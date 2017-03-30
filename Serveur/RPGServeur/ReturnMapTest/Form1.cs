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
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            playerMap1.UpdateMap();
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            playerMap1.MoveDown(1);
            playerMap1.UpdateMap();
        }

        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            playerMap1.MoveLeft(1);
            playerMap1.UpdateMap();
        }

        private void btnMoveRight_Click(object sender, EventArgs e)
        {
            playerMap1.MoveRight(1);
            playerMap1.UpdateMap();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Left || keyData == Keys.A)
            {
                playerMap1.MoveLeft(1);
                playerMap1.UpdateMap();
                return true;
            }
            if (keyData == Keys.Right || keyData == Keys.D)
            {
                playerMap1.MoveRight(1);
                playerMap1.UpdateMap();
                return true;
            }
            if (keyData == Keys.Up || keyData == Keys.W)
            {
                playerMap1.MoveUp(1);
                playerMap1.UpdateMap();
                return true;
            }
            if (keyData == Keys.Down || keyData == Keys.S)
            {
                playerMap1.MoveDown(1);
                playerMap1.UpdateMap();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
