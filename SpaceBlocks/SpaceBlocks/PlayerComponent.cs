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
    public class PlayerComponent : SquareGameComponent
    {
        public PlayerComponent(Game game)
            : base(game, null)
        { }

        protected override string GetTextureName()
        {
            return "Player1";
        }

        public override void Initialize()
        {
            base.Initialize();
            Position = new Vector2((int)(GetGame().ScreenWidth / 2), GetGame().ScreenHeight - 100);         
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                Position = new Vector2(Position.X - 600 * (float)gameTime.ElapsedGameTime.TotalSeconds, Position.Y);
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                Position = new Vector2(Position.X + 600 * (float)gameTime.ElapsedGameTime.TotalSeconds, Position.Y);
            base.Update(gameTime);
        }
   }
}
