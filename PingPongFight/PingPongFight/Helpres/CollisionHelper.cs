using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using PingPongFight.GameObjects;

namespace PingPongFight.Helpres
{
    static public class CollisionHelper
    {
        static public List<GameObject> GameObjects = new List<GameObject>();

        static public void Update(GameTime gameTime)
        {
            foreach (var gameObject in GameObjects)
            {
                foreach (var o in GameObjects.Where(o => o != gameObject))
                {
                    gameObject.CheckHit(o.BoundsRectangle);
                }
            }
        }
    }
}
