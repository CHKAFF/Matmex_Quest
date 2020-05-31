using System.Collections.Generic;
using static MATMEH_QUEST.Domain.Item;
using System.Linq;

namespace MATMEH_QUEST.Domain
{
    public class Inventory
    {
        public Dictionary<Item, int> Items;
        public Inventory()
        {
            Items = new Dictionary<Item, int>();
        }

        public bool InInventory(Item item)
        {
            return Items.ContainsKey(item);
        }

        public void PutItem(Item item)
        {
            var itemInInventory = Items
                .FirstOrDefault(i => i.Key.MissionId == item.MissionId &&
                                     i.Key.ObjectId == item.ObjectId).Key;
            if (itemInInventory == null)
                Items[item] = 1;
            else
                Items[itemInInventory] += 1;
        }

        public int GetItemCount(Item item)
        {
            return Items[item];
        }

        public void TakeItem(Item item)
        {
            Items.Remove(item);
        }
        
        
    }
}