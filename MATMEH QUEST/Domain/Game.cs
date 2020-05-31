using System;
using System.Drawing;
using System.Linq;
using MATMEH_QUEST.Properties;

namespace MATMEH_QUEST.Domain
{
    public enum CurrentAction
    {
        TalkWithHuman,
        GiveItem,
        TakeItem,
        EnterInRoom,
        LeaveRoom
    }
    public class Game
    {
        public World World;
        public Player Player;
        public Inventory Inventory;
        public Room Room;
        public CurrentAction CurrentAction;
        public PointF pointInWorld;
        public bool FlagDecan;

        public void New()
        {
            FlagDecan = false;
            World = new World();
            Player = new Player(new PointF(50,300));
            Inventory = new Inventory();
            Room = null;
            CurrentAction = CurrentAction.EnterInRoom;
        }

        public bool EnterInRoom()
        {
            if (Room != null)
                return true;
            foreach (var door in World.Doors)
            {
                if (Math.Abs(Player.Location.X - door.Value.Location.X) < 100 && door.Value.IsOpen())
                {
                    Room = door.Value.Room;
                    pointInWorld = Player.Location;
                    Player.Location.X = 50;
                    Player.Location.Y = 350;
                    return false;
                }
            }
            return true;
        }

        public bool LeaveFromRoom()
        {
            if(Math.Abs(Player.Location.X - 80) < 100 && Room != null)
            {
                Room = null;
                Player.Location = pointInWorld;
                return false;
            }
            return true;
        }
        
        public bool TalkWithHuman()
        {
            var humans = Room != null ? Room.Humans : World.Humans;
            foreach (var human in humans)
            {
                if (Math.Abs(human.Location.X - Player.Location.X) <= 90)
                    if (human.IsReady())
                    {
                        if (human.MissionId == 0)
                        {
                            FlagDecan = true;
                            World.Doors[1].State = Door.DoorState.Open;
                            human.State = Human.HumanState.Awaiting;
                        }
                        return false;
                    }
            }
            return true;
        }
        public void GiveItem()
        {
            var item = Inventory.Items.Keys.FirstOrDefault();
            foreach (var human in Room.Humans)
            {
                if (Math.Abs(human.Location.X - Player.Location.X) <= 10)
                    if (human.State == Human.HumanState.Awaiting && human.IsCorrectItem(item))
                    {
                        human.RemoveBroughtItem(item);
                        if (human.ExpectedItems.Count == 0)
                            human.MakeNotReady();
                        Inventory.TakeItem(item);
                    }
            }
        }

        public void PlayerMoveRight()
        {
            var borders = Room == null ? World.AvailableX : Room.AvailableX;
            if (Player.Location.X + 1 < borders[1])
            {
                if (!Player.IsRight)
                {
                    Player.Sprite.RotateFlip(RotateFlipType.Rotate180FlipY);
                    Player.IsRight = true;
                }
                Player.Location.X += 60;
                Player.IsRight = true;
            }
            else if (Room == null && World.Location.X > -5760)
            {
                if (World.Location.X > -6000)
                {
                    World.Location.X -= 60f;
                    for (var i = 0; i < 2; i++)
                    {
                        World.Doors[i].Location.X -= 60;
                    }
                }
            }
        }
        
        public void PlayerMoveLeft()
        {
            var borders = Room == null ? World.AvailableX : Room.AvailableX;
            if (Player.Location.X + 1 > borders[0])
            {
                if (Player.IsRight)
                {
                    Player.Sprite.RotateFlip(RotateFlipType.Rotate180FlipY);
                    Player.IsRight = false;
                }
                Player.Location.X -= 60f;
            }
            else if (Room == null && World.Location.X < 0)
            {
                if (World.Location.X < 0)
                {
                    World.Location.X += 60f;
                    for (var i = 0; i < 2; i++)
                    {
                        World.Doors[i].Location.X += 60;
                    }
                }
            }
        }
    }
}