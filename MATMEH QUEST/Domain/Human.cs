using System.Collections.Generic;
using System.Drawing;

namespace MATMEH_QUEST.Domain
{
    public class Human
    {
        public Point Location;
        public int MissionId;
        
        public enum HumanState
        {
            Ready,
            Awaiting,
            NotReady
        }

        public HumanState State;
        public List<Item> ExpectedItems;

        public Human(HumanState state, int missionId, Point location, List<Item> expectedItems)
        {
            Location = location;
            MissionId = missionId;
            State = state;
            ExpectedItems = expectedItems;
        }

        public bool IsReady()
        {
            return State == HumanState.Ready;
        }

        public void MakeReady()
        {
            State = HumanState.Ready;
        }

        public void MakeNotReady()
        {
            State = HumanState.NotReady;
        }

        public void MakeAwaiting()
        {
            State = HumanState.Awaiting;
        }
        
        public bool IsCorrectItem(Item item)
        {
            return (State == HumanState.Awaiting && item.MissionId == MissionId);
        }

        public void RemoveBroughtItem(Item item)
        {
            if (IsCorrectItem(item))
                ExpectedItems.Remove(item);
        }
    }
}