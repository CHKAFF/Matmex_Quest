using System.Collections.Generic;
using System.Security.Policy;

namespace MATMEH_QUEST.Domain
{
    public class World
    {
        public List<Door> Doors{ get; set; }
        public List<Human> Humans { get; set; }
        public List<Enemy> Enemies { get; set; }
        public HashSet<Item> LevelItems { get; set; }

        public World(List<Door> doors, List<Human> humans, List<Enemy> enemies, HashSet<Item> levelItems)
        {
            this.Doors = doors;
            this.Humans = humans;
            this.Enemies = enemies;
            this.LevelItems = levelItems;
        }

    }
}