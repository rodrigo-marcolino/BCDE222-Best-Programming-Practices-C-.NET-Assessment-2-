using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Linq;

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
		public int MoveCount;
		public bool HasMinotaurWon;
		public bool HasTheseusWon;


		public Game()
		{
			this.LevelHeight = 0;
			this.LevelWidth = 0;
			this.CurrentLevelName = "No levels loaded";
			this.LevelCount = 0; 
			this.LevNames = new List<string>();
			this.MoveCount = 0;
			this.HasMinotaurWon = false;
			this.HasTheseusWon = false;
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
			MinotaurWon();
			TheseusWon();

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

        public void MoveTheseus(Moves move)
        {
			//where is theseus  
			int[] theseus = CurrentLevel.GetTheseus();
			//what is the new square theseus is moving to
			//get current x y of theseus 
			//depending on direction plus or minus from the x y values
			int x = theseus[1];
			int y = theseus[0];
			bool canMove = false;
			Square origin = WhatIsAt(y, x);
			//can theseus move to that square
			//if wall is blocking theseus cannot move
			//else move theseus
			switch (move) 
			{
				case Moves.UP:
					if (!origin.Top)
					{
						y -= 1;
						canMove = true;
					}
					break;
				case Moves.DOWN:
					if (!origin.Bottom)
					{
						y += 1;
						canMove = true;
					}
					break;
				case Moves.LEFT:
					if (!origin.Left)
					{
						x -= 1;
						canMove = true;
					}
					break;
				case Moves.RIGHT:
					if (!origin.Right)
					{
						x += 1;
						canMove = true;
					}
					break;
				case Moves.PAUSE:
					this.MoveCount++;
					break;
			
            }
			//use what is at method to select new square for theseus 
			//add one to move count 
			if (canMove)
            {
				Square destination = WhatIsAt(y, x);
				CurrentLevel.theseus = new int[] { y, x };
				origin.Theseus = false;
				destination.Theseus = true;
				this.MoveCount++;
			}
			TheseusWon();

		}
		//figure out what way the minotaur needs to move 
		//minotaur always move towards theseus 
		// create variable that will hold the move
		// set x and y of minotaur like i did with theseus
		public void MoveMinotaur()
        {
			int[] minotaur = CurrentLevel.GetMinotaur();
			int x = minotaur[1];
			int y = minotaur[0];
			bool canMove = false;
			Square origin = WhatIsAt(y, x);
			Moves move = Moves.PAUSE;

			int[] theseusLocat = CurrentLevel.GetTheseus();
			// find the difference of theseus x and minotaur x
			// find the difference between theseus y and theseus x
			// if number is above 0 set move as right,
			// if number is below 0 set move as left
			if (theseusLocat[1] - minotaur[1] != 0)
			{
				if (theseusLocat[1] - minotaur[1] < 0)
				{
					move = Moves.LEFT;
				}
				else move = Moves.RIGHT;
			}
			// if number is above 0 set move as down
			// if number is below 0 set move as up
			else if (theseusLocat[0] - minotaur[0] != 0)
			{
				if (theseusLocat[0] - minotaur[0] < 0)
				{
					move = Moves.UP;
				}
				else move = Moves.DOWN;
			}
			switch (move)
			{
				case Moves.UP:
					if (!origin.Top)
					{
						y -= 1;
						canMove = true;
					}
					break;
				case Moves.DOWN:
					if (!origin.Bottom)
					{
						y += 1;
						canMove = true;
					}
					break;
				case Moves.LEFT:
					if (!origin.Left)
					{
						x -= 1;
						canMove = true;
					}
					break;
				case Moves.RIGHT:
					if (!origin.Right)
					{
						x += 1;
						canMove = true;
					}
					break;

			}
			if (canMove)
			{
				Square destination = WhatIsAt(y, x);
				CurrentLevel.minotaur = new int[] { y, x };
				origin.Minotaur = false;
				destination.Minotaur = true;
			}
			MinotaurWon();

		}
		//is the minotaur and theseus in the same square
		//if yes minotaur has won
		//this is a check method and needs to be called after the minotaur moves
		public void MinotaurWon()
		{ 
			int[] theseus = CurrentLevel.GetTheseus();
			int[] minotaur = CurrentLevel.GetMinotaur();

			if (theseus.SequenceEqual(minotaur))
            {
				this.HasMinotaurWon = true;
            }
        }
		public void TheseusWon()
        {
			int[] theseus = CurrentLevel.GetTheseus();
			int[] exit = CurrentLevel.GetExit();

			if (exit.SequenceEqual(theseus))
			{
				this.HasTheseusWon = true;
			}
		}

	}

}
