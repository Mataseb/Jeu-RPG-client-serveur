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
        List<int> possibleToWalkOn = new List<int>();
        Image img;
        Point origin;
        const int HEIGHT = 15;
        const int WIDTH = 15;
        public const int TILESIZE = 40;
        int[,] map;

        BaseGame baseGame;

        public int[,] TileMap
        {
            set
            {
                map = value;
            }
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
            baseGame = new BaseGame();
            baseGame.AddPlayer(1, "Player 1", IPAddress.Parse(GetLocalIPAddress()));
            base.Height = HEIGHT * TILESIZE;
            base.Width = HEIGHT * TILESIZE;
            base.Paint += PlayerMap_Paint;
            possibleToWalkOn.Add(4);//herbe
            possibleToWalkOn.Add(5);//sable
            possibleToWalkOn.Add(6);//chemin de pierre
            possibleToWalkOn.Add(7);//chemin de boue
        }

        public void UpdateMap()
        {
            map = baseGame.PlayerMap(1);
            this.Invalidate();
        }
        //Dessine la map
        public void PlayerMap_Paint(object sender, PaintEventArgs e)
        {
            int a = baseGame.Players[0].Position.X;

            for (int i = 0; i < WIDTH; i++)
            {
                for (int j = 0; j < HEIGHT; j++)
                {
                    switch (TileMap[j, i])
                    {
                        case 1:
                            // ne peut aller
                            img = Properties.Resources.OceanWater;
                            break;
                        case 2:
                            //ne peut pas aller
                            img = Properties.Resources.MaraisWater;
                            break;
                        case 3:
                            //ne peut pas aller
                            img = Properties.Resources.trees;
                            break;
                        case 4:
                            //peut aller
                            img = Properties.Resources.grass;
                            break;
                        case 5:
                            //peut aller
                            img = Properties.Resources.sand;
                            break;
                        case 6:
                            //peut aller
                            img = Properties.Resources.road;
                            break;
                        case 7:
                            //peut aller
                            img = Properties.Resources.BoueRoad;
                            break;
                        case 8:
                            //ne peut pas aller
                            img = Properties.Resources.muraille;
                            break;
                        default:
                            img = Properties.Resources.Ground;
                            break;
                    }

                    e.Graphics.DrawImage(img, new Rectangle(origin.X + i * TILESIZE, origin.Y + j * TILESIZE, TILESIZE, TILESIZE));

                    foreach (Player player in BaseGame.Players)
                    {
                        
                        e.Graphics.DrawImage(Properties.Resources.link, new Rectangle(BaseGame.getPositionPlayerInPlayerMap(player).X * TILESIZE, BaseGame.getPositionPlayerInPlayerMap(player).Y * TILESIZE, TILESIZE, TILESIZE));
                    }
                }
            }
        }

        /// <summary>
        /// Récupère l'adresse ip local
        /// </summary>
        /// <returns>IP en string</returns>
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
            if (baseGame.Players[idPlayer - 1].Position.Y >= 1)
            {
                if (possibleToWalkOn.Contains(BaseGame.GetTexture(new Point(
                    BaseGame.Players[idPlayer - 1].Position.X,
                    BaseGame.Players[idPlayer - 1].Position.Y - 1))))
                {
                    baseGame.Players[idPlayer - 1].MoveUp();
                }
            }
        }

        public void MoveDown(int idPlayer)
        {
            if (baseGame.Players[idPlayer - 1].Position.Y < baseGame.Game.Height -1)
            {
                if (possibleToWalkOn.Contains(BaseGame.GetTexture(new Point(
                    BaseGame.Players[idPlayer - 1].Position.X,
                    BaseGame.Players[idPlayer - 1].Position.Y + 1))))
                {
                    baseGame.Players[idPlayer - 1].MoveDown();
                }
            }
        }

        public void MoveRight(int idPlayer)
        {
            if (baseGame.Players[idPlayer - 1].Position.X < BaseGame.Game.Width -1)
            {
                if (possibleToWalkOn.Contains(BaseGame.GetTexture(new Point(
                    BaseGame.Players[idPlayer - 1].Position.X + 1,
                    BaseGame.Players[idPlayer - 1].Position.Y))))
                {
                    baseGame.Players[idPlayer - 1].MoveRight();
                }
            }
        }

        public void MoveLeft(int idPlayer)
        {
            if (baseGame.Players[idPlayer - 1].Position.X >= 1)
            {
                if (possibleToWalkOn.Contains(BaseGame.GetTexture(new Point(
                    BaseGame.Players[idPlayer - 1].Position.X-1, 
                    BaseGame.Players[idPlayer - 1].Position.Y))))
                {
                    baseGame.Players[idPlayer - 1].MoveLeft();
                }
            }
        }
    }
}
