using BluePrinceArchipelago.Events;
using BluePrinceArchipelago.Items;
using BluePrinceArchipelago.Utils;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BluePrinceArchipelago.FsmMethods.CustomMethods
{
    /// <summary>
    ///     An Unlock event for the BlackBridgeGrotto.
    /// </summary>
    public class BlackBridgeGrottoUnlock : RegisteredCustomFsmMethod
    {

        public new string Name { get; set; } = "BlackbridgeGrottoUnlock";

        public override void OnCalled()
        {
            Unlocks.BlackBridgeGrotto.FoundLocation();
        }
    }
}
