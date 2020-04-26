using System.Collections.Generic;
using System.Security.Policy;

namespace MATMEH_QUEST.Domain
{
    public class World
    {
        public Dictionary<int, Door> Doors{ get; set; }
        public List<Human> Humans { get; set; }
        public List<Enemy> Enemies { get; set; }
        public HashSet<Item> LevelItems { get; set; }

        public World()
        {
            for (int i = 1; i < 10; i++)
            {
                Doors[i] = new Door(Door.DoorState.Close, new Room());
            }
            var decRoom = new Room(new List<Human>(){new Human(Human.HumanState.Ready)});
            Doors[10] = new Door(Door.DoorState.Open, decRoom);
        }
    }
}