using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RPGServeur
{
    class Player
    {
        private int _id;
        private string _username;
        private IPAddress _ip;
        private Point _position;

        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }

        public IPAddress Ip
        {
            get
            {
                return _ip;
            }

            set
            {
                _ip = value;
            }
        }

        public Point Position
        {
            get
            {
                return _position;
            }

            set
            {
                _position = value;
            }
        }

        public Player(int id, string username, IPAddress ip, Point position)
        {
            this._id = id;
            this._username = username;
            this._ip = ip;
            this._position = position;
        }
    }
}
