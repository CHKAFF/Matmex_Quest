using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MATMEH_QUEST.Properties;

namespace MATMEH_QUEST
{
    public partial class Form1 : Form
    {
        private bool isMenu;
        private bool isRoom;
        public Form1()
        {
            isMenu = true;
            isRoom = false;
        }

        protected Button MakeNewButton(string text, Size size, Point location, Font font, FlatStyle flatStyle,
            Color foreColor, int borderSize, Color borderColor)
        {
            var button = new Button()
            {
                Text = text,
                Location = location,
                Size = size,
                Font = font,
                FlatStyle = flatStyle
            };
            button.ForeColor = foreColor;
            button.FlatAppearance.BorderSize = borderSize;
            button.FlatAppearance.BorderColor = borderColor;
            return button;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            if (isMenu)
                PaintMenu(graphics);
            else if (isRoom)
                PaintRoom(graphics);
            else
                PaintWorld(graphics);
        }

        private void PaintRoom(Graphics graphics)
        {
        }

        private void PaintWorld(Graphics graphics)
        {
            Controls.Clear();
            BackColor = Color.Empty;

            var pictureBox = new PictureBox();
            var background = new Bitmap(Resources.Bottom_part, base.Width, base.Height);
            graphics.DrawImage(background, new Point(0, 0));
        }

        private void PaintMenu(Graphics graphics)
        {
            var backgroundColor = Color.FromArgb(145, 215, 254);
            BackColor = backgroundColor;
            var logoSize = base.Width / 4;
            var logotype = new Bitmap(Resources.фон, base.Width , base.Width );
            graphics.DrawImage(logotype, new Point(90, 0));

            //PrivateFontCollection fontCollection = new PrivateFontCollection();
            //fontCollection.AddFontFile("Arial");
            //FontFamily family = fontCollection.Families[0];

            var newGame = MakeNewButton("НОВАЯ ИГРА",
                new Size(100, 50),
                new Point(100, 100),
                new Font("Arial", 20),
                FlatStyle.Flat,
                Color.FromArgb(1, 127, 189),
                0,
                backgroundColor);
            Controls.Add(newGame);

            var exit = MakeNewButton("ВЫХОД",
                new Size(100, 50),
                new Point(100, 150),
                new Font("Arial", 20),
                FlatStyle.Flat,
                Color.FromArgb(1, 127, 189),
                0,
                backgroundColor);
            Controls.Add(exit);

            newGame.Click += NewGameOnClick;
            exit.Click += ExitOnClick;
        }

        private void ExitOnClick(object sender, EventArgs e)
        {
            base.Close();
        }

        private void NewGameOnClick(object sender, EventArgs e)
        {
            isMenu = false;
            base.Refresh();
        }
    }
}
