using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using PingPongFight.GameObjects;
using PingPongFight.Helpres;

namespace PingPongFight
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private PongBat playerOne;
        private Ball ball;
        private Texture2D ballTexture;
        private Texture2D playerOneTexture;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            // Extend battery life under lock.
            InactiveSleepTime = TimeSpan.FromSeconds(1);
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            playerOneTexture = Content.Load<Texture2D>("PlayerOneBat");
            ballTexture = Content.Load<Texture2D>("BallTexture");
            playerOne = new PongBat(this, spriteBatch, playerOneTexture) {Speed = 0.3f};
            ball = new Ball(this, spriteBatch, ballTexture)
                       {
                           Position = new Vector2(450,150),
                           Direction = RandomHelper.GetRandomDirection(),
                           Speed = 0.1f,
                           MaxHeight = 200
                       };
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            TouchCollection touchCollection = TouchPanel.GetState();
            foreach (TouchLocation tl in touchCollection)
            {
                if ((tl.State == TouchLocationState.Pressed)
                        || (tl.State == TouchLocationState.Moved))
                {
                    playerOne.MoveTo(tl.Position);
                }
            }

            playerOne.Update(gameTime);
            ball.Update(gameTime);

            ball.CheckHit(playerOne.BoundsRectangle);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            playerOne.Draw(gameTime);
            ball.Draw(gameTime);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
