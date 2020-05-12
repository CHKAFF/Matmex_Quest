using System;
using System.Collections.Generic;
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
            if (e.KeyCode == Keys.A)
            {
                Game.PlayerMoveLeft();
            }

            if (e.KeyCode == Keys.D)
            {
                Game.PlayerMoveRight();
            }
        }
    }
}