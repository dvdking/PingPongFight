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
using PingPongFight.Controllers;


namespace PingPongFight.GameObjects
{

    public class PongBat :GameObject
    {
        public IControll Control { get; set; }
    

        public float Speed { get; set; }

        public Vector2 NextPosition;
        public bool DoNotAllowChangePositionUntilNextPositionReached = false;

        public PongBat(Game game, SpriteBatch spriteBatch, Texture2D texture)
            : base(game, spriteBatch, texture)
        {

        }

        public void SetControll(IControll control)
        {
            Control = control;
            control.Bat = this;
        }

        public void MoveTo(Vector2 position)
        {
            if(!DoNotAllowChangePositionUntilNextPositionReached)
                NextPosition = position;
        }

        public override void Initialize()
        {

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            float dt = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            Control.Update(gameTime);

            CenterX = MovingTowards(CenterX, NextPosition.X, dt);
            CenterY = MovingTowards(CenterY, NextPosition.Y, dt);
            if(NextPosition == CenterPosition)
            {
                DoNotAllowChangePositionUntilNextPositionReached = false;
            }

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
