using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.IO.IsolatedStorage;

namespace SpaceBlocks
{
    class GameOverScreen : Screen
    {
        public GameOverScreen(Game game)
            : base(game)
        { }

        protected override void CreateComponents()
        {
            this.Components.Add(new TotalPointsGameComponent(this.Game));        
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
        }
    }

    public class TotalPointsGameComponent : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private string highScoresFileName = "hscr.dat";

        private string bottomText = "developing: ls.izhevsk@gmail.com" + Environment.NewLine + "music: Mister Beep";

        private int highScores;

        private int gamePoints;

        public TotalPointsGameComponent(Game game)
            : base(game)
        { }

        public override void Initialize()
        {
            base.Initialize();
            highScores = LoadHighScores();
            gamePoints = (Game as Game1).Points;
            if (gamePoints > highScores)
            {
                highScores = gamePoints;
                SaveHighScores(highScores);
            }
        }

        private int LoadHighScores()
        {
            int highScores = 0;
            if (GameResources.BestPointsStorage.FileExists(highScoresFileName))
            {
                using (IsolatedStorageFileStream fs = GameResources.BestPointsStorage.OpenFile(highScoresFileName, System.IO.FileMode.Open))
                {
                    if (fs != null)
                    {
                        byte[] saveBytes = new byte[4];
                        int count = fs.Read(saveBytes, 0, 4);
                        if (count > 0)                        
                            highScores = System.BitConverter.ToInt32(saveBytes, 0);
                    }
                }
            }
            return highScores;        
        }

        private void SaveHighScores(int highScores)
        {
            IsolatedStorageFileStream fs = null;
            using (fs = GameResources.BestPointsStorage.CreateFile(highScoresFileName))
            {
                if (fs != null)
                {
                    byte[] bytes = System.BitConverter.GetBytes(highScores);
                    fs.Write(bytes, 0, bytes.Length);
                }
            }        
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GameResources.SpriteBatch.Begin();
            GameResources.SpriteBatch.DrawString(GameResources.TextFont, String.Format("Total Points: {0}" + Environment.NewLine +
                "High Scores: {1}" + Environment.NewLine + "Press Enter to start new game", new object[] {gamePoints, highScores}), 
                new Vector2(20, 20), Color.White);
            GameResources.SpriteBatch.DrawString(GameResources.TextFont, bottomText, 
                new Vector2(20, 700), Color.White);            
            GameResources.SpriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                (this.Game as Game1).ScreenMgr.ActivateScreen(1);            
        }
    }

}
