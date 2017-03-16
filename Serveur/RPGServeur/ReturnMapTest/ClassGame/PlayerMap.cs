using RPGServeur;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReturnMapTest.ClassGame
{
    class PlayerMap : PictureBox
    {
        Image img;
        Point origin;
        int tileSize = 20;
        const int HEIGHT = 21;
        const int WIDTH = 21;
        const int TILESIZE = 20;
        int[,] map;

        BaseGame baseGame;

        public int[,] TileMap
        {
            get
            {
                return map;
            }
        }

        public BaseGame BaseGame
        {
            get
            {
                return baseGame;
            }
        }

        public PlayerMap() : base()
        {
            map = new int[WIDTH, HEIGHT];
            base.Paint += PlayerMap_Paint;
            baseGame = new BaseGame();
            baseGame.AddPlayer(1, "Player 1", IPAddress.Parse(GetLocalIPAddress()));
            base.Height = HEIGHT * TILESIZE;
            base.Width = HEIGHT * TILESIZE;
        }

        public void UpdateMap()
        {
            map = baseGame.PlayerMap(1);
            this.Invalidate();
        }
        //Dessine la map
        public void PlayerMap_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < WIDTH; i++)
            {
                for (int j = 0; j < HEIGHT; j++)
                {
                    switch (TileMap[j, i])
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
                    e.Graphics.DrawImage(img, new Rectangle(origin.X + i * TILESIZE, origin.Y + j * TILESIZE, TILESIZE, TILESIZE));
                }
            }
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }

        public void MoveUp(int idPlayer)
        {
            if (baseGame.Players[idPlayer - 1].Position.Y > 1)
            {
                baseGame.Players[idPlayer - 1].MoveUp();
            }
        }

        public void MoveDown(int idPlayer)
        {
            if (baseGame.Players[idPlayer - 1].Position.Y < baseGame.Game.Height - 1)
            {
                baseGame.Players[idPlayer - 1].MoveDown();
            }
        }

        public void MoveRight(int idPlayer)      
        {
            if (baseGame.Players[idPlayer - 1].Position.X < BaseGame.Game.Width - 1)
            {
                baseGame.Players[idPlayer - 1].MoveRight();
            }
        }

        public void MoveLeft(int idPlayer)
        {
            if (baseGame.Players[idPlayer - 1].Position.X > 1)
            {
                baseGame.Players[idPlayer - 1].MoveLeft();
            }
        }
    }
}
