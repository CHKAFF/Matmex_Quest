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
        private bool isDialog1;
        private bool isDialog2;
        private bool isDialog3;
        private bool isDialog4;
        private bool missionItem;
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
            isDialog1 = true;
            isDialog2 = true;
            isDialog3 = true;
            isDialog4 = true;
            isDialog4 = false;
            music = new SoundPlayer(Resources._8_bit_Dendy___Smooth_Criminal__musicpro_me_);
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
            else if (isMenu)
            {
                PaintMenu(graphics);
            }
            else if (Controller.Game.FlagDecan)
            {
                if(isDialog1)
                    PaintDialogWithD(graphics, Resources.Деканат_диалог1, 190, 880, Dialog1OnClick);
                else if(isDialog2)
                    PaintDialogWithD(graphics, Resources.Деканат_диалог2, 190, 880, Dialog2OnClick);
                else if (isDialog3)
                    PaintDialogWithD(graphics, Resources.Деканат_диалог3, 190, 880, Dialog3OnClick);
                else if (isDialog4)
                    PaintDialogWithD(graphics, Resources.Деканат_диалог4, 190, 880, Dialog4OnClick);
            }
            else
            {
                var menuButton = new PictureBox()
                {
                    Image = Resources.меню,
                    BackColor = Color.Transparent,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Location =  new Point(20, 0)
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
                    PaintRoom(graphics);
                    if (missionItem)
                    {
                        var a = new PictureBox();
                        a.Image = Resources.задание_1;
                    }
                    PaintMission(graphics, new Bitmap(Resources.задание_3, new Size(290, 120)), 0);
                }
                var inventory = new Bitmap(Resources.Inventory);
                graphics.DrawImage(inventory, new Point(Size.Width / 2 - inventory.Width / 2, Size.Height/2 + 290));
                
            }
        }

        private void PaintDialogWithD(Graphics graphics, Bitmap image, int  width, int x, EventHandler eventAction)
        {
            BackgroundImage = image;
            BackgroundImageLayout = ImageLayout.Stretch;
            var button = new Button
            {
                BackColor = Color.Transparent,
                Size = new Size(width, 65),
                Location = new Point(x, 655),
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

        private void MenuButtonOnClick(object sender, EventArgs e)
        {
            Controls.Clear();
            isMenu = true;
            Invalidate();
        }

        private void PaintMenu(Graphics graphics)
        {
            var backgroundColor = Color.FromArgb(145, 215, 254);
            BackColor = backgroundColor;
            var table = new TableLayoutPanel();
            table.RowStyles.Clear();
            table.ColumnStyles.Clear();
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 40));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, 35));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30));
            table.BackgroundImage = Resources.Всплывающее_меню;
            table.BackgroundImageLayout = ImageLayout.Zoom;

            var returnButton = new Button
            {
                BackgroundImage = Resources.Вернуться_кнопка,
                BackgroundImageLayout = ImageLayout.Zoom,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(3, 153, 228)
            };
            returnButton.FlatAppearance.BorderSize = 0;
            returnButton.Dock = DockStyle.Fill;

            var exit = new Button
            {
                BackgroundImage = Resources.Выход_кнопка,
                BackgroundImageLayout = ImageLayout.Zoom,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(3, 153, 228)
            };
            exit.FlatAppearance.BorderSize = 0;
            exit.Dock = DockStyle.Fill;

            table.Controls.Add(new Control(), 0, 0);
            table.Controls.Add(returnButton, 1, 1);
            table.Controls.Add(exit, 1, 2);
            table.Controls.Add(new Control(), 1, 3);
            table.Controls.Add(new Control(), 2, 0);
       
            table.Dock = DockStyle.Fill;
            Controls.Add(table);
            table.Update();

            returnButton.Click += ReturnButtonOnClick;
            exit.Click += ExitOnClick;
        }

        private void ReturnButtonOnClick(object sender, EventArgs e)
        {
            isMenu = false;
            Controls.Clear();
            Invalidate();
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
            PaintPlayer(graphics);
            Invalidate();
        }

        private void PaintWorld(Graphics graphics)
        {
            Controller.Game.World.AvailableX[1] = Size.Width - 200;
            BackgroundImage = new Bitmap(Resources.Corridor);
            BackgroundImageLayout = ImageLayout.Stretch;
            graphics.DrawImage(BackgroundImage, Controller.Game.World.Location);
            PaintPlayer(graphics);
            Invalidate();
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

        private void Dialog1OnClick(object sender, EventArgs e)
        {
            Controls.Clear();
            isDialog1 = false;
            Invalidate();
        }

        private void Dialog2OnClick(object sender, EventArgs e)
        {
            Controls.Clear();
            isDialog2 = false;
            Invalidate();
        }

        private void Dialog3OnClick(object sender, EventArgs e)
        {
            Controls.Clear();
            isDialog3 = false;
            Invalidate();
        }

        private void Dialog4OnClick(object sender, EventArgs e)
        {
            missionItem = true;
            Controls.Clear();
            isDialog4 = false;
            Controller.Game.FlagDecan = false;
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
