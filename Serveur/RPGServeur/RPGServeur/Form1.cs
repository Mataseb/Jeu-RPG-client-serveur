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

namespace RPGServeur
{
    public partial class Form1 : Form
    {
        //objet permettant d'écouter les demandes de connexion.
        TcpListener listener = new TcpListener(IPAddress.Parse(GetLocalIPAddress()), 1024);
        //vrai si "listener" est en écoute et faux si "listener" n'est pas en écoute.
        bool DoListenerListen;

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Récupère l'addresse ip de la machine courante
        /// </summary>
        /// <returns>Adresse ip</returns>
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

        private void Form1_Load(object sender, EventArgs e)
        {
            listener.Start();
            DoListenerListen = true;
            lblStatutServeur.Text = "Statut: Activé";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            listener.Stop();
            DoListenerListen = false;
        }

        /// <summary>
        /// Active ou désactive l'écoute du serveur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (DoListenerListen)
            {
                listener.Stop();
                DoListenerListen = false;
                lblStatutServeur.Text = "Statut: Désactivé";
                btnActiver.Text = "Activer";
            }
            else
            {
                listener.Start();
                DoListenerListen = true;
                lblStatutServeur.Text = "Statut: Activé";
                btnActiver.Text = "Désactiver";
            }
        }
    }
}
