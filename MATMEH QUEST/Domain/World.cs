using System.Collections.Generic;
using System.Drawing;
using System.Security.Policy;
using MATMEH_QUEST.Properties;

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
            var firstRoom = new Room(Resources.room, levelItems: new List<Item>(){expectedItem});
            Doors[1] = new Door(Door.DoorState.Close, firstRoom, new Point(800, 200));
            for (var i = 2; i < 10; i++)
            {
                Doors[i] = new Door(Door.DoorState.Close, new Room(Resources.room), new Point(i, 0));
            }
            var decRoom = new Room(Resources.Деканат, new List<Human>(){new Human(Human.HumanState.Ready, 0,
                new Point(20, 15), new List<Item>(){expectedItem})});
            Doors[10] = new Door(Door.DoorState.Open, decRoom, new Point(7000, 200));
        }
    }
}