using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PingPongFight.GUI
{
    public class GUIControl
    {
        private readonly List<GUIElement> guiElements;
        protected SpriteBatch SpriteBatch;

        public GUIControl(SpriteBatch spriteBatch)
        {
            SpriteBatch = spriteBatch;
            guiElements = new List<GUIElement>();
        }
        public void Add(GUIElement element)
        {
            element.GuiControll = this;
            element.SpriteBatch = SpriteBatch;
            guiElements.Add(element);
        }
        public void Update(GameTime gameTime)
        {
            foreach (var element in guiElements)
            {
                element.Update(gameTime);
            }
        }
        public void Draw(GameTime gameTime)
        {
            foreach (var element in guiElements)
            {
                element.Draw(gameTime);
            }
        }
    } 
}
