using System.Drawing;

namespace MATMEH_QUEST.Domain
{
    public class Player 
    {
        public PointF Location;
        public int Height = 100;
        public int Width = 200;
        
        public Player(PointF location)
        {
            Location = location;
        }
    }
}