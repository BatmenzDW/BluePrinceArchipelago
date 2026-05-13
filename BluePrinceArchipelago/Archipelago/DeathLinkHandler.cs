using System;
using System.Collections.Generic;
using Archipelago.MultiClient.Net.BounceFeatures.DeathLink;
using BepInEx;
using BluePrinceArchipelago.Utils;
using HutongGames.PlayMaker;
using UnityEngine;

namespace BluePrinceArchipelago.Archipelago;

public class DeathLinkHandler
{
    private static bool _deathLinkEnabled = true;
    public static bool deathLinkEnabled
    {
        get => _deathLinkEnabled && ArchipelagoOptions.DeathLinkType != DeathLinkType.option_none;
        private set
        {
            _deathLinkEnabled = value;
        }
    }

    private int _deathLinkCount = 0;
    private string slotName;
    private readonly DeathLinkService service;
    private readonly Queue<DeathLink> deathLinks = new();

    /// <summary>
    /// instantiates our death link handler, sets up the hook for receiving death links, and enables death link if needed
    /// </summary>
    /// <param name="deathLinkService">The new DeathLinkService that our handler will use to send and
    /// receive death links</param>
    /// <param name="enableDeathLink">Whether we should enable death link or not on startup</param>
    public DeathLinkHandler(DeathLinkService deathLinkService, string name, bool enableDeathLink = true)
    {
        service = deathLinkService;
        service.OnDeathLinkReceived += DeathLinkReceived;
        slotName = name;
        deathLinkEnabled = enableDeathLink;

        if (deathLinkEnabled)
        {
            service.EnableDeathLink();
        }
    }

    /// <summary>
    /// enables/disables death link
    /// </summary>
    public void ToggleDeathLink()
    {
        deathLinkEnabled = !deathLinkEnabled;

        if (deathLinkEnabled)
        {
            service.EnableDeathLink();
        }
        else
        {
            service.DisableDeathLink();
        }
    }

    /// <summary>
    /// what happens when we receive a deathLink
    /// </summary>
    /// <param name="deathLink">Received Death Link object to handle</param>
    private void DeathLinkReceived(DeathLink deathLink)
    {
        deathLinks.Enqueue(deathLink);

        Logging.Log(deathLink.Cause.IsNullOrWhiteSpace()
            ? $"Received Death Link from: {deathLink.Source}"
            : deathLink.Cause, "DeathLink");

        KillPlayer();
    }

    /// <summary>
    /// can be called when in a valid state to kill the player, dequeueing and immediately killing the player with a
    /// message if we have a death link in the queue
    /// </summary>
    public void KillPlayer()
    {
        try
        {
            if (!ModInstance.IsInRun) return;
            if (deathLinks.Count < 1) return;

            var deathLink = deathLinks.Dequeue();
            var cause = deathLink.Cause.IsNullOrWhiteSpace() ? GetDeathLinkCause(deathLink) : deathLink.Cause;

            KillPlayer(cause);
        }
        catch (Exception e)
        {
            Logging.LogError(e, "DeathLink");
        }
    }

    public static void ForceKillPlayer(string cause)
    {
        try
        {
            KillPlayer(cause);
        }
        catch (Exception e)
        {
            Logging.LogError(e, "DeathLink");
        }
    }

    private static bool _localDeathInProgress = false;

    private static void KillPlayer(string cause)
    {
        _localDeathInProgress = true;
        ArchipelagoConsole.LogMessage(cause, "DeathLink");

        ModInstance.StepManager.FindIntVariable("Adjustment Amount").Value = -1000;
        ModInstance.StepManager.SendEvent("Update");

        // ZERO STEP ENDING: Send Event- State 8
    }

    /// <summary>
    /// returns message for the player to see when a death link is received without a cause
    /// </summary>
    /// <param name="deathLink">death link object to get relevant info from</param>
    /// <returns></returns>
    private string GetDeathLinkCause(DeathLink deathLink)
    {
        return $"Received death from {deathLink.Source}";
    }

    private bool _bedroom = false;

    public void SendStepsDeathLink()
    {
        if (_localDeathInProgress)
        {
            _localDeathInProgress = false;
            return;
        }

        if (!deathLinkEnabled) return;

        if (ArchipelagoOptions.DeathLinkType != DeathLinkType.option_steps) return;

        SendDeathLink("Ran out of steps");
    }

    public void SendEndOfDayDeathLink(PlayMakerFSM fsm)
    {
        Logging.Log("End of Day, checking for deathlink send", "DeathLink");
        if (_localDeathInProgress)
        {
            _localDeathInProgress = false;
            return;
        }

        if (!deathLinkEnabled) return;

        var currentRoom = fsm.GetStringVariable("Current Room String").Value;

        if (currentRoom.Contains("adyship") || currentRoom.Contains("aster") || currentRoom.Contains("ervants") || currentRoom.Contains("unk"))
        {
            _bedroom = true;
        }

        if (ArchipelagoOptions.DeathLinkType != DeathLinkType.option_steps) SendDeathLink("End of Day");
    }

    /// <summary>
    /// called to send a death link to the multiworld
    /// </summary>
    public void SendDeathLink(string cause = null)
    {
        try
        {
            if (!deathLinkEnabled) return;

            if (_bedroom)
            {
                _bedroom = false;
                return;
            }

            if (ArchipelagoOptions.DeathLinkMonkException && ModInstance.GetPersistentDataString("Blessing") == "Monk")
            {
                ArchipelagoConsole.LogMessage("Death Link prevented due to Monk blessing.", "DeathLink");
                return;
            }

            if (ArchipelagoOptions.DeathLinkGrace > _deathLinkCount)
            {
                _deathLinkCount++;
                ArchipelagoConsole.LogMessage($"Death Link grace active. Deaths until next deathlink can be sent: {ArchipelagoOptions.DeathLinkGrace - _deathLinkCount}", "DeathLink");
                return;
            }

            ArchipelagoConsole.LogMessage($"Sent {cause} DeathLink", "DeathLink");

            // add the cause here
            var linkToSend = new DeathLink(slotName, cause);

            service.SendDeathLink(linkToSend);
        }
        catch (Exception e)
        {
            Logging.LogError(e, "DeathLink");
        }
    }
}