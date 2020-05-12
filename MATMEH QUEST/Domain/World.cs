using System.Collections.Generic;
using System.Drawing;
using System.Security.Policy;

namespace MATMEH_QUEST.Domain
{
    public class World
    {
        public Dictionary<int, Door> Doors{ get; set; }
        public List<Human> Humans { get; set; }
        public HashSet<Item> LevelItems { get; set; }
        public int[] availableY = {23, 45};
        public int[] AvailableX = new int[2]{50,1100};
        public PointF Location;
        public World()
        {
            Location = new PointF(0,0);
            Doors = new Dictionary<int, Door>();
            var expectedItem = new Item(0, 0, new Point(15, 15));
            var firstRoom = new Room(levelItems: new List<Item>(){expectedItem});
            Doors[0] = new Door(Door.DoorState.Close, firstRoom, new Point(5, 0));
            for (var i = 600; i < 610; i++)
            {
                Doors[i] = new Door(Door.DoorState.Close, new Room(), new Point(i, 0));
            }
            var decRoom = new Room(new List<Human>(){new Human(Human.HumanState.Ready, 0,
                new Point(20, 15), new List<Item>(){expectedItem})});
            Doors[10] = new Door(Door.DoorState.Open, decRoom, new Point(25, 0));
        }
    }
}