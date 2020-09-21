using System;
using System.Collections.Generic;
using System.Text;

namespace TaM
{
    interface ILevelHolder
    {
        public void AddLevel(string name, int width, int height, string data);
        public int LevelCount { get; }
        public string CurrentLevelName { get; }
        public int LevelWidth { get; }
        public int LevelHeight { get; }
        public List<string> LevelNames();
        public void SetLevel(string name);
    }
}


