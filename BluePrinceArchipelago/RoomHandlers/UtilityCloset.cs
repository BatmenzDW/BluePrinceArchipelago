using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BluePrinceArchipelago.RoomHandlers
{
    public class UtilityCloset : RoomHandler
    {
        public UtilityCloset()
        {
            Logging.Log("Initializing Utility Closet.", "Utility Closet");
        }

        public override void OnRoomDrafted(GameObject roomGameObject)
        {
            RoomGameObject = roomGameObject;
        }

        public override void OnAfterRoomDrafted()
        {
            Logging.Log("Attempting to override Gemstone Caverns", "Utility Closet");
            // Runs the code to prevent Gemstone Cavern from being unlocked normally.
            //PermanentUnlocks.Unlocks.GemstoneCaverns.PreventDefault();
        }
    }
}
