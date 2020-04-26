using System.Collections.Generic;

namespace MATMEH_QUEST.Domain
{
    public class Room
    {
        public List<Human> Humans { get; set; }
        public List<Enemy> Enemies { get; set; }
        public List<Item> LevelItems { get; set; }

        public Room(List<Human> humans = null,List<Enemy> enemies = null, List<Item> levelItems = null)
        {
            this.Humans = humans;
            this.Enemies = enemies;
            this.LevelItems = levelItems;
        }
    }
}