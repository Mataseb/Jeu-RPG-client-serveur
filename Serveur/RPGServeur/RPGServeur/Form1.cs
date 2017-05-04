using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGServeur
{
    public partial class Form1 : Form
    {
        private static Thread thEcoute;
        bool thEcouteWork = true;
        string msg;
        List<Socket> sockets;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Récupère l'addresse ip de la machine courante
        /// </summary>
        /// <returns>Adresse ip</returns>
        public static IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;//.ToString();
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblStatutServeur.Text = "Statut: Activé";
            lblIp.Text = "Adresse du serveur : " + GetLocalIPAddress();
            thEcoute = new Thread(new ThreadStart(Ecouter));
            thEcoute.Start();
            sockets = new List<Socket>();
        }

        /*private void Ecouter()
        {
            UdpClient serveur = new UdpClient(5035);

            while (thEcouteWork)
            {
                IPEndPoint client = null;
                byte[] data = serveur.Receive(ref client);

                string message = Encoding.Default.GetString(data);
                if (message != "")
                {
                    MessageBox.Show(message);
                }
            }
        }*/

        private void Ecouter()
        {
            TcpListener listener = new TcpListener(GetLocalIPAddress(), 5035);
            int countTransaction = 0;
            listener.Start();

            while (thEcouteWork)
            {
                this.Invoke((MethodInvoker)(() => listBox1.Items.Add("coucou"))); // comment modifier un composant sur le thread principal depuis un autre thread

                Socket sock = listener.AcceptSocket();
                sockets.Add(sock);
                MessageBox.Show("Connection accepted from " + sock.RemoteEndPoint);
                countTransaction++;

                byte[] byteMsg = new byte[1000];
                int k = sock.Receive(byteMsg);
                msg = "";
                for (int i = 0; i < k; i++)
                {
                    msg += Convert.ToChar(byteMsg[i]);
                }

                MessageBox.Show(msg);

                ASCIIEncoding asen = new ASCIIEncoding();
                sock.Send(asen.GetBytes("The string was recieved by the server. " + countTransaction.ToString()));
            }
        }
       
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            thEcoute.Abort();
        }

        /// <summary>
        /// Active ou désactive l'écoute du serveur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (thEcoute.ThreadState == ThreadState.Running)
            {
                thEcouteWork = false;
                thEcoute.Suspend();
                lblStatutServeur.Text = "Désactivé";               
            }
            else
            {
                thEcouteWork = true;
                thEcoute.Resume();
                lblStatutServeur.Text = "Activé";
            }
        }

        private void map1_Click(object sender, EventArgs e)
        {

        }
    }
}
