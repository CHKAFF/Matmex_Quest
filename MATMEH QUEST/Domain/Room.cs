using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MATMEH_QUEST.Domain
{
    public class Room
    {
        public List<Human> Humans { get; set; }
        public List<Item> LevelItems { get; set; }
        public int[] AvailableX = {0, 2389};
        public Bitmap Background;
        public Room(Bitmap background, List<Human> humans = null, List<Item> levelItems = null)
        {
            Background = background;
            Humans = humans;
            LevelItems = levelItems;
        }

        public Item GetItem(Point click)
        {
            foreach (var element in LevelItems.Where(x => Math.Abs(x.Location.X - click.X) <= 5 && Math.Abs(x.Location.Y - click.Y) <= 5))
            {
                LevelItems.Remove(element);
                return element;
            } 
            return null;
        }

    }
}