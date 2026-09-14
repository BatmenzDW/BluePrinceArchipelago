using System.Collections.Generic;

namespace BluePrinceArchipelago.Archipelago
{
    public static class DeathLinkMessages
    {
        private static Dictionary<string, string[]> _DeathLinkMessageDict = new Dictionary<string, string[]>()
        {
            {"Antechanber", ["{0} went post-mortem in the Antechamber.", "{0} thought they had reached Room 46."]},
            {"Apple Orchard", ["{0} discovered gravity in the Apple Orchard."]},
            {"Aquarium", ["{0} is swimming with the fishes in the Aquarium.", "{0} 's tank contains a dead herring."]},
        };
        private static Dictionary<string, string[]> _DeathLinkSpoilerMessageDict = new Dictionary<string, string[]>()
        { 

        };
        public static Dictionary<string, string[]> DeathLinkMsgDict { get; private set; } = new Dictionary<string, string[]>();

        public static void Initialize() {
            if (SpoilersEnabled) {
                EnableSpoilers();
                return;
            }
            DeathLinkMsgDict = _DeathLinkMessageDict;
        }
        public static bool SpoilersEnabled = false;

        public static void EnableSpoilers()
        {
            if (!SpoilersEnabled)
            {
                DeathLinkMsgDict = new();
                foreach (string key in _DeathLinkMessageDict.Keys)
                {
                    DeathLinkMsgDict[key] = [.. _DeathLinkMessageDict[key], .. _DeathLinkSpoilerMessageDict[key]];
                }
            }
            SpoilersEnabled |= true;
        }
        public static void DisableSpoilers()
        {
            if (SpoilersEnabled)
            {
                DeathLinkMsgDict = _DeathLinkMessageDict;
            }
            SpoilersEnabled |= false;
        }
    }
}
