using BluePrinceArchipelago.Items;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using BluePrinceArchipelago.Utils;
using UnityEngine;

namespace BluePrinceArchipelago.Rooms.RoomHandlers;

class GreatHall : RoomHandler
{
    public override void OnRoomDrafted(GameObject roomGameObject)
    {
        roomGameObject = ModRoomManager.GetRoomInstance("Great Hall");
        if (roomGameObject != null)
        {
            Transform[] tranforms = roomGameObject.transform.FindAllRecursive("8");
            foreach (Transform transform in tranforms)
            {
                PlayMakerFSM ItemDropFSM = transform.GetComponent<PlayMakerFSM>();

                if (ItemDropFSM != null)
                {
                    bool found = ModItemManager.UpgradeDisks.FoundLocations.Contains("GREAT HALL");
                    Logging.LogWarning(found);
                    FsmBool CanSpawnDisk = ItemDropFSM.AddBoolVariable("CanSpawnDisk");
                    CanSpawnDisk.Value = found;
                    ItemDropFSM.GetState("State 1").GetFirstActionOfType<BoolTest>().boolVariable = CanSpawnDisk;
                    ArrayListContains CheckInInventory = ItemDropFSM.GetState("State 2").GetFirstActionOfType<ArrayListContains>();
                    CheckInInventory.isContainedEvent = CheckInInventory.isNotContainedEvent;
                }
                else
                {
                    Logging.LogWarning("Error changing Great Hall Upgrade disk spawn logic.");
                }
            }
        }

    }
}

