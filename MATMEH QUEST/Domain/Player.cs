using System.Data.Common;
using System.Drawing;

namespace MATMEH_QUEST.Domain
{
    public class Player
    {
<<<<<<< HEAD
        private Point location;
        private int health;
        private Inventory inventory;

        public Player(Point location, int health, Inventory inventory)
        {
            this.location = location;
            this.health = health;
            this.inventory = inventory;
=======
        public Player()
        {
            Health = 100;
            state = PlayerState.Alive;
        }
        private enum PlayerState
        {
            Alive,
            Dead
        }
        
        public int Health;
        private PlayerState state;

        public bool IsAlive()
        {
            return Health > 0;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void Dead()
        {
            state = PlayerState.Dead;
>>>>>>> class_Player
        }
    }
}