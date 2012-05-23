using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceBlocks
{
    class GameScreen : Screen
    {
        private TimeSpan lastBrickCreationTime = new TimeSpan(0);

        public GameScreen(Game1 game)
            : base(game)
        { }

        public override void OnActivate()
        {
            base.OnActivate();
            (this.Game as Game1).Points = 0;
        }

        protected override void CreateComponents()
        {
            Components.Add(new PlayerComponent(this.Game));
            Components.Add(new PointsGameComponent(this.Game));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            ProcessIntersections();

            if (gameTime.TotalGameTime.TotalMilliseconds - lastBrickCreationTime.TotalMilliseconds > 400)
            {
                Components.Add(new EnemyComponent(this.Game, this));
                lastBrickCreationTime = gameTime.TotalGameTime;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
        }

        public void GameOver()
        {
            GameComponentCollection bricks = new GameComponentCollection();

            foreach (GameComponent component in Components)
            {
                if (component is EnemyComponent)
                    bricks.Add(component);
            }

            foreach (GameComponent brick in bricks)
            {
                Components.Remove(brick);
                Game.Components.Remove(brick);
            }

            (this.Game as Game1).ScreenMgr.ActivateScreen(2);
        }

        public void ProcessBrickDestruction(EnemyComponent enemy)
        {
            (Game as Game1).Points++;
            Components.Remove(enemy);
            Game.Components.Remove(enemy);
        }

        public void ProcessIntersections()
        {
            for (int i = 0; i < Components.Count - 1; i++)
            {
                if (Components[i] is SquareGameComponent)
                {
                    for (int j = i + 1; j < Components.Count; j++)
                    {
                        if (Components[j] is SquareGameComponent)
                        {
                            Rectangle firstRec = new Rectangle((int)(Components[i] as SquareGameComponent).Position.X, (int)(Components[i] as SquareGameComponent).Position.Y,
                                (Components[i] as SquareGameComponent).Width, (Components[i] as SquareGameComponent).Height);
                            Rectangle secondRec = new Rectangle((int)(Components[j] as SquareGameComponent).Position.X, (int)(Components[j] as SquareGameComponent).Position.Y,
                                (Components[j] as SquareGameComponent).Width, (Components[j] as SquareGameComponent).Height);
                            if (firstRec.Intersects(secondRec))
                            {
                                if ((Components[i] is PlayerComponent) || (Components[j] is PlayerComponent))
                                    GameOver();
                                else
                                {
                                    Vector2 oldISpeed = (Components[i] as EnemyComponent).Speed;
                                    Vector2 oldJSpeed = (Components[j] as EnemyComponent).Speed;
                                    (Components[i] as EnemyComponent).Speed = oldJSpeed;
                                    (Components[j] as EnemyComponent).Speed = oldISpeed;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
