namespace MATMEH_QUEST.Domain
{
    public class Enemy : ILife
    {
        public int Health;
        private PlayerState state;
        
        public Enemy(int health)
        {
            this.Health = health;
            state = PlayerState.Alive;
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
    }
}