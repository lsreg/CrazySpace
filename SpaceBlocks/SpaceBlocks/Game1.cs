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
using System.IO.IsolatedStorage;

namespace SpaceBlocks
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {        
        public int Points{ get; set; }

        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }

        public ScreenManager ScreenMgr { get; set; }
        public Random GameRandom = new Random();

        public Game1()
        {
            ScreenWidth = 1024;
            ScreenHeight = 768;

            GameResources.GraphicsDeviceManager = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            ScreenMgr = new ScreenManager();

            ScreenMgr.AddScreen(new StartScreen(this));
            ScreenMgr.AddScreen(new GameScreen(this));
            ScreenMgr.AddScreen(new GameOverScreen(this));

            GameResources.GraphicsDeviceManager.PreferredBackBufferWidth = ScreenWidth; // ширина
            GameResources.GraphicsDeviceManager.PreferredBackBufferHeight = ScreenHeight; // высота
            
            GameResources.BestPointsStorage = IsolatedStorageFile.GetUserStoreForDomain();

            ScreenMgr.StartFromScreen(0);
        }

        protected override void Initialize()
        {
            base.Initialize();
            GameResources.SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void LoadContent()
        {
            GameResources.TextFont = Content.Load<SpriteFont>("PointsFont");
            Song song = Content.Load<Song>("Music");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(song);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
        }
    }
}
