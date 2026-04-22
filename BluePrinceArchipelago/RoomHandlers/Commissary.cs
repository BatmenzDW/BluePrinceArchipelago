
using System.Collections.Generic;
using BluePrinceArchipelago.Utils;
using HutongGames.PlayMaker;
using Il2CppSystem.Linq;
using UnityEngine;

namespace BluePrinceArchipelago.RoomHandlers;

public class Commissary : RoomHandler
{
    public List<Models.ShopItem> LocationPool { get; set; } = new List<Models.ShopItem>();
    public Models.ShopItem[] ShopItems { get; set; } = new Models.ShopItem[4];
    private PlayMakerFSM _ItemsForSaleFsm;
    private GameObject _CommissaryMenuGameObject;
    private PlayMakerFSM _CommissaryMenuFsm;
    private GameObject _ColliderGameObject;

    private readonly int _seed;

    public Commissary(int locationCount, int minPrice, int maxPrice, int seed)
    {
        _seed = seed;
        for (int i = 0; i < locationCount; i++)
        {
            LocationPool.Add(new Models.ShopItem
            {
                Name = $"Commissary Purchase {i + 1}",
                Price = new System.Random(seed + i).Next(minPrice, maxPrice + 1)
            });
        }
    }

    public override void OnRoomDrafted()
    {
        Logging.Log("Commissary drafted, setting up shop items.");
        _ItemsForSaleFsm = GameObject.Find("_GAMEPLAY/ITEMS FOR SALE")?.GetFsm("FSM");
        _CommissaryMenuGameObject = GameObject.Find("UI OVERLAY CAM/Commissary Menu");
        _CommissaryMenuFsm = _CommissaryMenuGameObject?.GetFsm("FSM");
        _ColliderGameObject = GameObject.Find("Click Commissary Collider");

        for (int i = 0; i < ShopItems.Length; i++)
        {
            if (LocationPool.Count == 0)
            {
                Logging.LogWarning("Not enough items in the location pool to fill all shop slots.");
                break;
            }

            var rand = new System.Random(_seed + i);

            var item = LocationPool[rand.Next(LocationPool.Count)];
            LocationPool.Remove(item);
            ShopItems[i] = item;
        }

        SetupItemsForSale();
    }

    private void SetupItemsForSale()
    {
        if (_ColliderGameObject == null)
        {
            Logging.LogError("Commissary Collider GameObject not found!");
            return;
        }

        PlayMakerFSM fSM = _ColliderGameObject.GetFsm("FSM");
        if (fSM == null)
        {
            Logging.LogError("FSM not found on Commissary Collider GameObject!");
            return;
        }

        for (int i = 0; i < ShopItems.Length; i++)
        {
            var item = ShopItems[i];
            if (item == null)
            {
                Logging.LogWarning($"Shop item at index {i} is null, skipping.");
                continue;
            }

            fSM.GetIntVariable($"ITEM {i + 1} PRICE").Value = item.Price;
            fSM.GetStringVariable($"ITEM {i + 1} NAME").Value = item.Name;
        }

        _CommissaryMenuFsm?.Update();
    }
}
