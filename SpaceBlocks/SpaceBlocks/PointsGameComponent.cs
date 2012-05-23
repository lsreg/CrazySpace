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


namespace SpaceBlocks
{
    public class PointsGameComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public PointsGameComponent(Game game)
            : base(game)
        { }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GameResources.SpriteBatch.Begin();
            GameResources.SpriteBatch.DrawString(GameResources.TextFont, String.Format("Points: {0}", (Game as Game1).Points), new Vector2(20, 20), Color.White);
            GameResources.SpriteBatch.End();
        }
    }
}
