using System.Drawing;

namespace MATMEH_QUEST.Domain
{
    public class Player
    {
        public Player(Point location, int health)
        {
            this.Health = health;
            state = PlayerState.Alive;
            this.Location = location;
        }
        private enum PlayerState
        {
            Alive,
            Dead
        }
        
        public int Health;
        private PlayerState state;
        public Point Location;

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
        }
    }
}