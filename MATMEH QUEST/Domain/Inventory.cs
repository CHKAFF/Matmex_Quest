using System.Collections.Generic;
using static MATMEH_QUEST.Domain.Item;
using System.Linq;

namespace MATMEH_QUEST.Domain
{
    public class Inventory
    {
        public Dictionary<Item, int> items;
        public Inventory()
        {
            items = new Dictionary<Item, int>();
        }

        public bool InInventory(Item item)
        {
            return items.ContainsKey(item);
        }

        public void PutItem(Item item)
        {
            var itemInInventory = items
                .FirstOrDefault(i => i.Key.MissionID == item.MissionID &&
                                     i.Key.ObjectID == item.ObjectID).Key;
            if (itemInInventory == null)
                items[item] = 1;
            else
                items[itemInInventory] += 1;
        }

        public int GetItemCount(Item item)
        {
            return items[item];
        }

        public void TakeItem(Item item)
        {
            items.Remove(item);
        }
        
        
    }
}