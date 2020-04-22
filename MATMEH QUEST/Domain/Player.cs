using System.Data.Common;
using System.Drawing;

namespace MATMEH_QUEST.Domain
{
    public class Player
    {
        private Point location;
        private int health;
        private Inventory inventory;

        public Player(Point location, int health, Inventory inventory)
        {
            this.location = location;
            this.health = health;
            this.inventory = inventory;
        }
    }
}