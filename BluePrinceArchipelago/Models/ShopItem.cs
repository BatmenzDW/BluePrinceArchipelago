
namespace BluePrinceArchipelago.Models
{
    public class ShopItem
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public string GetScoutHint()
        {
            return "Scout Hint Placeholder";
        }
    }
}