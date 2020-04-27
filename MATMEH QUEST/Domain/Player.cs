using System.Drawing;

namespace MATMEH_QUEST.Domain
{
    public class Player : ILife
    {
        
        public int Health;
        private PlayerState state;
        public Point Location;
        public int Height = 100;
        public int Width = 200;
        
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

        public bool IsAlive()
        {
            return Health > 0 && state == PlayerState.Alive;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void Dead()
        {
            state = PlayerState.Dead;
        }

        public void MoveLeft()
        {
            Location.X += 1;
        }

        public void MoveRight()
        {
            Location.X -= 1;
        }

        public void MoveUp()
        {
            Location.Y -= 1;
        }

        public void MoveDown()
        {
            Location.Y += 1;
        }

    }
}