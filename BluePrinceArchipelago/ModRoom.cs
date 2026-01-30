using BluePrinceArchipelago.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BluePrinceArchipelago.ModRooms
{
    public class ModRoomManager {
        private List<ModRoom> rooms = [];
        public List<ModRoom> Rooms { 
            get { return rooms; }
            set { rooms = value; }
        }

        public ModRoomManager() {
        }
        public void AddRoom(ModRoom room) { 
            rooms.Add(room);
        }
        public void AddRoom(string name, List<string> pickerArrays, bool isUnlocked, bool isRandomizable = true) {
            rooms.Add(new ModRoom(name, GameObject.Find("__SYSTEM/The Room Engines/" + name), pickerArrays, isUnlocked, isRandomizable));
        }
        public void Intialize() {
            Plugin.BepinLogger.LogMessage("Attempting to modify room pools");
            foreach (ModRoom room in rooms) {
                if (room.IsUnlocked && room.IsRandomizable)
                {
                    foreach (string arrayName in room.PickerArrays)
                    {
                        PlayMakerArrayListProxy array = ModInstance.PickerDict[arrayName];
                        if (!array.arrayList.Contains(room.GameObj))
                        {
                            array.Add(room.GameObj, "GameObject");
                            ModInstance.PlanPicker.GetComponent<PlayMakerFSM>().Fsm.Variables.GetFsmBool("POOL REMOVAL").value = false;
                            Plugin.BepinLogger.LogMessage($"Added {room.Name} to {arrayName}");
                        }
                    }
                }
                else if (room.IsRandomizable)
                {
                    foreach (string arrayName in room.PickerArrays)
                    {
                        PlayMakerArrayListProxy array = ModInstance.PickerDict[arrayName];
                        if (array.arrayList.Contains(room.GameObj))
                        {
                            array.Remove(room.GameObj, "GameObject");
                            ModInstance.PlanPicker.GetComponent<PlayMakerFSM>().Fsm.Variables.GetFsmBool("POOL REMOVAL").value = false;
                            Plugin.BepinLogger.LogMessage($"Removed {room.Name} from {arrayName}");
                        }
                    }
                }
            }
        }
    }
    public class ModRoom(String name, GameObject gameObject, List<string> pickerArrays, bool isUnlocked, bool isRandomizable = true)
    {
        public string Name { get; set; } = name;
        public GameObject GameObj { get; set; } = gameObject;
        public List<string> PickerArrays { get; set; } = pickerArrays;
        public bool IsUnlocked { get; set; } = isUnlocked;
        public bool HasBeenDrafted { get; set; } = false;
        public bool IsRandomizable { get; set; } = isRandomizable;
    }
}
