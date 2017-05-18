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

        #region propriétés
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
        #endregion

        public Player(int id, string username, IPAddress ip, Point position)
        {
            this._id = id;
            this._username = username;
            this._ip = ip;
            this._position = position;
        }

        #region déplacements du joueur
        public void MoveUp()
        {
            _position.Y -= 1;
        }

        public void MoveDown()
        {
            _position.Y += 1;
        }

        public void MoveRight()
        {
            _position.X += 1;
        }

        public void MoveLeft()
        {
            _position.X -= 1;
        }
        #endregion
    }
}
