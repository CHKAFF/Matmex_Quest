﻿using System.Collections.Generic;
using static MATMEH_QUEST.Domain.Item;

namespace MATMEH_QUEST.Domain
{
    public class Inventory
    {
        private HashSet<Item> items;
        public Inventory()
        {
            items = new HashSet<Item>();
        }

        public bool InInventory(Item item)
        {
            return items.Contains(item);
        }

        public void PutItem(Item item)
        {
            items.Add(item);
        }

        public void TakeItem(Item item)
        {
            items.Remove(item);
        }
    }
}