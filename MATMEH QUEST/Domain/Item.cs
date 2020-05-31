using System.Drawing;

namespace MATMEH_QUEST.Domain
{
    public class Item
    {
        public int MissionId;
        public int ObjectId;
        public Point Location { get; set; }
        public Item(int missionId, int objectId, Point location)
        {
            Location = location;
            MissionId = missionId;
            ObjectId = objectId;
        }
    }
}