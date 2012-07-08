using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PingPongFight.GUI
{
    class StatusBar:GUIElement
    {
        protected Texture2D Texture;

        public bool Flip { get; set; }

        public float Progress 
        {
            get;
            set;
        }

        public StatusBar(Texture2D texture)
        {
            Texture = texture;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Draw(Texture, new Rectangle((int)X,(int)Y,(int)(Width * Progress),(int)(Height * Progress)),
                                      new Rectangle(0,0, (int)(Texture.Width * Progress), Texture.Height),Color.White );
        }
    }
}
