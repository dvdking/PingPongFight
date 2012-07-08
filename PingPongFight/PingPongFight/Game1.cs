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
using PingPongFight.Controllers;
using PingPongFight.GameObjects;
using PingPongFight.Helpres;

namespace PingPongFight
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Player playerOne;
        private Player playerTwo;
        private Ball ball;
        private Texture2D ballTexture;
        private Texture2D playerOneTexture;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft;
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
            PongBat batOne = new PongBat(this, spriteBatch, playerOneTexture) {Speed = 0.3f};
            PongBat batTwo = new PongBat(this, spriteBatch, playerOneTexture) { Speed = 0.3f, Position = new Vector2(300, 150) };
            ball = new Ball(this, spriteBatch, ballTexture)
                       {
                           Position = new Vector2(450,150),
                           Direction = RandomHelper.GetRandomDirection(),
                           Speed = 0.1f,
                           MaxHeight = 200,
                       };

            batOne.SetControll(new GamerControll(ball));
            batTwo.SetControll(new AIControll(ball));

            playerOne = new Player(batOne);
            playerTwo = new Player(batTwo);

            CollisionHelper.GameObjects.Add(batOne);
            CollisionHelper.GameObjects.Add(batTwo);
            CollisionHelper.GameObjects.Add(ball);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            playerOne.Update(gameTime);
            playerTwo.Update(gameTime);
            ball.Update(gameTime);

            CollisionHelper.Update(gameTime);
            //ball.CheckHit(playerOne.BoundsRectangle);
            //ball.CheckHit(playerTwo.BoundsRectangle);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            playerOne.Draw(gameTime);
            playerTwo.Draw(gameTime);
            ball.Draw(gameTime);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
