using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using PingPongFight.GameObjects;

namespace PingPongFight.Controllers
{
    class GamerControll:IControll
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

        public GamerControll(Ball ball)
        {
            Ball = ball;
        }


        public void Update(GameTime gameTime)
        {
            TouchCollection touchCollection = TouchPanel.GetState();
            foreach (TouchLocation tl in touchCollection)
            {
                if ((tl.State == TouchLocationState.Pressed)
                        || (tl.State == TouchLocationState.Moved))
                {
                    Bat.MoveTo(new Vector2(Bat.CenterX, tl.Position.Y));
                }
            }
        }
    }
}
