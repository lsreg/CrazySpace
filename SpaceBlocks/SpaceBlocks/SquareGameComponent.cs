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
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public abstract class SquareGameComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public Vector2 Position { get; set; }

        public int Width { get; set; }
        
        public int Height { get; set; }

        protected Texture2D texture;
        
        protected Screen gameScreen;

        public SquareGameComponent(Game game, Screen screen)
            : base(game)
        {
            this.gameScreen = screen;
        }

        protected abstract string GetTextureName();

        protected Game1 GetGame()
        {
            return Game as Game1;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (Position.X < 0)
                Position = new Vector2(0, Position.Y);
            if (Position.X > GetGame().ScreenWidth - Width)
                Position = new Vector2(GetGame().ScreenWidth - Width, Position.Y);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            GameResources.SpriteBatch.Begin();
            GameResources.SpriteBatch.Draw(texture, Position, Color.White);
            GameResources.SpriteBatch.End();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            texture = this.Game.Content.Load<Texture2D>(GetTextureName());
            Width = texture.Width;
            Height = texture.Height;
        }
    }
}
