using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MATMEH_QUEST.Domain;
using MATMEH_QUEST.Properties;

namespace MATMEH_QUEST
{
    public partial class Form1 : Form
    {
        private bool isMenu;
        private Controller controller;
        public Form1()
        {
            Timer timer = new Timer();
            timer.Interval = 1000 / 60;
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
            isMenu = true;
            MinimumSize = new Size(1200, 800);
            controller = new Controller(Size.Width);
            DoubleBuffered = true;
        }

        private void TimerTick(object sender, EventArgs args)
        {
            
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
            controller.Game.World.AvailableX[1] = Size.Width - 200;
            KeyDown += (sender, args) =>
            {
                controller.Action(args);
            };
            var graphics = e.Graphics;
            if (isMenu)
                PaintMenu();
            else
            {
                if (controller.Game.Room == null) PaintWorld(graphics); 
                else PaintRoom(graphics);
                
                var inventory = new Bitmap(Resources.Inventory);
                graphics.DrawImage(inventory, new Point(Size.Width / 2 - inventory.Width / 2, Size.Height/2 + 290));
            }
        }

        private void PaintRoom(Graphics graphics)
        {
            BackgroundImage = controller.Game.Room.Background;
            BackgroundImageLayout = ImageLayout.Stretch;
            PaintPlayer(graphics);
        }

        private void PaintWorld(Graphics graphics)
        {
            BackgroundImage = new Bitmap(Resources.CORRIDOR);
            graphics.DrawImage(BackgroundImage, controller.Game.World.Location);

            var doorOne = MakeNewButton(
                "Door",
                new Size(100, 100),
                new Point(6100, 200),
                new Font("Arial", 20),
                FlatStyle.Flat,
                Color.Black,
                20,
                Color.Blue);

            
            PaintPlayer(graphics);
        }

        private void PaintMenu()
        {
            var backgroundColor = Color.FromArgb(145, 215, 254);
            BackColor = backgroundColor;

            //PrivateFontCollection fontCollection = new PrivateFontCollection();
            //fontCollection.AddFontFile("Arial");
            //FontFamily family = fontCollection.Families[0];

            var table = new TableLayoutPanel();
            table.RowStyles.Clear();
            table.ColumnStyles.Clear();
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            var pictureBox = new PictureBox();
            pictureBox.Image = new Bitmap(Resources.фон);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Dock = DockStyle.Fill;
            

            var newGame = MakeNewButton("НОВАЯ ИГРА",
                new Size(50, 25),
                new Point(100, 100),
                new Font("Arial", 20),
                FlatStyle.Flat,
                Color.FromArgb(1, 127, 189),
                0,
                backgroundColor);
            newGame.Dock = DockStyle.Fill;
            

            var exit = MakeNewButton("ВЫХОД",
                new Size(100, 50),
                new Point(50, 25),
                new Font("Arial", 20),
                FlatStyle.Flat,
                Color.FromArgb(1, 127, 189),
                0,
                backgroundColor);
            exit.Dock = DockStyle.Fill;

            table.Controls.Add(pictureBox, 0, 0);
            table.Controls.Add(newGame,0,1);
            table.Controls.Add(exit,0,2);
         
            table.Dock = DockStyle.Fill;

            Controls.Add(table);
            
            newGame.Click += NewGameOnClick;
            exit.Click += ExitOnClick;
            
        }

        private void PaintPlayer(Graphics graphics)
        {
            var playerImage = new Bitmap(controller.Game.Player.Sprite, new Size(100,300));
            graphics.DrawImage(playerImage, new PointF(controller.Game.Player.Location.X, controller.Game.Player.Location.Y));
        }

        private void ExitOnClick(object sender, EventArgs e)
        {
            Close();
        }

        private void NewGameOnClick(object sender, EventArgs e)
        {
            isMenu = false;
            Controls.Clear();
            BackColor = Color.Empty;
            Invalidate();
        }
    }
}
