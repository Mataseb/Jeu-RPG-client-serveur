using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace RPGServeur
{
    class BaseGame
    {
        Map map;
        List<Player> players;
        List<Point> spawns;

        public BaseGame()
        {
            map = new Map();
            players = new List<Player>();
            spawns = new List<Point>();
            spawns.Add(new Point(5, 5));
            spawns.Add(new Point(45, 45));
        }

        public Map Game
        {
            get
            {
                return map;
            }
        }

        /// <summary>
        /// Ajoute un joueur dans le jeu
        /// </summary>
        public void AddPlayer(int idPlayer, string username, IPAddress ip)
        {
            Random rdn = new Random();
            int count = 0;
            foreach (Player item in players)
            {
                count++;
            }
            players.Add(new Player(count + 1, username, ip, spawns[rdn.Next(0, spawns.Count())]));
        }

        /// <summary>
        /// Suprimme un joueur du jeu
        /// </summary>
        public void DelPlayer(int idPlayer)
        {
            players.RemoveAt(idPlayer);
        }

        /// <summary>
        /// Renvoie ce que le joueur peut voir selon son emplacement
        /// </summary>
        /// <returns></returns>
        public int[,] PlayerMap(int idPlayer)
        {
            int[,] playermap = new int[21, 21];
            int posX;
            int posY;

            if (players.Count != 0)
            {
                posX = players[idPlayer - 1].Position.X;
                posY = players[idPlayer - 1].Position.Y;
            }
            else
            {
                posX = 5;
                posY = 5;
            }

            if ((posX >= 11 && posY >= 11) && (posX <= 39 && posY <= 39))
            {
                for (int i = -10; i <= 10; i++)
                {
                    for (int j = -10; j <= 10; j++)
                    {
                        playermap[j + 10, i + 10] = Game.map[posY + j, posX + i];
                    }
                }
            }
            else if ((posX < 11 && posY < 11))
            {
                for (int i = 0; i <= 20; i++)
                {
                    for (int j = 0; j <= 20; j++)
                    {
                        playermap[j, i] = Game.map[j, i];
                    }
                }
            }
            else if ((posX < 11 && posY > 39))
            {
                for (int i = 0; i <= 20; i++)
                {
                    for (int j = 30; j <= 50; j++)
                    {
                        playermap[j - 30, i] = Game.map[j - 1, i];
                    }
                }
            }
            else if ((posX > 39 && posY > 39))
            {
                for (int i = 30; i <= 50; i++)
                {
                    for (int j = 30; j <= 50; j++)
                    {
                        playermap[j - 30, i - 30] = Game.map[j - 1, i - 1];
                    }
                }
            }
            else if ((posX > 39 && posY < 11))
            {
                for (int i = 30; i <= 50; i++)
                {
                    for (int j = 0; j <= 20; j++)
                    {
                        playermap[j, i - 30] = Game.map[j, i - 1];
                    }
                }
            }


            return playermap;
        }
    }
}
