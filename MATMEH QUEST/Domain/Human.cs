namespace MATMEH_QUEST.Domain
{
    public class Human
    {
        public enum HumanState
        {
            Ready,
            Awaiting,
            NotReady
        }

        private HumanState state;

        public Human(HumanState state) 
        {
            this.state = state;
        }

        public bool IsReady()
        {
            return state == HumanState.Ready;
        }

        public void MakeReady()
        {
            state = HumanState.Ready;
        }

        public void MakeNotReady()
        {
            state = HumanState.NotReady;
        }

        public void MakeAwaiting()
        {
            state = HumanState.Awaiting;
        }
    }
}