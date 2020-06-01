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
        private bool isMusicOn;
        private bool isMainMenu;
        private bool isTutorial1;
        private bool isTutorial2;
        private bool isTutorial3;
        private bool isMenu;
        private bool isDialog1;
        private bool isDialog2;
        private bool isDialog3;
        private bool isDialog4;
        private bool isDialogM1;
        private bool isDialogM2;
        private bool isDialogM3;
        private bool isDialogM4;
        private bool isDialogM5;
        private bool isDemo;
        private bool missionItem;
        private bool missionItem1;
        private bool flagM;
        private bool tk;
        private double proportion;
        private SoundPlayer music;
        private Controller Controller;
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            isMusicOn = true;
            isMainMenu = true;
            isTutorial1 = true;
            isTutorial2 = true;
            isTutorial3 = true;
            isMenu = false;
            isDialog1 = true;
            isDialog2 = true;
            isDialog3 = true;
            isDialog4 = true;
            isDialogM1 = true;
            isDialogM2 = true;
            isDialogM3 = true;
            isDialogM4 = true;
            isDialogM5 = true;
            isDemo = false;
            missionItem = false;
            missionItem = false;
            flagM = true;
            tk = false;
            proportion = Width / Height;
            music = new SoundPlayer(Resources._8_bit_Dendy___Smooth_Criminal__musicpro_me_);
            music.Play();
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            Controller = new Controller(Size.Width);
            DoubleBuffered = true;
            KeyDown += (sender, args) =>
            {
                Controller.Action(args);
                Invalidate();
            };
            Resize += (sender, args) =>
            {
                Control control = (Control)sender;
                control.Width = control.Height * 2;
                Invalidate();
            };

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            GC.Collect();
            if (isDemo)
            {
                BackgroundImage = Resources.демоверсия;
            }
            else if (isMainMenu)
                PaintMainMenu();
            else if (isTutorial1)
            {
                PaintDialog(graphics, Resources.Обучение_1, 90, 15, 23,80, 23, 17, NextOnClick);
            }
            else if (isTutorial2)
            {
                PaintDialog(graphics, Resources.Обучение_2, 90, 15, 23, 80, 23, 17, NextOnClick);
            }
            else if (isTutorial3)
            {
                PaintDialog(graphics, Resources.Обучение_3, 90, 15, 23, 78, 42, 20, OverButtonOnClick);
            }
            else if (isMenu) 
            {
                PaintMenu(graphics);
            }
            else if (Controller.Game.FlagDecan)
            {
                if (isDialog1)
                    PaintDialog(graphics, Resources.Деканат_диалог1, 179, 20, 20, 118, 28, 62, Dialog1OnClick);
                else if (isDialog2)
                    PaintDialog(graphics, Resources.Деканат_диалог2, 179, 20, 20, 118, 28, 62, Dialog2OnClick);
                else if (isDialog3)
                    PaintDialog(graphics, Resources.Деканат_диалог3, 179, 20, 20, 118, 28, 62, Dialog3OnClick);
                else if (isDialog4)
                    PaintDialog(graphics, Resources.Деканат_диалог4, 179, 20, 20, 116, 48, 69, Dialog4OnClick);
            }
            else if (Controller.Game.FlagMatan)
            {
                if (isDialogM1)
                    PaintDialog(graphics, Resources._601_диалог1, 179, 20, 20, 118, 28, 62, DialogM1OnClick);
                else if (isDialogM2)
                    PaintDialog(graphics, Resources._601_диалог2, 179, 20, 20, 118, 28, 62, DialogM2OnClick);
                else if (isDialogM3)
                    PaintDialog(graphics, Resources._601_диалог3, 179, 20, 20, 118, 28, 62, DialogM3OnClick);
                else if (isDialogM4)
                    PaintDialog(graphics, Resources._601_диалог4, 179, 20, 20, 118, 28, 62, DialogM4OnClick);
                else if (isDialogM5)
                    PaintDialog(graphics, Resources._601_диалог5, 179, 20, 20, 116, 48, 69, DialogM5OnClick);
            }
            else
            {
                PaintMenuButton();
                GC.Collect();
                if (isMenu)
                {
                    PaintMenu(graphics);
                }
                if (Controller.Game.Room == null)
                {
                    PaintWorld(graphics);
                    if (flagM)
                    {
                        PaintMission(graphics,
                            Controller.Game.World.Location.X > -5600
                                ? new Bitmap(Resources.задание_1, new Size(290, 120))
                                : new Bitmap(Resources.задание_2, new Size(290, 120)), 0);
                    }
                }
                else if(Controller.Game.Room != null)
                {
                    PaintRoom(graphics);
                    if (missionItem)
                    {
                        var list = new PictureBox
                        {
                            Image = Resources.Свиток,
                            Location = new Point(500, 200),
                            SizeMode = PictureBoxSizeMode.Zoom,
                            BackColor = Color.Transparent
                        };
                        Controls.Add(list);
                        list.Update();
                        
                        list.Click += (sender, args) =>
                        { 
                            Controller.Game.Room.Background = Resources.Деканат_готово;
                            missionItem = false;
                            missionItem1 = true;
                            tk = true;
                            Controls.Clear();
                            Invalidate();
                        };
                    }
                    if (flagM)
                        PaintMission(graphics, new Bitmap(Resources.задание_3, new Size(290, 120)), 0);
                }
                if (missionItem1)
                {
                    var list = new PictureBox
                    {
                        Image = Resources.Свиток,
                        Location = new Point(565, 740),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        BackColor = Color.Transparent
                    };
                    Controls.Add(list);
                    list.Update();
                        
                    list.Click += (sender, args) =>
                    {
                        tk = true;
                        Controls.Clear();
                        Invalidate();
                    };
                }

                if (tk)
                {
                    var k = new PictureBox()
                    {
                        Image = Resources.crestik,
                        Location = new Point(990, 630),
                        Size = new Size(20, 20),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        BackColor = Color.DimGray
                    };
                    k.BringToFront();
                    Controls.Add(k);
                    k.Update();
                    k.Click += (sender, args) =>
                    {
                        tk = false;
                        Controls.Clear();
                        Invalidate();
                    };
                    var l = new PictureBox
                    {
                        Image = Resources.Табличка,
                        Location = new Point(1000, 650),
                        Size = new Size(250,200),
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        BackColor = Color.Transparent
                    };
                    Controls.Add(l);
                    l.Update();
                }
                var inventory = new Bitmap(Resources.Inventory);
                graphics.DrawImage(inventory, new Point(Size.Width / 2 - inventory.Width / 2, Size.Height/2 + 290));
                
            }
        }

        private void PaintDialogWithM(Graphics graphics, Bitmap image, int width, int x, EventHandler eventAction)
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

        private void PaintMenuButton()
        {
            var menuButton = new PictureBox()
            {
                Image = Resources.меню,
                BackColor = Color.Transparent,
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(20, 0)
            };
            menuButton.Click += MenuButtonOnClick;
            Controls.Add(menuButton);
            menuButton.Update();
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

        private void PaintDialog(Graphics graphics, Bitmap image, int p1, int p2, int p3, int c1, int c2, int c3, EventHandler eventAction)
        {
            var table = new TableLayoutPanel();
            table.RowStyles.Clear();
            table.ColumnStyles.Clear();
            table.RowStyles.Add(new RowStyle(SizeType.Percent, p1));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, p2));
            table.RowStyles.Add(new RowStyle(SizeType.Percent, p3));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, c1));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, c2));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, c3));
            table.BackColor = Color.SandyBrown;
            table.BackgroundImage = image;
            table.BackgroundImageLayout = ImageLayout.Stretch;

            var button = new Button
            {
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Popup,
                FlatAppearance =
                {
                    BorderSize = 0
                },
                AutoSizeMode = AutoSizeMode.GrowOnly
            };
            button.Dock = DockStyle.Fill;

            table.Controls.Add(new Control(), 0, 0);
            table.Controls.Add(button, 1, 1);
            table.Controls.Add(new Control(), 2, 2);

            table.Dock = DockStyle.Fill;
            Controls.Add(table);
            table.Update();

            DrawButton(graphics, button);
            button.Update();
            button.Click += eventAction;
        }

        private void PaintMainMenu()
        {
            var backgroundColor = Color.FromArgb(145, 215, 254);
            var table = new TableLayoutPanel();
            table.BackColor = backgroundColor;
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
                BackgroundImage = Resources.Music_on,
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
            if (isMusicOn)
            {
                isMusicOn = false;
                ((Button) sender).BackgroundImage = Resources.Music_off;
                music.Stop(); 
            }
            else
            {
                isMusicOn = true;
                ((Button) sender).BackgroundImage = Resources.Music_on;
                music.Play();
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
            if (isTutorial1)
            {
                isTutorial1 = false;
                isTutorial2 = true;
            }
            else if(isTutorial2)
            {
                isTutorial2 = false;
                isTutorial3 = true;
            }
            Controls.Clear();
            Update();
            Invalidate();
        }

        private void OverButtonOnClick(object sender, EventArgs e)
        {
            isTutorial3 = false;
            Controls.Clear();
            Invalidate();
        }

        private void ReturnButtonOnClick(object sender, EventArgs e)
        {
            isMenu = false;
            Controls.Clear();
            Update();
            Invalidate();
        }

        private void Dialog1OnClick(object sender, EventArgs e)
        {
            Controls.Clear();
            isDialog1 = false;
            Update();
            Invalidate();
        }

        private void Dialog2OnClick(object sender, EventArgs e)
        {
            Controls.Clear();
            isDialog2 = false;
            Update();
            Invalidate();
        }

        private void Dialog3OnClick(object sender, EventArgs e)
        {
            Controls.Clear();
            isDialog3 = false;
            Update();
            Invalidate();
        }

        private void Dialog4OnClick(object sender, EventArgs e)
        {
            flagM = false;
            Controller.Game.Room.Background = Resources.Деканат_ожидание;
            Controls.Clear();
            isDialog4 = false;
            Controller.Game.FlagDecan = false;
            missionItem = true;
            Update();
            Invalidate();
        }

        private void DialogM1OnClick(object sender, EventArgs e)
        {
            Controls.Clear();
            isDialogM1 = false;
            Update();
            Invalidate();
        }

        private void DialogM2OnClick(object sender, EventArgs e)
        {
            Controls.Clear();
            isDialogM2 = false;
            Update();
            Invalidate();
        }

        private void DialogM3OnClick(object sender, EventArgs e)
        {
            Controls.Clear();
            isDialogM3 = false;
            Update();
            Invalidate();
        }

        private void DialogM4OnClick(object sender, EventArgs e)
        {
            Controls.Clear();
            isDialogM4 = false;
            Update();
            Invalidate();
        }
       
        private void DialogM5OnClick(object sender, EventArgs e)
        {
            flagM = false;
            Controls.Clear();
            isDemo = true;
            Update();
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
