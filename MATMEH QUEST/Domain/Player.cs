namespace MATMEH_QUEST.Domain
{
    public class Player
    {
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
        }
    }
}