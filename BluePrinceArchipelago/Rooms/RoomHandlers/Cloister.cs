
using System.Linq;
using BluePrinceArchipelago.Events;
using BluePrinceArchipelago.Utils;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using UnityEngine;

namespace BluePrinceArchipelago.Rooms.RoomHandlers;

class Cloister : RoomHandler
{
    private static bool _collected = false;
    public Cloister()
    { 
    }

    public override void OnRoomDrafted(GameObject roomGameObject)
    {
        RoomGameObject = roomGameObject;
        SetupEventHooks();
    }

    public override void SetupEventHooks()
    {
        FSMEventHandler.RegisteredEvents.Add("CloisterToken", new CloisterToken());

        var fsmPath = "_GAMEPLAY/_Pickup Items/Allowance Token/ALLOWANCE TOKEN";
        PlayMakerFSM fsm = RoomGameObject.transform.Find(fsmPath)?.gameObject?.GetComponent<PlayMakerFSM>();
        var stateName = "State 2";
        fsm.GetState(stateName)?.DisableActionsOfType<SendEvent>();
        fsm.GetState(stateName)?.AddAction(FSMEventHandler.RegisteredEvents["Apple Orchard Unlock"].Event);
    }

    public class CloisterToken : RegisteredFSMEvent {

        public new string Name { get; set; } = "Apple Orchard Unlock";

        public override void OnRegister()
        {
            ModInstance.APEventFSM.AddState(Name);
            ModInstance.APEventFSM.AddGlobalTransition(Name, Name);
            // Creates a new SendEvent instance that can be called by other FSMs to communicate important events to the mod (albeit a little jankily).
            Event = new SendEvent()
            {
                eventTarget = new FsmEventTarget()
                {
                    target = FsmEventTarget.EventTarget.GameObject,
                    gameObject = new FsmOwnerDefault()
                    {
                        gameObject = Plugin.ModObject,
                        ownerOption = OwnerDefaultOption.SpecifyGameObject
                    },
                    fsmName = "FSM",
                    sendToChildren = false,
                    excludeSelf = false
                },
                sendEvent = Plugin.ModObject.GetComponent<PlayMakerFSM>().GetGlobalTransition(Name).FsmEvent,
                everyFrame = false,
                delay = 0f
            };
        }

        public override void OnTrigger()
        {
            ModInstance.ModEventHandler.OnAllowanceCollected("Cloister Statue");
        }
    }
}