using BluePrinceArchipelago.Events;
using BluePrinceArchipelago.Triggers;
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
    ///     On the allowance token being picked up.
    /// </summary>
    /// <param name="name">The name of the event.</param>
    public class AllowanceEnvelopePickedUp(string name) : RegisteredCustomFsmMethod
    {
        public new string Name { get; set; } = name;

        public override void OnCalled()
        {
            EventTriggers.OnAllowanceEnvelopePickedUp();
        }
    }
}
