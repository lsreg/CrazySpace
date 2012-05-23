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
    public class EnemyComponent : SquareGameComponent
    {
        public Vector2 Speed { get; set; }

        public EnemyComponent(Game game, Screen screen)
            : base(game, screen)
        { }
        
        protected override string GetTextureName()
        {
            return "Enemy1";        
        }

        public override void Initialize()
        {
            base.Initialize();
            Position = new Vector2((Game as Game1).GameRandom.Next(GetGame().ScreenWidth - 50), 0);
            Speed = new Vector2(20 * ((Game as Game1).GameRandom.Next(70) - 35), 20 * ((Game as Game1).GameRandom.Next(10) + 13));
        }

        public override void Update(GameTime gameTime)
        {
            Position = new Vector2(Position.X + Speed.X * (float)gameTime.ElapsedGameTime.TotalSeconds, 
                Position.Y + Speed.Y * (float)gameTime.ElapsedGameTime.TotalSeconds);
        
            if (Position.X <= 0)
                Speed = new Vector2(-Speed.X, Speed.Y);

            if (Position.X >= GetGame().ScreenWidth - Width)
                Speed = new Vector2(-Speed.X, Speed.Y);

            if (Position.Y >= GetGame().ScreenHeight)
                (gameScreen as GameScreen).ProcessBrickDestruction(this);            

            base.Update(gameTime);
        }
    }
}
