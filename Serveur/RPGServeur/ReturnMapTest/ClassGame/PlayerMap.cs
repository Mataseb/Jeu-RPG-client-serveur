using RPGServeur;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReturnMapTest.ClassGame
{
    class PlayerMap : PictureBox
    {
        Image img;
        Timer t;
        Color couleur;
        Point origin;
        int height = 21;
        int width = 21;
        int tileSize = 20;
        int[,] map = new int[21, 21];

        BaseGame baseGame;

        public int[,] TileMap
        {
            get
            {
                return map;
            }
        }

        public PlayerMap() : base()
        {
            t = new Timer();
            t.Interval = 100;
            t.Tick += this.Tick;
            t.Enabled = true;

            base.Paint += PlayerMap_Paint;
            baseGame = new BaseGame();
        }

        private void Tick(object sender, EventArgs e)
        {
            Invalidate(); // lol
            map = baseGame.PlayerMap(1);
        }

        private void PlayerMap_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    switch (map[j, i])
                    {
                        case 1:
                            img = Properties.Resources.Grass;
                            break;
                        case 2:
                            img = Properties.Resources.Water;
                            break;
                        case 3:
                            img = Properties.Resources.Rock;
                            break;
                        case 4:
                            img = Properties.Resources.GroundDirt;
                            break;
                        case 5:
                            img = Properties.Resources.Tree;
                            break;
                        default:
                            img = Properties.Resources.Ground;
                            break;
                    }
                    e.Graphics.DrawImage(img, new Rectangle(origin.X + i * tileSize, origin.Y + j * tileSize, tileSize, tileSize));
                }
            }
        }
    }
}
