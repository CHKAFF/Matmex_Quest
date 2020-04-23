using System.Collections.Generic;
using System.Drawing;
using System.Xml.Linq;
using System.Linq;

namespace MATMEH_QUEST.Domain
{
    public class Game
    {
        public World World;
        public Player Player;
        public Inventory Inventory;
        public Game()
        {
            
        }

        public void New()
        {
            World = new World();
            Player = new Player(new Point(0,0),100);
            Inventory = new Inventory();
        }

        public void Load()
        {
            World = new World();
            Player = new Player();
        }
    }
}