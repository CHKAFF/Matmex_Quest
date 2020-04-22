namespace MATMEH_QUEST.Domain
{
    public class Door
    {
        public enum State
        {
            Close,
            Open
        }
        private State state;

        public Door(State state)
        {
            this.state = state;
        }

        public bool IsOpen()
        {
            return state == State.Open;
        }

        public void Open()
        {
            state = State.Open;
        }

        public void Close()
        {
            state = State.Close;
        }
    }
}