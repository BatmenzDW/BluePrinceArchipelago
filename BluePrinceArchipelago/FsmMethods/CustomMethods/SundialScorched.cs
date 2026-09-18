using BluePrinceArchipelago.Events;
using BluePrinceArchipelago.Triggers;
using BluePrinceArchipelago.Utils;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;

namespace BluePrinceArchipelago.FsmMethods.CustomMethods
{
    public class SundialScorched : RegisteredCustomFsmMethod
    {
        public new string Name { get; set; } = "SundialScorched";

        public override void OnCalled()
        {
            EventTriggers.OnSundailScorched();
        }
    }
}
