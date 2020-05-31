using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using MATMEH_QUEST.Domain;

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
                {

                    if (Game.CurrentAction == CurrentAction.EnterInRoom)
                        Game.EnterInRoom();
                    if (Game.CurrentAction == CurrentAction.LeaveRoom)
                        Game.LeaveFromRoom();
                    if (Game.CurrentAction == CurrentAction.GiveItem)
                        Game.GiveItem();
                    if (Game.CurrentAction == CurrentAction.TalkWithHuman)
                        Game.TalkWithHuman();
                    break;

                }
                        
            }
        }
    }
}