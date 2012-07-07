using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PingPongFight.Helpres
{
    static public class RandomHelper
    {
        public static readonly Random Random = new Random();

        static public Vector2 GetRandomDirection()
        {
            Vector2 vec = new Vector2(NextFloat() * GetRandomSign(), NextFloat() * GetRandomSign());
            vec.Normalize();
            return vec;
        }

        static public int GetRandomSign()
        {
            return Random.NextDouble() > 0.5? 1:-1;
        }

        static public float NextFloat()
        {
            return (float) Random.NextDouble();
        }
    }
}
