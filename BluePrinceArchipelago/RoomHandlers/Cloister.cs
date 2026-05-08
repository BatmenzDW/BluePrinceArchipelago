
using HutongGames.PlayMaker;
using UnityEngine;

namespace BluePrinceArchipelago.RoomHandlers;

class Cloister : RoomHandler
{
    public Cloister()
    {
        ObservedFSMStates.Add("ALLOWANCE TOKEN", ["State"]);
    }

    public override void OnFSMStateChanged(Fsm fsm, string gameObjectName, string newState)
    {
        var gameObject = fsm.GameObject;
        while (gameObject.name.ToUpper() == "ALLOWANCE TOKEN") // several objects called allowance token are nested
        {
            gameObject = gameObject.transform.parent.gameObject;
        }

        var parent = gameObject.transform.parent.gameObject;
        Logging.Log($"Allowance Token state changed to {newState} in. Parent is: {parent.name}", "Cloister");
        var parent2 = parent.transform.parent.gameObject;
        Logging.Log($"Parent's parent is: {parent2.name}", "Cloister");
        var parent3 = parent2.transform.parent.gameObject;
        Logging.Log($"Parent's parent's parent is: {parent3.name}", "Cloister");
    }

    public override void OnRoomDrafted(GameObject roomGameObject)
    {
        RoomGameObject = roomGameObject;
    }
}