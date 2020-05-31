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
        public int[] AvailableX = {50, 1100};
        public PointF Location;

        public World()
        {
            Doors = new Dictionary<int, Door>();
            Doors[0] = new Door(Door.DoorState.Open, new Room(Resources.Деканат_задание, new List<Human>(), new List<Item>()),new Point(0, 350) );
        }
    }
    
}