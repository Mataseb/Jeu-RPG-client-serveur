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
        Point positionPlayerMap00;
        List<int> possibleToWalkOn = new List<int>();
        //Distance en cases entre le joueur et le bord de sa vue
        const int DISTANCE_BORD_JOUEUR = 7;

        //Distance en cases entre le joueur au centre de sa vue et le bord de sa vue
        const int DISTANCE_BORD_MAP_JOUEUR_CENTRE = DISTANCE_BORD_JOUEUR + 1;

        //vue joueur
        const int DISTANCE_VUE_JOUEUR = 2 * DISTANCE_BORD_JOUEUR;
        public BaseGame()
        {
            map = new Map();
            players = new List<Player>();
            spawns = new List<Point>();
            spawns.Add(new Point(2, 50));
            spawns.Add(new Point(51, 49));
            spawns.Add(new Point(51, 72));
            spawns.Add(new Point(76, 4));
            spawns.Add(new Point(71, 3));
            spawns.Add(new Point(73, 21));
            spawns.Add(new Point(2, 2));
            spawns.Add(new Point(29, 27));
        }

        public Map Game
        {
            get
            {
                return map;
            }
        }

        internal List<Player> Players
        {
            get
            {
                return players;
            }

            set
            {
                players = value;
            }
        }

        public Point PositionPlayerMap00
        {
            get
            {
                return positionPlayerMap00;
            }

            set
            {
                positionPlayerMap00 = value;
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
            map.Players = players;
        }

        /// <summary>
        /// Suprimme un joueur du jeu
        /// </summary>
        public void DeletePlayer(int idPlayer)
        {

        }

        public Point getPositionPlayerInPlayerMap(Player player)
        {
            int PositionYPlayerInPlayerMap = 0;
            int PositionXPlayerInPlayerMap = 0;

            PositionYPlayerInPlayerMap = player.Position.Y - PositionPlayerMap00.Y;
            PositionXPlayerInPlayerMap = player.Position.X - PositionPlayerMap00.X;


            Point PositionPlayerInPlayerMap = new Point(PositionXPlayerInPlayerMap, PositionYPlayerInPlayerMap);

            return PositionPlayerInPlayerMap;
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
                posX = 45;
                posY = 45;
            }
            #region Si le joueur n'est pas au bord de la map
            if (((posX >= DISTANCE_BORD_MAP_JOUEUR_CENTRE)
                && (posY >= DISTANCE_BORD_MAP_JOUEUR_CENTRE))
                && ((posX <= Game.Width - DISTANCE_BORD_MAP_JOUEUR_CENTRE)
                && posY <= Game.Height - DISTANCE_BORD_MAP_JOUEUR_CENTRE))
            {
                for (int i = -DISTANCE_BORD_JOUEUR; i <= DISTANCE_BORD_JOUEUR; i++)
                {
                    for (int j = -DISTANCE_BORD_JOUEUR; j <= DISTANCE_BORD_JOUEUR; j++)
                    {
                        PositionPlayerMap00 = new Point((posX + i) - (i + DISTANCE_BORD_JOUEUR), (posY + j) - (j + DISTANCE_BORD_JOUEUR));
                        playermap[j + DISTANCE_BORD_JOUEUR, i + DISTANCE_BORD_JOUEUR] = Game.map[posY + j, posX + i];
                    }
                }
            }
            #endregion
            else
            {
                #region Ligne supérieur centre
                if ((posY <= DISTANCE_BORD_MAP_JOUEUR_CENTRE)
                    && (posX >= DISTANCE_BORD_MAP_JOUEUR_CENTRE)
                    && (posX <= Game.Width - DISTANCE_BORD_MAP_JOUEUR_CENTRE))
                {
                    //ne corrige pas le (x)
                    for (int i = -DISTANCE_BORD_JOUEUR; i <= DISTANCE_BORD_JOUEUR; i++)
                    {
                        //corrige le (y)
                        for (int j = 0; j <= DISTANCE_VUE_JOUEUR; j++)
                        {
                            PositionPlayerMap00 = new Point((posX + i) - (i + DISTANCE_BORD_JOUEUR), j - j);
                            playermap[j, i + DISTANCE_BORD_JOUEUR] = Game.map[j, posX + i];
                        }
                    }
                }
                #endregion
                #region Ligne inférieur centre
                if ((posY >= Game.Height - DISTANCE_BORD_MAP_JOUEUR_CENTRE)
                    && (posX >= DISTANCE_BORD_MAP_JOUEUR_CENTRE)
                    && (posX <= Game.Width - DISTANCE_BORD_MAP_JOUEUR_CENTRE))
                {
                    //ne corrige pas le (x)
                    for (int i = -DISTANCE_BORD_JOUEUR; i <= DISTANCE_BORD_JOUEUR; i++)
                    {
                        //corrige le (y)
                        for (int j = Game.Height - DISTANCE_VUE_JOUEUR; j <= Game.Height; j++)
                        {
                            PositionPlayerMap00 = new Point((posX + i) - (i + DISTANCE_BORD_JOUEUR), (j - 1) - (j - (Game.Height - DISTANCE_VUE_JOUEUR)));
                            playermap[j - (Game.Height - DISTANCE_VUE_JOUEUR), i + DISTANCE_BORD_JOUEUR] = Game.map[j - 1, posX + i];
                        }
                    }
                }
                #endregion
                #region Colonne de gauche centre
                if ((posX <= DISTANCE_BORD_MAP_JOUEUR_CENTRE)
                    && (posY >= DISTANCE_BORD_MAP_JOUEUR_CENTRE)
                    && (posY <= Game.Height - DISTANCE_BORD_MAP_JOUEUR_CENTRE))
                {
                    //corrige le (x)
                    for (int i = 0; i <= DISTANCE_VUE_JOUEUR; i++)
                    {
                        //ne corrige pas le (y)
                        for (int j = -DISTANCE_BORD_JOUEUR; j <= DISTANCE_BORD_JOUEUR; j++)
                        {
                            PositionPlayerMap00 = new Point(i - i, (posY + j) - (j + DISTANCE_BORD_JOUEUR));
                            playermap[j + DISTANCE_BORD_JOUEUR, i] = Game.map[posY + j, i];
                        }
                    }
                }
                #endregion
                #region coin supérieur gauche
                if ((posY < DISTANCE_BORD_MAP_JOUEUR_CENTRE)
                    && (posX < DISTANCE_BORD_MAP_JOUEUR_CENTRE))
                {
                    for (int i = 0; i <= DISTANCE_VUE_JOUEUR; i++)
                    {
                        for (int j = 0; j <= DISTANCE_VUE_JOUEUR; j++)
                        {
                            PositionPlayerMap00 = new Point(i - i, j - j);
                            playermap[j, i] = Game.map[j, i];
                        }
                    }
                }
                #endregion
                #region coin inférieur gauche
                if ((posY > Game.Height - DISTANCE_BORD_MAP_JOUEUR_CENTRE)
                    && (posX < DISTANCE_BORD_MAP_JOUEUR_CENTRE))
                {
                    for (int i = 0; i <= DISTANCE_VUE_JOUEUR; i++)
                    {
                        for (int j = Game.Height - DISTANCE_VUE_JOUEUR; j <= Game.Height; j++)
                        {
                            PositionPlayerMap00 = new Point(i - i, (j - 1) - (j - (Game.Height - DISTANCE_VUE_JOUEUR)));
                            playermap[j - (Game.Height - DISTANCE_VUE_JOUEUR), i] = Game.map[j - 1, i];
                        }
                    }
                }
                #endregion
                #region Colonne de droite centre
                if ((posX >= Game.Width - DISTANCE_BORD_MAP_JOUEUR_CENTRE)
                    && (posY >= DISTANCE_BORD_MAP_JOUEUR_CENTRE)
                    && (posY <= Game.Height - DISTANCE_BORD_MAP_JOUEUR_CENTRE))
                {
                    //corrige le (x)
                    for (int i = Game.Width - DISTANCE_VUE_JOUEUR; i <= Game.Width; i++)
                    {
                        //ne corrige pas le (y)
                        for (int j = -DISTANCE_BORD_JOUEUR; j <= DISTANCE_BORD_JOUEUR; j++)
                        {
                            PositionPlayerMap00 = new Point((i - 1) - (i - (Game.Width - DISTANCE_VUE_JOUEUR)), (posY + j) - (j + DISTANCE_BORD_JOUEUR));
                            playermap[j + DISTANCE_BORD_JOUEUR, i - (Game.Width - DISTANCE_VUE_JOUEUR)] = Game.map[posY + j, i - 1];
                        }
                    }
                }
                #endregion
                #region coin supérieur droit
                if ((posY < DISTANCE_BORD_MAP_JOUEUR_CENTRE)
                    && (posX > Game.Width - DISTANCE_BORD_MAP_JOUEUR_CENTRE))
                {
                    for (int i = Game.Width - DISTANCE_VUE_JOUEUR; i <= Game.Width; i++)
                    {
                        for (int j = 0; j <= DISTANCE_VUE_JOUEUR; j++)
                        {
                            PositionPlayerMap00 = new Point((i - 1) - (i - (Game.Width - DISTANCE_VUE_JOUEUR)), j - j);
                            playermap[j, i - (Game.Width - DISTANCE_VUE_JOUEUR)] = Game.map[j, i - 1];
                        }
                    }
                }
                #endregion
                #region coin inférieur droit
                if ((posY > Game.Height - DISTANCE_BORD_MAP_JOUEUR_CENTRE)
                    && (posX > Game.Width - DISTANCE_BORD_MAP_JOUEUR_CENTRE))
                {
                    for (int i = Game.Width - DISTANCE_VUE_JOUEUR; i <= Game.Width; i++)
                    {
                        for (int j = Game.Height - DISTANCE_VUE_JOUEUR; j <= Game.Height; j++)
                        {
                            PositionPlayerMap00 = new Point((i - 1) - (i - (Game.Width - DISTANCE_VUE_JOUEUR)), (j - 1) - (j - (Game.Height - DISTANCE_VUE_JOUEUR)));
                            playermap[j - (Game.Height - DISTANCE_VUE_JOUEUR), i - (Game.Width - DISTANCE_VUE_JOUEUR)] = Game.map[j - 1, i - 1];
                        }
                    }
                }
                #endregion
            }
            return playermap;
        }
        public int GetTexture(Point coordonnees)
        {
            return Game.map[coordonnees.Y, coordonnees.X];
        }
    }
}
