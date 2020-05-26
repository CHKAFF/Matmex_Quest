using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using MATMEH_QUEST.Domain;
using MATMEH_QUEST.Properties;

namespace MATMEH_QUEST
{
    public partial class Form1 : Form
    {
        private bool isMusicOn;
        private bool isMenu;
        private bool isTutorial1;
        private bool isTutorial2;
        private SoundPlayer music;
        private Controller controller;
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            Timer timer = new Timer {Interval = 1000 / 60};
            timer.Tick += new EventHandler(TimerTick);
            timer.Start();
            isMusicOn = true;
            isMenu = true;
            isTutorial1 = true;
            isTutorial2 = true;
            music = new SoundPlayer(Resources.Олег_Кензов___По_Кайфу);
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            controller = new Controller(Size.Width);
            DoubleBuffered = true;
            KeyDown += (sender, args) =>
            {
                controller.Action(args);
            };
        }

        private void TimerTick(object sender, EventArgs args)
        {
            
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;
            if (isMenu)
                PaintMenu();
            else if (isTutorial1)
            {
                PaintFirstTrain(graphics);
            }
            else if (isTutorial2)
            {
                PaintSecondTrain(graphics);
            }
            else
            {
                
                if (controller.Game.Room == null) 
                    PaintWorld(graphics); 
                else 
                    PaintRoom(graphics);
                
                var inventory = new Bitmap(Resources.Inventory);
                graphics.DrawImage(inventory, new Point(Size.Width / 2 - inventory.Width / 2, Size.Height/2 + 290));
                var missionTable = controller.Game.MissionSprite;
                graphics.DrawImage(missionTable, new Point(Size.Width / 2 - inventory.Width / 2, Size.Height/20));
            }
        }

        private void PaintFirstTrain(Graphics graphics)
        {
            Invalidate();
            BackColor = Color.Aqua;

            var tutorialForm = new Bitmap(Resources.Обучение_1);
            graphics.DrawImage(tutorialForm, new Point(Size.Width / 2 - tutorialForm.Width / 2, Size.Height / 6));

            var nextButton = new PictureBox
            {
                ForeColor = Color.Transparent,
                BackColor = Color.Transparent,
                Location = new Point(790, 500),
                Size = new Size(160, 40)
            };
            Controls.Add(nextButton);
            nextButton.Update();
            nextButton.Click += NextOnClick;
        }

        private void PaintSecondTrain(Graphics graphics)
        {
            Invalidate();
            BackColor = Color.Aqua;

            var tutorialForm = new Bitmap(Resources.Обучение_2);
            graphics.DrawImage(tutorialForm, new Point(Size.Width / 2 - tutorialForm.Width / 2, Size.Height / 6));

            var overButton = new PictureBox
            {
                ForeColor = Color.Transparent,
                BackColor = Color.Transparent,
                Location = new Point(790, 500),
                Size = new Size(160, 40)
            };
            Controls.Add(overButton);
            overButton.Update();
            overButton.Click += OverButtonOnClick;
        }


        private void PaintRoom(Graphics graphics)
        {
            Invalidate();
            controller.Game.Room.AvailableX[1] = Size.Width - 200;
            BackgroundImage = controller.Game.Room.Background;
            BackgroundImageLayout = ImageLayout.Stretch;
            PaintPlayer(graphics);
        }

        private void PaintWorld(Graphics graphics)
        {
            Invalidate();
            controller.Game.World.AvailableX[1] = Size.Width - 200;
            BackgroundImage = new Bitmap(Resources.Corridor);
            BackgroundImageLayout = ImageLayout.Stretch;
            graphics.DrawImage(BackgroundImage, controller.Game.World.Location);

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
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            

            var logotype = new PictureBox
            {
                Image = new Bitmap(Resources.Логотип), 
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill
            };


            var musicText = new Button
            {
                Text = "МУЗЫКА",
                Font = new Font("Arial", 20),
                ForeColor = Color.FromArgb(1, 127, 189),
                Location = new Point(Left, Top),
                Size = new Size(150, 100),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance =
                {
                    CheckedBackColor = Color.Transparent,
                    MouseDownBackColor = Color.Transparent,
                    MouseOverBackColor = Color.Transparent
                },
                BackColor = Color.Transparent,
            };
            musicText.FlatAppearance.BorderSize = 0;
            musicText.FlatAppearance.BorderColor = backgroundColor;


            var music = new Button
            {
                BackgroundImage = new Bitmap(Resources.Music_on),
                BackgroundImageLayout = ImageLayout.Zoom,
                Location = new Point(Left, Top),
                Size = new Size(150, 100),
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = 
                {
                    CheckedBackColor = Color.Transparent, 
                    MouseDownBackColor = Color.Transparent, 
                    MouseOverBackColor = Color.Transparent
                },
                BackColor = Color.Transparent,
            };
            music.FlatAppearance.BorderSize = 0;
            music.FlatAppearance.BorderColor = backgroundColor;
            music.Dock = DockStyle.Top;


            var newGame = new Button
            {
                Text = Resources.Новая_игра,
                Font = new Font("Arial", 20),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.FromArgb(1, 127, 189)
            };
            newGame.FlatAppearance.BorderSize = 0;
            newGame.FlatAppearance.BorderColor = backgroundColor;
            newGame.Dock = DockStyle.Fill;


            var exit = new Button
            {
                Text = Resources.Выход,
                Font = new Font("Arial", 20),
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.FromArgb(1, 127, 189)
            };
            exit.FlatAppearance.BorderSize = 0;
            exit.FlatAppearance.BorderColor = backgroundColor;
            exit.Dock = DockStyle.Fill;


            table.Controls.Add(music, 0, 0);
            table.Controls.Add(musicText, 1, 0);
            table.Controls.Add(logotype, 2, 0);
            table.Controls.Add(newGame,2,1);
            table.Controls.Add(exit,2,2);
            table.Controls.Add(new UserControl(), 3, 0);

            table.Dock = DockStyle.Fill;
            Controls.Add(table);
            
            music.Click += MusicOnOnClick;
            newGame.Click += NewGameOnClick;
            exit.Click += ExitOnClick;
            Invalidate();
            
        }

        private void MusicOnOnClick(object sender, EventArgs e)
        {
            isMusicOn = !isMusicOn;
            if (!isMusicOn)
            {
                ((Button) sender).BackgroundImage = Resources.Music_off;
                music.Play();
            }
            else
            {
                ((Button) sender).BackgroundImage = Resources.Music_on;
                music.Stop();
                
            }

            Invalidate();
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

        private void NextOnClick(object sender, EventArgs e)
        {
            Controls.Clear();
            BackColor = Color.Empty;
            isTutorial1 = false;
            Invalidate();
        }

        private void OverButtonOnClick(object sender, EventArgs e)
        {
            Controls.Clear();
            BackColor = Color.Empty;
            isTutorial2 = false;
            Invalidate();
            controller.NewMission();
        }
    }
}
