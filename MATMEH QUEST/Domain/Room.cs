using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MATMEH_QUEST.Domain
{
    public class Room
    {
        public List<Human> Humans { get; set; }
        public List<Enemy> Enemies { get; set; }
        public List<Item> LevelItems { get; set; }
        private int[] availableX = {23, 45};
        private int[] availableY = {6700, 2389};

        public Room(List<Human> humans = null,List<Enemy> enemies = null, List<Item> levelItems = null)
        {
            this.Humans = humans;
            this.Enemies = enemies;
            this.LevelItems = levelItems;
        }

        public Item GetItem(Point click)
        {
            foreach (var element in LevelItems.Where(x => x.Location == click))
            {
                return element;
            }
            var item = LevelItems[0];
            LevelItems.RemoveAt(0);
            return item;
        }

    }
}