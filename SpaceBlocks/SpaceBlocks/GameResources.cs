using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;
using System.IO.IsolatedStorage;

namespace SpaceBlocks
{
    class GameResources
    {
        public static GraphicsDeviceManager GraphicsDeviceManager { get; set; }

        public static SpriteBatch SpriteBatch { get; set; }

        public static IsolatedStorageFile BestPointsStorage { get; set; }

        public static SpriteFont TextFont { get; set; }            
    }
}
