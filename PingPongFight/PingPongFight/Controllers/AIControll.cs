using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using PingPongFight.GameObjects;

namespace PingPongFight.Controllers
{
    public class AIControll:IControll
    {
        public Ball Ball
        {
            get;
            set;
        }

        public PongBat Bat
        {
            get;
            set;
        }

        public AIControll(Ball ball)
        {
            Ball = ball;
        }


        public void Update(GameTime gameTime)
        {
            Bat.MoveTo(new Vector2(Bat.CenterPosition.X, Ball.CenterPosition.Y));
        }
    }
}
