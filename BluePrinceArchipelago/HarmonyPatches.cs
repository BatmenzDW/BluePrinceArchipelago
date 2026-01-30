using HarmonyLib;
using HutongGames.PlayMaker.Actions;
using System;
using System.Reflection;
using UnityEngine;

namespace BluePrinceArchipelago
{
    public class ItemPatches
    {
        [HarmonyPatch(typeof(PmtSpawn), "OnEnter")]
        [HarmonyPrefix]
        static void PreFix(PmtSpawn __instance)
        {
            if (__instance != null)
            {
                GameObject obj = __instance.gameObject.value;
                string poolName = __instance.poolName.value;
                GameObject transformObj = __instance.spawnTransform.value;
                if (poolName == "Pickup")
                {
                    ModInstance.OnItemSpawn(obj, poolName, transformObj);
                    //Can theoritically replace the game object spawned by replacing the __instance.gameObject.
                }
                else
                {
                    //TODO replace this with a similar method to above
                    //MelonLogger.Msg($"PoolName: {poolName}");
                    //MelonLogger.Msg($"Item: {obj.name}");
                    //MelonLogger.Msg($"Transform: {transformObj.name} - {transformObj.transform.position.ToString()}");
                }
            }
        }
    }
    public class RoomPatches {
        [HarmonyPatch(typeof(RoomDraftHelper), nameof(RoomDraftHelper.InitializeDraft))]
        [HarmonyPostfix]
        static void PostFix(RoomDraftHelper __instance)
        {
            ModInstance.OnDraftInitialize(__instance);
        }
    }
}
