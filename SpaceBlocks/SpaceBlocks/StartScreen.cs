using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SpaceBlocks
{
    public class StartScreen : Screen
    {
        public StartScreen(Game game)
            : base(game)
        { }

        protected override void CreateComponents()
        { }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                (this.Game as Game1).ScreenMgr.ActivateScreen(1);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            GameResources.SpriteBatch.Begin();
            GameResources.SpriteBatch.DrawString(GameResources.TextFont, "Welcome to crazy space" + Environment.NewLine + "Press Enter to start new game",
                new Vector2(20, 20), Color.White);
            GameResources.SpriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
