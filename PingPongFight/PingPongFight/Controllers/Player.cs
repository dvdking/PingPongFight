using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PingPongFight.GameObjects;

namespace PingPongFight.Controllers
{
    public class Player
    {
        public float Health { get; set; }
        public bool Alive
        {
            get { return Health > 0; }
        }

        protected PongBat Bat;

        public Player(PongBat bat)
        {
            Bat = bat;
            Health = 100;
        }

        public void Update(GameTime gameTime)
        {
            Bat.Update(gameTime);
        }
        public void Draw(GameTime gameTime)
        {
            Bat.Draw(gameTime);
        }

    }
}
