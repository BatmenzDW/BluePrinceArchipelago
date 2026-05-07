using System;
using System.Collections.Generic;
using HarmonyLib;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Il2CppInterop.Runtime.Injection;
using TMPro;
using UnityEngine;

namespace BluePrinceArchipelago.RoomHandlers;

public abstract class RoomHandler
{
    protected static GameObject UIOverlayCam => GameObject.Find("UI OVERLAY CAM");
    public GameObject RoomGameObject { get; set; }

    public HashSet<string> ObservedFSMs { get; } = [];

    public abstract void OnRoomDrafted(GameObject roomGameObject);
    public virtual void OnAfterRoomDrafted() { }
    public virtual void OnFSMStateChanged(Fsm fsm, string gameObjectName) { }
    

    public static readonly Dictionary<string, RoomHandler> RoomHandlers = new();

    public static RoomHandler CreateRoomHandler(string roomName)
    {
        if (RoomHandlers.TryGetValue(roomName, out var handler))
        {
            return handler;
        }

        handler = roomName switch 
        {
            "COMMISSARY" => new Commissary(),
            "SHOWROOM" => new Showroom(),
            "THE ARMORY" => new Armory(),
            "BOOKSHOP" => new Bookshop(),
            "GIFT SHOP" => new GiftShop(),
            "LOCKSMITH" => new Locksmith(),
            "TRADING POST" => new TradingPost(),
            _ => null
        };

        if (handler != null)
        {
            RoomHandlers[roomName] = handler;
            Logging.Log($"Created RoomHandler for {roomName}.");
        }
        return handler;
    }
}

public static class FsmRoomPatches
{
    [HarmonyPatch(typeof(Fsm), nameof(Fsm.UpdateStateChanges))]
    [HarmonyPostfix]
    static void Postfix(Fsm __instance)
    {
        if (__instance == null) return;
        var gameObjectName = __instance.GameObjectName;
        
        foreach (var roomHandler in RoomHandler.RoomHandlers.Values)
        {
            if (roomHandler.ObservedFSMs.Contains(gameObjectName))
            {
                roomHandler.OnFSMStateChanged(__instance, gameObjectName);
            }
        }
    }
}