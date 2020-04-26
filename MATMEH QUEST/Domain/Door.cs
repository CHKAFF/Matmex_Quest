namespace MATMEH_QUEST.Domain
{
    public class Door
    {
        public Room Room;
        public enum DoorState
        {
            Close,
            Open
        }
        public DoorState State;

        public Door(DoorState state, Room room)
        {
            this.State = state;
            this.Room = room;

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

        public Room EnterRoom()
        {
            return Room;
        }

    }
}