using System.Drawing;
using MATMEH_QUEST.Properties;

namespace MATMEH_QUEST.Domain
{
    public class Player 
    {
        public PointF Location;
        public int Height = 100;
        public int Width = 200;
        public System.Drawing.Bitmap Sprite = Resources.Player;
        public bool isRight = true;
        public Player(PointF location)
        {
            Location = location;
        }
    }
}