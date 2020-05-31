using System.Drawing;
using MATMEH_QUEST.Properties;

namespace MATMEH_QUEST.Domain
{
    public class Player 
    {
        public PointF Location;
        public Bitmap Sprite = Resources.Player;
        public bool IsRight = true;
        public Player(PointF location)
        {
            Location = location;
        }
    }
}