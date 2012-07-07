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

    public class PongBat :GameObject
    {
        public float Speed { get; set; }

        private Vector2 NextPosition;

        public PongBat(Game game, SpriteBatch spriteBatch, Texture2D texture)
            : base(game, spriteBatch, texture)
        {

        }

        public void MoveTo(Vector2 position)
        {
            NextPosition = position;
        }

        public override void Initialize()
        {

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            CenterX = MovingTowards(CenterX, NextPosition.X, dt);
            CenterY = MovingTowards(CenterY, NextPosition.Y, dt);

            base.Update(gameTime);
        }

        private float MovingTowards(float x1,float x2, float dt)
        {
            if(x1 < x2)
            {
                x1 += Speed * dt;
                if (x1 > x2)
                    x1 = x2;
            }
            if (x1 > x2)
            {
                x1 -= Speed * dt;
                if (x1 < x2)
                    x1 = x2;
            }
            return x1;
        }
    }
}
