using System.Drawing;

namespace MATMEH_QUEST.Domain
{
    public class Player 
    {
        public Point Location;
        public int Height = 100;
        public int Width = 200;
        
        public Player(Point location)
        {
            this.Location = location;
        }
    }
}