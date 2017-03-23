using RPGServeur;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        BaseGame game;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game = new BaseGame();
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

        private void btnActiver_Click(object sender, EventArgs e)
        {

        }

        private void btnMovetop_Click(object sender, EventArgs e)
        {
            playerMap1.MoveUp(1);
            playerMap1.UpdateMap();
            lblCoord.Text = playerMap1.BaseGame.Players[0].Position.ToString();
            lblPlayermaporigin.Text = playerMap1.BaseGame.PositionPlayerMap00.X + " ; " + playerMap1.BaseGame.PositionPlayerMap00.Y;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            playerMap1.UpdateMap();
        }
       
        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            playerMap1.MoveDown(1);
            playerMap1.UpdateMap();
            lblPlayermaporigin.Text = playerMap1.BaseGame.PositionPlayerMap00.X + " ; " + playerMap1.BaseGame.PositionPlayerMap00.Y;

            lblCoord.Text = playerMap1.BaseGame.Players[0].Position.ToString();
        }

        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            playerMap1.MoveLeft(1);
            playerMap1.UpdateMap();
            lblPlayermaporigin.Text = playerMap1.BaseGame.PositionPlayerMap00.X + " ; " + playerMap1.BaseGame.PositionPlayerMap00.Y;

            lblCoord.Text = playerMap1.BaseGame.Players[0].Position.ToString();
        }

        private void btnMoveRight_Click(object sender, EventArgs e)
        {
            playerMap1.MoveRight(1);
            playerMap1.UpdateMap();
            lblPlayermaporigin.Text = playerMap1.BaseGame.PositionPlayerMap00.X + " ; " + playerMap1.BaseGame.PositionPlayerMap00.Y;

            lblCoord.Text = playerMap1.BaseGame.Players[0].Position.ToString();
        }
    }
}
