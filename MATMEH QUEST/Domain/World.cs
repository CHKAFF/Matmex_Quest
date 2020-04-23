using System.Collections.Generic;
using System.Security.Policy;

namespace MATMEH_QUEST.Domain
{
    public class World
    {
        private readonly double height;
        private readonly double width;
        public List<Door> Doors{ get; set; }
        public List<Human> Humans { get; set; }
        public List<Enemy> Enemies { get; set; }
        public HashSet<Item> LevelItems { get; set; }

        public World(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

    }
}