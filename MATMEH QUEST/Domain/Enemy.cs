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
            return state == PlayerState.Alive;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
                state = PlayerState.Dead;
        }

        public void Dead()
        {
            state = PlayerState.Dead;
        }
    }
}