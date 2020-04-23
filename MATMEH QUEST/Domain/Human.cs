using System.Collections.Generic;

namespace MATMEH_QUEST.Domain
{
    public class Human
    {
        public int MissionID;
        public enum HumanState
        {
            Ready,
            Awaiting,
            NotReady
        }

        private HumanState state;
        private List<int> expectedItems;

        public Human(HumanState state, List<int> expectedItems) 
        {
            this.state = state;
            this.expectedItems = expectedItems;
        }

        public bool IsReady()
        {
            return state == HumanState.Ready;
        }

        public void MakeReady()
        {
            state = HumanState.Ready;
        }

        public void MakeNotReady()
        {
            state = HumanState.NotReady;
        }

        public void MakeAwaiting()
        {
            state = HumanState.Awaiting;
        }
        
        public bool IsCorrectItem(Item item)
        {
            return (state == HumanState.Awaiting && item.MissionID == MissionID) ? true : false;
        }

        public void RemoveBroughtItem(Item item)
        {
            if (IsCorrectItem(item))
                expectedItems.Remove(item.ObjectID);
        }
    }
}