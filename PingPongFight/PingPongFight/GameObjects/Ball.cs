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
        public int MinHeight, MaxHeight, MaxWidth;

        public float Countdown;
        protected float Elapsed;


        public Vector2 StartPosition { get; set; }
        public Vector2 Direction { get; set; }
        public float Speed { get; set; }

        protected Vector2 Velocity { get; set; }


        public Ball(Game game, SpriteBatch spriteBatch, Texture2D texture) 
            : base(game, spriteBatch, texture)
        {
          //  Reset();
        }

        public override void CheckHit(Rectangle bound)
        {
            if(!BoundsRectangle.Intersects(bound)) return;

                Direction = new Vector2(-Direction.X, Direction.Y);

        }

        public void Reset()
        {
            CenterPosition = StartPosition;
            Elapsed = Countdown;
        }

        public override void Update(GameTime gameTime)
        {
            if (Elapsed <= 0.0f)
            {
                if (Y + Width > MaxHeight || Y < MinHeight)
                {
                    Direction = new Vector2(Direction.X, -Direction.Y);
                }

                Velocity = Direction*Speed*gameTime.ElapsedGameTime.Milliseconds;
                Position += Velocity;

                if(X + Width > MaxWidth || X < 0)
                {
                    Direction = new Vector2(-Direction.X, Direction.Y);
                }

            }
            else
            {
                Elapsed -= gameTime.ElapsedGameTime.Milliseconds;
            }
            base.Update(gameTime);
        }



    }
}
