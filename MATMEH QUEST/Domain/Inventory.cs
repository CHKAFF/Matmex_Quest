using System.Collections.Generic;
using MATMEH_QUEST.Domain.Item;

namespace MATMEH_QUEST.Domain
{
    public class Inventory
    {
        private HashSet<item> items;
        public Inventory()
        {
            items = new HashSet<item>();
        }

        public item PutItem()
        {
            
        }

        public item TakeItem()
        {
            
        }
    }
}