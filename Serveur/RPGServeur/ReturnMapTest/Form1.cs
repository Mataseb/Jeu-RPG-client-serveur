using RPGServeur;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReturnMapTest
{
    public partial class Form1 : Form
    {
        Stream stm;
        TcpClient tcpclnt;

        public Form1()
        {
            InitializeComponent();
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

        private void MapRequest()
        {
            try
            {
                tcpclnt = new TcpClient();

                tcpclnt.Connect("172.21.5.99", 8001);

                String str = Console.ReadLine();
                stm = tcpclnt.GetStream();

                ASCIIEncoding asen = new ASCIIEncoding();
                byte[] ba = asen.GetBytes(str);
                Console.WriteLine("Transmitting.....");

                stm.Write(ba, 0, ba.Length);

                byte[] bb = new byte[100];
                int k = stm.Read(bb, 0, 100);

                for (int i = 0; i < k; i++)
                    Console.Write(Convert.ToChar(bb[i]));

                tcpclnt.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine("Error..... " + e.StackTrace);
            }
        }
        /// <summary>
        /// Crée le modèle et affiche la vue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load_1(object sender, EventArgs e)
        {
            playerMap2.UpdateMap();
        }
        

        /// <summary>
        /// Si la touche du clavier pressée est une touche prévue, déplace le joueur controlé
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left || keyData == Keys.A)
            {
                playerMap2.MoveLeft(playerMap2.BaseGame.PlayerSelected);
                playerMap2.UpdateMap();
                return true;
            }
            if (keyData == Keys.Right || keyData == Keys.D)
            {
                playerMap2.MoveRight(playerMap2.BaseGame.PlayerSelected);
                playerMap2.UpdateMap();
                return true;
            }
            if (keyData == Keys.Up || keyData == Keys.W)
            {
                playerMap2.MoveUp(playerMap2.BaseGame.PlayerSelected);
                playerMap2.UpdateMap();
                return true;
            }
            if (keyData == Keys.Down || keyData == Keys.S)
            {
                playerMap2.MoveDown(playerMap2.BaseGame.PlayerSelected);
                playerMap2.UpdateMap();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region selection joueurs
        private void btnPlayer1_Click(object sender, EventArgs e)
        {
            playerMap2.BaseGame.PlayerSelected = 1;
            playerMap2.UpdateMap();
        }

        private void btnPlayer2_Click(object sender, EventArgs e)
        {
            playerMap2.BaseGame.PlayerSelected = 2;
            playerMap2.UpdateMap();
        }

        private void btnPlayer3_Click(object sender, EventArgs e)
        {
            playerMap2.BaseGame.PlayerSelected = 3;
            playerMap2.UpdateMap();
        }

        private void btnPlayer4_Click(object sender, EventArgs e)
        {
            playerMap2.BaseGame.PlayerSelected = 4;
            playerMap2.UpdateMap();
        }
        #endregion
    }
}
