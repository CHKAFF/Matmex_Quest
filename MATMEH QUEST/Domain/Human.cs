using System.Collections.Generic;
using System.Drawing;

namespace MATMEH_QUEST.Domain
{
    public class Human
    {
        public Point Location;
        public int Height = 100;
        public int Width = 200;
        public int MissionID;
        
        public enum HumanState
        {
            Ready,
            Awaiting,
            NotReady
        }

        public HumanState State;
        public List<Item> expectedItems;

        public Human(HumanState state, List<Item> expectedItems) 
        {
            this.State = state;
            this.expectedItems = expectedItems;
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
            return (State == HumanState.Awaiting && item.MissionID == MissionID) ? true : false;
        }

        public void RemoveBroughtItem(Item item)
        {
            if (IsCorrectItem(item))
                expectedItems.Remove(item);
        }
    }
}