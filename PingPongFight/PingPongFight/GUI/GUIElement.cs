using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PingPongFight.GUI
{
    public abstract class GUIElement
    {
        internal GUIControl GuiControll;
        internal SpriteBatch SpriteBatch;
        private float _x;
        private float _y;

        public int Width { get; set; }
        public int Height { get; set; }

        public float X
        {
            get
            {
                return _x;
            }
            protected set
            {
                _x = value;
            }
        }
        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public Vector2 Position
        {
            get
            {
                return new Vector2(_x, _y);
            }
            set
            {
                _x = value.X;
                _y = value.Y;
            }
        }

        public float CenterX
        {
            get { return _x + Width / 2; }
            set { _x = value - Width / 2; }
        }
        public float CenterY
        {
            get { return _y + Height / 2; }
            set { _y = value - Height / 2; }
        }


        public Vector2 CenterPosition
        {
            get
            {
                return new Vector2(_x + Width / 2, _y + Height / 2);
            }
            set
            {
                _x = value.X - Width / 2;
                _y = value.Y - Height / 2;
            }
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);
    }
}
