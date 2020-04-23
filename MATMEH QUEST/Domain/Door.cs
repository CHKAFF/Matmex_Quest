namespace MATMEH_QUEST.Domain
{
    public class Door
    {
        public enum DoorState
        {
            Close,
            Open
        }
        public DoorState State;

        public Door(DoorState state)
        {
            this.State = state;
        }

        public bool IsOpen()
        {
            return State == DoorState.Open;
        }

        public void Open()
        {
            State = DoorState.Open;
        }

        public void Close()
        {
            State = DoorState.Close;
        }
    }
}