using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Linq;
using System.Linq;
using System.Windows.Forms;
using MATMEH_QUEST.Properties;

namespace MATMEH_QUEST.Domain
{
    public class Game
    {
        public World World;
        public Player Player;
        public Inventory Inventory;
        public Room Room;
        private PointF pointInWorld;
        public Bitmap MissionSprite;

        public void New()
        {
            this.World = new World();
            Player = new Player(new PointF(50,300));
            Inventory = new Inventory();
            Room = null;
        }

        public void EnterInRoom()
        {
            foreach (var door in World.Doors)
            {
                if (Math.Abs(door.Value.Location.X - Player.Location.X) <= 200)
                    if (door.Value.IsOpen())
                    {
                        Room = door.Value.Room;
                        pointInWorld = Player.Location;
                        Player.Location.X = 50;
                        Player.Location.Y = 350;
                        MissionSprite = new Bitmap();
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
            var borders = Room == null ? World.AvailableX : Room.AvailableX;
            if (Player.Location.X + 1 < borders[1])
            {
                if (!Player.isRight)
                {
                    Player.Sprite.RotateFlip(RotateFlipType.Rotate180FlipY);
                    Player.isRight = true;
                }
                Player.Location.X += 1f;
                Player.isRight = true;
            }
            else if (Room == null)
            {
                if (World.Location.X > -6000)
                {
                    World.Location.X -= 1f;
                    for (var i = 1; i < 11; i++)
                    {
                        World.Doors[i].Location.X -= 1;
                    }
                }
            }
        }
        
        public void PlayerMoveLeft()
        {
            var borders = Room == null ? World.AvailableX : Room.AvailableX;
            if (Player.Location.X + 1 > borders[0])
            {
                if (Player.isRight)
                {
                    Player.Sprite.RotateFlip(RotateFlipType.Rotate180FlipY);
                    Player.isRight = false;
                }
                Player.Location.X -= 1f;
            }
            else if (Room == null)
            {
                if (World.Location.X < 0)
                {
                    World.Location.X += 1f;
                    for (var i = 1; i < 11; i++)
                    {
                        World.Doors[i].Location.X += 1;
                    }
                }
            }
        }
    }
}