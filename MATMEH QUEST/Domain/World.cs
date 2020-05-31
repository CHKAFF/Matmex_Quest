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
            Humans = new List<Human>();
            Doors = new Dictionary<int, Door>();
<<<<<<< HEAD
            Doors[0] = new Door(Door.DoorState.Open, new Room(Resources.Деканат_задание, new List<Human>(){new Human(Human.HumanState.Ready, 1, new Point(700, 0), new List<Item>())}, new List<Item>()),new Point(7040, 0) );
            Doors[1] = new Door(Door.DoorState.Close, new Room(Resources.Команта1_задание, new List<Human>(), new List<Item>()),new Point(1050, 0) );
=======
            Doors[0] = new Door(Door.DoorState.Open, new Room(Resources.Деканат_задание, new List<Human>(){new Human(Human.HumanState.Ready, 0, new Point(700, 0), new List<Item>())}, new List<Item>()),new Point(7040, 0) );
            Doors[1] = new Door(Door.DoorState.Open, new Room(Resources.Комната601_задание, new List<Human>(), new List<Item>()),new Point(1050, 0) );
>>>>>>> ae3613afbc6e5d0cdd9ceabffcfef3816b13e90d
        }
    }
    
}