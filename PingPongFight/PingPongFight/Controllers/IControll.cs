using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using PingPongFight.GameObjects;

namespace PingPongFight.Controllers
{
    public interface IControll
    {
        Ball Ball { get; set; }
        PongBat Bat { get; set; }

        void Update(GameTime gameTime);
    }
}
