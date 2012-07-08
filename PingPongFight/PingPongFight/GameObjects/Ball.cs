using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PingPongFight.GameObjects
{
    public class Ball:GameObject
    {
        public int MinHeight, MaxHeight;

        public Vector2 Direction { get; set; }
        public float Speed { get; set; }

        protected Vector2 Velocity { get; set; }


        public Ball(Game game, SpriteBatch spriteBatch, Texture2D texture) 
            : base(game, spriteBatch, texture)
        {
        }

        public override void CheckHit(Rectangle bound)
        {
            if(!BoundsRectangle.Intersects(bound)) return;

                Direction = new Vector2(-Direction.X, Direction.Y);

        }

        public override void Update(GameTime gameTime)
        {
            if(Y + Width > MaxHeight || Y < MinHeight)
            {
                Direction = new Vector2(Direction.X, -Direction.Y);
            }

            Velocity = Direction*Speed*gameTime.ElapsedGameTime.Milliseconds;
            Position += Velocity;
            base.Update(gameTime);
        }



    }
}
