using System.Collections.Generic;
using System.Drawing;
using System.Security.Policy;

namespace MATMEH_QUEST.Domain
{
    public class World
    {
        public Dictionary<int, Door> Doors{ get; set; }
        public List<Human> Humans { get; set; }
        public List<Enemy> Enemies { get; set; }
        public HashSet<Item> LevelItems { get; set; }
        private int[] availableX = {23, 45};
        private int[] availableY = {6700, 2389};
        public World()
        {
            for (var i = 1; i < 10; i++)
            {
                Doors[i] = new Door(Door.DoorState.Close, new Room(), new Point(i, 0));
            }
            var decRoom = new Room(new List<Human>(){new Human(Human.HumanState.Ready)});
            Doors[10] = new Door(Door.DoorState.Open, decRoom, new Point(15, 0));
        }
    }
}