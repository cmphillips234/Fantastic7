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
    abstract class GSprite{}

    class SSprite : GSprite
    {

        public SSprite()
        {
            
        }
        
    }

    class NSprite : GSprite
    {
        protected Rectangle _r;
        protected Color _c;
        protected Texture2D _t;
        void draw(SpriteBatch sb, float scale) { sb.Draw(_t, _r, _c); }
        public NSprite(Rectangle r, Color c, Texture2D t) { _r = r; _c = c; _t = t; }
    }
}
