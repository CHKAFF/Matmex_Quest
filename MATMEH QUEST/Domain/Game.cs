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
        public Room room;
        private Point pointInWorld;
        public Game()
        {
            
        }

        public void New()
        {
            this.World = new World();
            Player = new Player(new Point(10,10),100);
            Inventory = new Inventory();
            room = null;
        }

        public void EnterInRoom()
        {
            foreach (var door in World.Doors)
            {
                if (Math.Abs(door.Value.Location.X - Player.Location.X) <= 10)
                    if (door.Value.IsOpen())
                    {
                        room = door.Value.Room;
                        pointInWorld = Player.Location;
                        Player.Location = new Point(0,10);
                        break;
                    }
            }
        }

        public void LeaveFromRoom()
        {
            if (room != null)
            {
                room = null;
                Player.Location = pointInWorld;
            }
        }
        
        public void TalkWithHuman()
        {
            var humans = room != null ? room.Humans : World.Humans;
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
            foreach (var human in room.Humans)
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
    }
}