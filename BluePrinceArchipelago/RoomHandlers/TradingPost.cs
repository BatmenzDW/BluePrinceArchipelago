using System;
using BluePrinceArchipelago.Utils;
using BluePrinceArchipelago.Utils.Actions;
using HarmonyLib;
using HutongGames.PlayMaker;
using Il2CppSystem.Linq;
using UnityEngine;

namespace BluePrinceArchipelago.RoomHandlers
{
    public class TradingPost : RoomHandler
    {
        private PlayMakerFSM _ClickTradingPostColliderFSM;
        private PlayMakerFSM _MoreButtonFSM;
        public TradingPost()
        {
            Logging.Log("Initializing Trading Post.");
            ObservedFSMs.Add("Click Trading Post Collider");
            ObservedFSMs.Add("more button");
        }

        public override void OnRoomDrafted(GameObject roomGameObject)
        {
            RoomGameObject = roomGameObject;
            _ClickTradingPostColliderFSM = RoomGameObject.transform.Find("_GAMEPLAY/ITEMS FOR TRADE/Click Trading Post Collider").gameObject.GetFsm("FSM");
            _MoreButtonFSM = UIOverlayCam.transform.Find("Trading Post Menu/Menu Buttons/more button").gameObject.GetFsm("FSM");
        }

        public override void OnAfterRoomDrafted()
        {
            // Logging.Log("Trading Post drafted. Setting up FSM hooks.");
        }

        private static string _previousStateName = "";
        public override void OnFSMStateChanged(Fsm fsm, string gameObjectName)
        {
            if (gameObjectName == "Click Trading Post Collider")
            {
                var state = fsm.ActiveState;
                if (state == null) return;

                if (state.Name == "Click" && _previousStateName != "Click")
                {
                    Logging.Log("Trading Post Clicked.");
                }
                _previousStateName = state.Name;
            }
        }
    }
}   