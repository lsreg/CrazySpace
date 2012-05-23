using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Collections.ObjectModel;

namespace SpaceBlocks
{
    public abstract class Screen : DrawableGameComponent
    {
        public Collection<GameComponent> Components;

        public Screen(Game game) : base(game)
        {
            Components = new Collection<GameComponent>();
        }

        protected void AddComponentsToGame()
        {
            foreach (GameComponent component in Components)
            {
                if (this.Game.Components.IndexOf(component) < 0)
                    this.Game.Components.Add(component);
            }        
        }

        public override void Update(GameTime gameTime)
        {
            AddComponentsToGame();
            base.Update(gameTime);
        }

        public void Activate()
        {
            OnActivate();
            this.Game.Components.Clear();
            this.Game.Components.Add(this);
            foreach (GameComponent component in Components)
                this.Game.Components.Add(component);            
        }

        public void Deactivate()
        {
            foreach (GameComponent component in Components)
                if (this.Game.Components.IndexOf(component) >= 0)
                    this.Game.Components.Remove(component);
            if (this.Game.Components.IndexOf(this) >= 0)
                this.Game.Components.Remove(this);
            OnDeactivate();
        }

        protected abstract void CreateComponents();

        public virtual void OnActivate()
        {
            CreateComponents();        
        }

        public virtual void OnDeactivate()
        {
            this.Components.Clear();
        }
    }
}
