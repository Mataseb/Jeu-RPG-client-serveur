using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPGServeur
{
    class BaseGame
    {
        Map map;
        List<Player> players;

        public BaseGame()
        {
            map = new Map();
            players = new List<Player>();
        }
    }
}
