﻿using System.Drawing;

namespace MATMEH_QUEST.Domain
{
    public class Item
    {
        public int MissionID;
        public int ObjectID;
        public Point Location { get; set; }
        public int Height { get;}
        public int Width { get; }
        public Item(int missionId, int objectId, Point location)
        {
            Location = location;
            MissionID = missionId;
            ObjectID = objectId;
        }
    }
}