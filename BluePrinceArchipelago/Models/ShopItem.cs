
using Archipelago.MultiClient.Net.Models;
using BluePrinceArchipelago.Archipelago;
using BluePrinceArchipelago.Utils;

namespace BluePrinceArchipelago.Models
{
    public class ShopItem
    {
        public string Name { get; set; }
        public string ScoutHint { get; set; }

        public string GetScoutHint()
        {
            if (!ArchipelagoClient.Authenticated || ArchipelagoClient.ServerData.ReceivedItems.Contains(Name))
                return Name;

            if (ScoutHint != null)
                return ScoutHint;

            string locationName = Name;
            if (!Name.Contains("Upgrade Disk"))
                locationName = Name + " First Pickup";

            long locationid = Plugin.ArchipelagoClient.GetLocationFromName(locationName);
            if (locationid == -1)
            {
                Logging.LogWarning($"Location '{locationName}' not found in Archipelago data.");
                return Name; // Fallback to the original name if location is not found
            }
            Plugin.ArchipelagoClient.ScoutLocationHint([locationid]);
            ScoutedItemInfo scout = ArchipelagoClient.ServerData.LocationItemMap[locationid];

            string playerName = scout?.Player?.Name ?? "";
            string itemName = scout?.ItemName ?? "";
            string description = scout?.Flags.ItemFlagDescription();

            ScoutHint = $"{playerName}'s {itemName} {description}";
            return ScoutHint;
        }
    }
}