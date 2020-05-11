using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MATMEH_QUEST.Domain;

namespace MATMEH_QUEST
{
    public class Controller
    {
        private Game game;
        public Controller()
        {
            game = new Game();
        }
        public void Action(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                game.PlayerMoveLeft();
            }

            if (e.KeyCode == Keys.D)
            {
                game.PlayerMoveLeft();
            }
        }
    }
}