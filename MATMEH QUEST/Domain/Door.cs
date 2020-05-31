using System.Drawing;

namespace MATMEH_QUEST.Domain
{
    public class Door
    {
        public Point Location;
        public Room Room;
        
        public enum DoorState
        {
            Close,
            Open
        }
        
        public DoorState State;

        public Door(DoorState state, Room room, Point location)
        {
            Location = location;
            State = state;
            Room = room;

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