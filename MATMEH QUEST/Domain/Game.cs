﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Linq;
using System.Linq;

namespace MATMEH_QUEST.Domain
{
    public class Game
    {
        public World World;
        public Player Player;
        public Inventory Inventory;
        public Room room;
        public Game()
        {
            
        }

        public void New()
        {
            this.World = new World();
            Player = new Player(new Point(0,0),100);
            Inventory = new Inventory();
            room = null;
        }

        public void EnterInRoom()
        {
            foreach (var door in World.Doors)
            {
                if (Math.Abs(door.Value.Location.X - Player.Location.X) <= 10)
                    if (door.Value.IsOpen())
                        room = door.Value.Room;
            }
        }

        public void LeaveFromRoom()
        {
            room = null;
        }
    }
}