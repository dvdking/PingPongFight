using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace PingPongFight.GameObjects
{
    public class GameObject : Microsoft.Xna.Framework.DrawableGameComponent
    {

        protected Texture2D Texture;
        protected SpriteBatch SpriteBatch;

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
                return new Vector2(_x,_y);
            }
            set 
            { 
                _x = value.X;
                _y = value.Y;
            }
        }

        public float CenterX
        {
            get { return _x + Width/2; }
            set { _x = value - Width/2; }
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
                return new Vector2(_x + Width/2, _y + Height/2);
            }
            set 
            {
                _x = value.X - Width / 2;
                _y = value.Y - Height/2;
            }
        }

        

        public Rectangle BoundsRectangle
        {
           get {return new Rectangle((int)X,(int)Y,Width,Height);}
        }

        public GameObject(Game game, SpriteBatch spriteBatch, Texture2D texture)
            : base(game)
        {
            SpriteBatch = spriteBatch;
            Texture = texture;
            Width = texture.Width;
            Height = texture.Height;
        }

        public virtual void CheckHit(Rectangle bound)
        {
        }

        public override void Draw(GameTime gameTime)
        {
            if(!Visible) return;

            SpriteBatch.Draw(Texture, Position,Color.White);

            base.Draw(gameTime);
        }
    }
}
