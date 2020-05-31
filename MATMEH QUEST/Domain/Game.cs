﻿using System;
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

        public void New()
        {
            World = new World();
            Player = new Player(new PointF(50,300));
            Inventory = new Inventory();
            Room = null;
            CurrentAction = CurrentAction.EnterInRoom;
        }

        public void EnterInRoom()
        {
            foreach (var door in World.Doors)
            {
                if (door.Value.IsOpen())
                {
                    Room = door.Value.Room;
                    pointInWorld = Player.Location;
                    Player.Location.X = 50;
                    Player.Location.Y = 350;
                    break;
                }
            }
        }

        public void LeaveFromRoom()
        {
            if(Room != null)
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
                        World.Doors[human.MissionId].State = Door.DoorState.Open;
                        human.State = Human.HumanState.Awaiting;
                    }
            }
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
<<<<<<< HEAD
                Player.Location.X += 20;
=======
                Player.Location.X += 60f;
>>>>>>> 9548e6086c5bbc648cd8f253066f7d35524f7804
                Player.IsRight = true;
            }
            else if (Room == null && World.Location.X > -5760)
            {
<<<<<<< HEAD
                if (World.Location.X > -6000)
                {
                    World.Location.X -= 20f;
                    for (var i = 1; i < 11; i++)
                    {
                        World.Doors[i].Location.X -= 20;
                    }
                }
=======
                World.Location.X -= 60f;
>>>>>>> 9548e6086c5bbc648cd8f253066f7d35524f7804
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
<<<<<<< HEAD
                Player.Location.X -= 20;
=======
                Player.Location.X -= 60f;
>>>>>>> 9548e6086c5bbc648cd8f253066f7d35524f7804
            }
            else if (Room == null && World.Location.X < 0)
            {
<<<<<<< HEAD
                if (World.Location.X < 0)
                {
                    World.Location.X += 20;
                    for (var i = 1; i < 11; i++)
                    {
                        World.Doors[i].Location.X += 20;
                    }
                }
=======
                World.Location.X += 60f;
>>>>>>> 9548e6086c5bbc648cd8f253066f7d35524f7804
            }
        }
    }
}