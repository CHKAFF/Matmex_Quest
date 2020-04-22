namespace MATMEH_QUEST.Domain
{
    public class Item
    {
        public int MissionID;
        public int ObjectID;

        public Item(int missionId, int objectId)
        {
            MissionID = missionId;
            ObjectID = objectId;
        }
    }
}