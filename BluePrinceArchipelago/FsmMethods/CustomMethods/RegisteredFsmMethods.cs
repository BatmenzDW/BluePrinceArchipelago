using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using Il2CppInterop.Runtime;

namespace BluePrinceArchipelago.FsmMethods.CustomMethods
{
    public abstract class RegisteredCustomFsmMethod
    {
        public string Name { get; set; }

        /// <summary>
        ///     The code for when an event occurs.
        /// </summary>
        public abstract void OnCalled();


        /// <summary>
        ///     The code for when an event is registered.
        /// </summary>
        public virtual void OnRegister() { }

        /// <summary>
        ///     Updates anything that needs to update on run.
        /// </summary>
        public virtual void Update() { 
        }
    }
}
