﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using MATMEH_QUEST.Properties;

namespace MATMEH_QUEST
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected Button MakeNewButton(string text, Point location, Size size, Font font, FlatStyle flatStyle,
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
            var backgroundColor = Color.FromArgb(145, 215, 254);
            BackColor = backgroundColor;
            
            var logotype = new Bitmap(Resources.фон, 120, 105);
            graphics.DrawImage(logotype, new Point(100, 0));

            PrivateFontCollection fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile("19190.TTF");
            FontFamily family = fontCollection.Families[0];


            var newGame = MakeNewButton("НОВАЯ ИГРА", 
                new Point(0, 0), 
                new Size(100, 50),
                new Font(family, 20), 
                FlatStyle.Flat, 
                Color.FromArgb(1, 127, 189), 
                0, 
                backgroundColor);
            Controls.Add(newGame);

            var exit = MakeNewButton("ВЫХОД",
                new Point(Width / 2 - 50, Bottom / 2),
                new Size(100, 50),
                new Font(family, 20),
                FlatStyle.Flat,
                Color.FromArgb(1, 127, 189),
                0,
                backgroundColor);
            Controls.Add(exit);
            Controls.Add(new TextBox(){Text = Width.ToString()});
        }
    }
}

