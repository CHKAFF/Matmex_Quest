namespace MATMEH_QUEST.Domain
{
    public interface ILife
    {
        bool IsAlive();
        void TakeDamage(int damage);
        void Dead();
    }
}