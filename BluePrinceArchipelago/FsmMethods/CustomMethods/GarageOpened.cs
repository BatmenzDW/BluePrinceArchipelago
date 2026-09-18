using BluePrinceArchipelago.Events;
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
    public class GarageOpened() : RegisteredCustomFsmMethod
    {
        public new string Name { get; set; } = "GarageOpened";

        public override void OnCalled()
        {
            //Not implemented yet.
        }
    }
}
