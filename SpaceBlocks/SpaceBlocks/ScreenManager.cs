using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceBlocks
{
    public class ScreenManager
    {
        private List<Screen> screens;
        private int activeScreenIndex = -1;
        private bool started = false;

        public ScreenManager()
        {
            screens = new List<Screen>();        
        }

        public void ActivateScreen(int screenIndex)
        {
            if (!started)
                throw new Exception("Game is not started yet.");
            if ((screenIndex < 0) || (screenIndex > screens.Count - 1))
                throw new Exception("Invalid screen index.");

            if (screenIndex != activeScreenIndex)
            {
                if (activeScreenIndex > -1)                
                    screens[activeScreenIndex].Deactivate();                                
                activeScreenIndex = screenIndex;
                screens[activeScreenIndex].Activate();            
            }        
        }

        public void AddScreen(Screen screen)
        {
            if (started)
                throw new Exception("Game is already started");
            if (screens.IndexOf(screen) == -1)
                screens.Add(screen);        
        }

        public void StartFromScreen(int screenIndex)
        {
            if (started)
                throw new Exception("Game is already started");
            started = true;
            activeScreenIndex = screenIndex;
            screens[activeScreenIndex].Activate();        
        }
    }
}
