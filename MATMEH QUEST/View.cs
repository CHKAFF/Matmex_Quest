using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using System.Xml.Schema;
using MATMEH_QUEST.Domain;
using MATMEH_QUEST.Properties;

namespace MATMEH_QUEST
{
    public partial class Form1 : Form
    {
        private bool isMusicOff;
        private bool isMainMenu;
        private bool isTutorial1;
        private bool isTutorial2;
        private bool isMenu;
        private SoundPlayer music;
        private Controller Controller;
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            isMusicOff = true;
            isMainMenu = true;
            isTutorial1 = true;
            isTutorial2 = true;
            isMenu = false;
            WindowState = FormWindowState.Maximized;
            Controller = new Controller(Size.Width);
            DoubleBuffered = true;
            KeyDown += (sender, args) =>
            {
                Controller.Action(args);
            };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            if (isMainMenu)
                PaintMainMenu();
            else if (isTutorial1)
            {
                PaintTrain(graphics, Resources.Обучение_1, 250, 1050, NextOnClick);
            }
            else if (isTutorial2)
            {
                PaintTrain(graphics, Resources.Обучение_2, 430, 870,  OverButtonOnClick);
            }
            else
            {
                var menuButton = new PictureBox()
                {
                    Image = Resources.меню,
                    BackColor = Color.Transparent,
                    SizeMode = PictureBoxSizeMode.Zoom
                };
                menuButton.Click += MenuButtonOnClick;
                Controls.Add(menuButton);
                menuButton.Update();
                if (isMenu)
                {
                    PaintMenu(graphics);
                }
                if (Controller.Game.Room == null)
                {
                    Controller.Game.CurrentAction = CurrentAction.EnterInRoom;
                    PaintWorld(graphics);
                    if (Controller.Game.World.Location.X > -5600)
                    {
                        PaintMission(graphics, new Bitmap(Resources.задание_1, new Size(290, 120)),  0);
                    }
                    else
                    {
                        PaintMission(graphics, new Bitmap(Resources.задание_2, new Size(290, 120)), 0);
                    }
                }
                else if(Controller.Game.Room != null)
                {
                    Controller.Game.CurrentAction = CurrentAction.LeaveRoom;
                    PaintRoom(graphics);
                    PaintMission(graphics, new Bitmap(Resources.задание_3, new Size(290, 100)), 10);
                }
                var inventory = new Bitmap(Resources.Inventory);
                graphics.DrawImage(inventory, new Point(Size.Width / 2 - inventory.Width / 2, Size.Height/2 + 290));
                
            }
        }

        private void MenuButtonOnClick(object sender, EventArgs e)
        {
            isMenu = true;
        }

        private void PaintMenu(Graphics graphics)
        {
            BackgroundImage = Resources.меню;
        }

        private void PaintMission(Graphics graphics, Bitmap missionTable, int dy)
        {
            graphics.DrawImage(missionTable,
                new Point(Size.Width / 2 - missionTable.Width / 2, Top + dy));
        }

        private void PaintRoom(Graphics graphics)
        {
            Controller.Game.Room.AvailableX[1] = Size.Width - 200;
            BackgroundImage = Controller.Game.Room.Background;
            BackgroundImageLayout = ImageLayout.Stretch;
            Invalidate();
            PaintPlayer(graphics);
        }

        private void PaintWorld(Graphics graphics)
        {
            Controller.Game.World.AvailableX[1] = Size.Width - 200;
            BackgroundImage = new Bitmap(Resources.Corridor);
            BackgroundImageLayout = ImageLayout.Stretch;
            graphics.DrawImage(BackgroundImage, Controller.Game.World.Location);
            Invalidate();
            PaintPlayer(graphics);
        }

        private void PaintPlayer(Graphics graphics)
        {
            var playerImage = new Bitmap(Controller.Game.Player.Sprite, new Size(100,300));
            graphics.DrawImage(playerImage, new PointF(Controller.Game.Player.Location.X, Controller.Game.Player.Location.Y));
            Invalidate();
        }

        private void PaintTrain(Graphics graphics, Bitmap image, int width, int x, EventHandler eventAction)
        {
            BackColor = Color.SandyBrown;
            BackgroundImage = image;
            BackgroundImageLayout = ImageLayout.Zoom;
            var button = new Button
            {
                BackColor = Color.Transparent,
                Size = new Size(width, 90),
                Location = new Point(x, 555),
                FlatStyle = FlatStyle.Popup,
                FlatAppearance =
                {
                    BorderSize = 0
                }
            };
            Controls.Add(button);
            DrawButton(graphics, button);
            button.Update();
            button.Click += eventAction;
        }

        private void PaintMainMenu()
        {
            var backgroundColor = Color.FromArgb(145, 215, 254);
            BackColor = backgroundColor;
            var table = new TableLayoutPanel();
            table.RowStyles.Clear();
            table.ColumnStyles.Clear();
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));

            var logotype = new PictureBox
            {
                Image = Resources.Логотип, 
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill
            };

            var musicText = new Button
            {
                BackgroundImage = Resources.Музыка,
                BackgroundImageLayout = ImageLayout.Zoom,
                Size = new Size(150, 100),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance =
                {
                    CheckedBackColor = Color.Transparent,
                    MouseDownBackColor = Color.Transparent,
                    MouseOverBackColor = Color.Transparent,
                    BorderSize = 0
                },
                Dock = DockStyle.Top
            };

            var musicButton = new Button
            {
                BackgroundImage = Resources.Music_off,
                BackgroundImageLayout = ImageLayout.Zoom,
                Size = new Size(150, 100),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance =
                {
                    CheckedBackColor = Color.Transparent,
                    MouseDownBackColor = Color.Transparent,
                    MouseOverBackColor = Color.Transparent,
                    BorderSize = 0
                },
                Dock = DockStyle.Top,
            };

            var newGame = new Button
            {
                BackgroundImage = Resources.Новая_игра,
                BackgroundImageLayout = ImageLayout.Zoom,
                FlatStyle = FlatStyle.Flat,
            };
            newGame.FlatAppearance.BorderSize = 0;
            newGame.Dock = DockStyle.Fill;

            var exit = new Button
            {
                BackgroundImage = Resources.Выход,
                BackgroundImageLayout = ImageLayout.Zoom,
                FlatStyle = FlatStyle.Flat
            };
            exit.FlatAppearance.BorderSize = 0;
            exit.Dock = DockStyle.Fill;

            table.Controls.Add(musicButton, 0, 0);
            table.Controls.Add(musicText, 1, 0);
            table.Controls.Add(logotype, 2, 0);
            table.Controls.Add(newGame,2,1);
            table.Controls.Add(exit,2,2);
            table.Controls.Add(new Control(), 3, 0);
            table.Dock = DockStyle.Fill;
            Controls.Add(table);
            table.Update();

            musicButton.Click += MusicOnClick;
            newGame.Click += NewGameOnClick;
            exit.Click += ExitOnClick;
        }

        private void MusicOnClick(object sender, EventArgs e)
        {
            isMusicOff = !isMusicOff;
            if (!isMusicOff)
            {
                ((Button) sender).BackgroundImage = Resources.Music_on;
                music.Play(); 
            }
            else
            {
                ((Button) sender).BackgroundImage = Resources.Music_off;
                music.Stop();
            }
            Invalidate();
        }

        private void ExitOnClick(object sender, EventArgs e)
        {
            Close();
        }

        private void NewGameOnClick(object sender, EventArgs e)
        {
            isMainMenu = false;
            Controls.Clear();
            Invalidate();
        }

        private void NextOnClick(object sender, EventArgs e)
        {
            isTutorial1 = false;
            Controls.Clear();
            Invalidate();
        }

        private void OverButtonOnClick(object sender, EventArgs e)
        {
            isTutorial2 = false;
            Controls.Clear();
            Invalidate();
        }

        private void DrawButton(Graphics graphics, Button button)
        {
            ControlPaint.DrawBorder(graphics, new Rectangle(button.Location, button.Size), 
                SystemColors.ControlLight, 5, ButtonBorderStyle.Outset,
                SystemColors.ControlLight, 5, ButtonBorderStyle.Outset,
                SystemColors.ControlLight, 5, ButtonBorderStyle.Outset,
                SystemColors.ControlLight, 5, ButtonBorderStyle.Outset);
        }
    }
}
