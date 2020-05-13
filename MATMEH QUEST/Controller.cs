using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using MATMEH_QUEST.Domain;
using MATMEH_QUEST.Properties;

namespace MATMEH_QUEST
{
    public class Controller
    {
        public Game Game;
        public Controller(int formWidth)
        {
            Game = new Game();
            Game.New();
        }

        public void Action(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.Left:
                    Game.PlayerMoveLeft();
                    break;
                case Keys.D:
                case Keys.Right:
                    Game.PlayerMoveRight();
                    break;
                case Keys.E:
                    Game.EnterInRoom();
                    break;
                case Keys.Escape:
                    if (Game.Room != null) Game.LeaveFromRoom();
                    break;
            }
        }

        public void NewMission()
        {
            Game.MissionSprite = new Bitmap(Resources.задание_1);
        }
    }
}