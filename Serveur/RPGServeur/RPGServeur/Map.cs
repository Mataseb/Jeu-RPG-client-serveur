﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGServeur
{
    class Map : PictureBox
    {
        Image img;
        Timer t;
        Color couleur;
        Point origin;
        int height = 15;
        int width = 11;
        int tileSize = 20;
        int[,] baseGame = new int[15, 11] {
            {1, 1, 0, 0, 1, 1, 0, 1, 0, 1, 1},
            {1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1},
            {1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1},
            {1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1},
            {1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1},
            {1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1},
            {1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1},
            {1, 0, 0, 0, 0, 1, 0, 1, 0, 1, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            {1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1},
            {1, 0, 0, 0, 1, 0, 1, 1, 0, 1, 1},
            {1, 1, 1, 1, 0, 0, 0, 1, 0, 1, 1},
            {1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1},
            {1, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1}
        };

        public Map() : base()
        {
            t = new Timer();
            t.Interval = 999;
            t.Tick += this.Tick;
            t.Enabled = true;

            couleur = new Color();
            origin = new Point(5, 5);
            base.Paint += BaseGame_Paint;
        }

        private void Tick(object sender, EventArgs e)
        {
            base.Refresh();
        }

        private void BaseGame_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    switch (baseGame[j, i])
                    {
                        case 0:
                            img = Properties.Resources.Ground;
                            break;
                        case 1:
                            img = Properties.Resources.Gravel;
                            break;
                        default:
                            couleur = Color.Green;
                            break;
                    }
                    //e.Graphics.FillRectangle(new SolidBrush(couleur), new Rectangle(origin.X + i * tileSize, origin.Y + j * tileSize, tileSize, tileSize));
                    e.Graphics.DrawImage(img, new Rectangle(origin.X + i * tileSize, origin.Y + j * tileSize, tileSize, tileSize));
                }
            }
        }
    }
}
