using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Fantastic7
{
    public class Room
    {
        public Room left;
        public Room right;
        public Room up;
        public Room down;
        private Color _main;
        private Color _sec;
        private Texture2D plainText;

        public Room(Color main, Color sec, Texture2D pt, Room r = null, Room u = null, Room l = null, Room d = null)
        {
            right = r;
            up = u;
            left = l;
            down = d;
            plainText = pt;
            _main = main;
            _sec = sec;
        }

        public void setText(Texture2D text)
        {
            plainText = text;
        }

        public void Draw(SpriteBatch sb, float scale)
        { 
            sb.Draw(plainText, new Rectangle(0, 0, 1280, 720), _main);
            sb.Draw(plainText, new Rectangle(128, 72, 1024, 576), _sec);
        }
    }
}
