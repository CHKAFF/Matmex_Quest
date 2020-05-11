using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Linq;
using System.Linq;
using System.Windows.Forms;

namespace MATMEH_QUEST.Domain
{
    public class Game
    {
        public World World;
        public Player Player;
        public Inventory Inventory;
        public Room Room;
        private PointF pointInWorld;

        public void New()
        {
            this.World = new World();
            Player = new Player(new Point(10,10));
            Inventory = new Inventory();
            Room = null;
        }

        public void EnterInRoom()
        {
            foreach (var door in World.Doors)
            {
                if (Math.Abs(door.Value.Location.X - Player.Location.X) <= 10)
                    if (door.Value.IsOpen())
                    {
                        Room = door.Value.Room;
                        pointInWorld = Player.Location;
                        Player.Location = new Point(0,10);
                        break;
                    }
            }
        }

        public void LeaveFromRoom()
        {
            if (Room != null)
            {
                Room = null;
                Player.Location = pointInWorld;
            }
        }
        
        public void TalkWithHuman()
        {
            var humans = Room != null ? Room.Humans : World.Humans;
            foreach (var human in humans)
            {
                if (Math.Abs(human.Location.X - Player.Location.X) <= 10)
                    if (human.IsReady())
                    {
                        World.Doors[human.MissionID].State = Door.DoorState.Open;
                        human.State = Human.HumanState.Awaiting;
                    }
            }
        }

        public void GiveItem(Item item)
        {
            foreach (var human in Room.Humans)
            {
                if (Math.Abs(human.Location.X - Player.Location.X) <= 10)
                    if (human.State == Human.HumanState.Awaiting)
                    {
                        if (human.IsCorrectItem(item))
                        {
                            human.RemoveBroughtItem(item);
                            if (human.expectedItems.Count == 0)
                                human.MakeNotReady();
                            Inventory.TakeItem(item);
                        }
                    }
            }
        }

        public void PlayerMoveRight()
        {
            var borders = Room == null ? World.availableX : Room.availableX;
            if (Player.Location.X + 1 < borders[1]) 
                Player.Location.X += 1;
        }
        
        public void PlayerMoveLeft()
        {
            var borders = Room == null ? World.availableX : Room.availableX;
            if (Player.Location.X + 1 > borders[0]) 
                Player.Location.X -= 1;
        }
    }
}