using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace TaM
{
	public class Game : ILevelHolder
	{
		public int LevelHeight { get; set; } 
		public int LevelWidth { get; set; }
		public string CurrentLevelName { get; set; }
		public int LevelCount { get; set; }
		private List<string> LevNames;
		private Level CurrentLevel;

        public Game()
		{
			this.LevelHeight = 0;
			this.LevelWidth = 0;
			this.CurrentLevelName = "No levels loaded";
			this.LevelCount = 0; 
			this.LevNames = new List<string>();
		}
		public List<string> LevelNames()
		{
			return this.LevNames;
		}


        public void AddLevel(string name, int width, int height, string data)
        {
			this.CurrentLevelName = name;
			this.LevelWidth = width;
			this.LevelHeight = height;
			this.LevelCount += 1;
			this.LevNames.Add(name);
			Level Level = new Level(name, width, height, data);
			CurrentLevel = Level;
        }
		
		public Square WhatIsAt(int x, int y)
        {
			Square square = this.CurrentLevel.allMySquares[x, y];
			return square;

        }

		public void SetLevel(string name)
        {
			
			// check if name = LevNames
			// loop through each name in list
			foreach (string levelName in this.LevNames) {
				if (levelName == name)
                {
					this.CurrentLevelName = name;
				}
            }
        }
		 
		

	}

}
