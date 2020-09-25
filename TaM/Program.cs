using System;

namespace TaM
{
	class Program
	{
		static void Main(string[] args)
		{
			Game game = new Game();
			Console.WriteLine("** Empty game");
			Console.WriteLine($"Levels: {game.LevelCount}");
			Console.WriteLine($"CurrentLevel: {game.CurrentLevelName}.{ game.LevelWidth}x { game.LevelHeight}\n");

			string data = "0000 0001 0002 1011 1010 1110";
			game.AddLevel("*** simple game", 3, 1, data);
			Console.WriteLine($"CurrentLevel: {game.CurrentLevelName}.{ game.LevelWidth}x { game.LevelHeight}");
			Console.WriteLine(game);

			data = "0001 0201 0103";
			data += " 1001 1010 1100 0001";
			data += " 0001 1110 0001 1010";
			data += " 0011 1010 0110 1011";
			game.AddLevel("*** complex game", 4, 3, data);
			Console.WriteLine($"CurrentLevel: {game.CurrentLevelName}.{ game.LevelWidth}x { game.LevelHeight}");
			Console.WriteLine(game);

			game.AddLevel("ThesesusIn3by3", 3, 3,
							"0000 0101 0202"
							+ " 1111 1001 1100"
							+ " 1001 0000 0100"
							+ " 0011 0010 0110");
			Console.WriteLine($"CurrentLevel: {game.CurrentLevelName}.{ game.LevelWidth}x { game.LevelHeight}");
			Console.WriteLine(game);

			game.AddLevel("BlockedThesesusIn3by3", 3, 3,
							"0000 0101 0202"
							+ " 1111 1001 1100"
							+ " 1101 1111 0101"
							+ " 0011 1010 0110");
			Console.WriteLine($"CurrentLevel: {game.CurrentLevelName}.{ game.LevelWidth}x { game.LevelHeight}");
			Console.WriteLine(game);

			game.AddLevel("CentredMinotaurThesesusIn7by7", 7, 7,
							"0303 0003 0001"
							+ " 1001 1000 1000 1000 1000 1000 1100"
							+ " 0001 0000 0000 0000 0000 0000 0100"
							+ " 0001 0000 0000 0000 0000 0000 0100"
							+ " 0001 0000 0000 0000 0000 0000 0100"
							+ " 0001 0000 0000 0000 0000 0000 0100"
							+ " 0001 0000 0000 0000 0000 0000 0100"
							+ " 0011 0010 0010 0010 0010 0010 0110");
			Console.WriteLine($"CurrentLevel: {game.CurrentLevelName}.{ game.LevelWidth}x { game.LevelHeight}");
			Console.WriteLine(game);
			
			game.SetLevel("*** complex game");
			Console.WriteLine("Start - Theseus wins complex game");
			Console.WriteLine(game);
			Console.WriteLine($"CurrentLevel: {game.CurrentLevelName}.{ game.LevelWidth}x { game.LevelHeight}");
			Console.WriteLine($"Moves: {game.MoveCount}\n");

			Console.WriteLine("Theseus goes left");
			game.MoveTheseus(Moves.LEFT);
			game.MoveMinotaur();
			game.MoveMinotaur();
			Console.WriteLine(game);
			Console.WriteLine($"Moves: {game.MoveCount}");
			Console.WriteLine($"Theseus Win: {game.HasTheseusWon}");
			Console.WriteLine($"Minotaur Win: {game.HasMinotaurWon}\n");

			Console.WriteLine("Theseus goes right");
			game.MoveTheseus(Moves.RIGHT);
			game.MoveMinotaur();
			game.MoveMinotaur();
			Console.WriteLine(game);
			Console.WriteLine($"Moves: {game.MoveCount}");
			Console.WriteLine($"Theseus Win: {game.HasTheseusWon}");
			Console.WriteLine($"Minotaur Win: {game.HasMinotaurWon}\n");

			Console.WriteLine("Theseus goes right");
			game.MoveTheseus(Moves.RIGHT);
			game.MoveMinotaur();
			game.MoveMinotaur();
			Console.WriteLine(game);
			Console.WriteLine($"Moves: {game.MoveCount}");
			Console.WriteLine($"Theseus Win: {game.HasTheseusWon}");
			Console.WriteLine($"Minotaur Win: {game.HasMinotaurWon}\n");

			Console.WriteLine("Theseus goes up");
			game.MoveTheseus(Moves.UP);
			game.MoveMinotaur();
			game.MoveMinotaur();
			Console.WriteLine(game);
			Console.WriteLine($"Moves: {game.MoveCount}");
			Console.WriteLine($"Theseus Win: {game.HasTheseusWon}");
			Console.WriteLine($"Minotaur Win: {game.HasMinotaurWon}\n");

			Console.WriteLine("Theseus goes right");
			game.MoveTheseus(Moves.RIGHT);
			game.MoveMinotaur();
			game.MoveMinotaur();
			Console.WriteLine(game);
			Console.WriteLine($"Moves: {game.MoveCount}");
			Console.WriteLine($"Theseus Win: {game.HasTheseusWon}");
			Console.WriteLine($"Minotaur Win: {game.HasMinotaurWon}\n");

			Console.WriteLine("Start - Theseus loses complex game");
			data = "0001 0201 0103";
			data += " 1001 1010 1100 0001";
			data += " 0001 1110 0001 1010";
			data += " 0011 1010 0110 1011";
			game.AddLevel("*** complex game2", 4, 3, data);

			Console.WriteLine(game);
			Console.WriteLine($"Moves: {game.MoveCount}\n");

			Console.WriteLine("Theseus goes right");
			game.MoveTheseus(Moves.RIGHT);
			game.MoveMinotaur();
			game.MoveMinotaur();
			Console.WriteLine(game);
			Console.WriteLine($"Moves: {game.MoveCount}");
			Console.WriteLine($"Theseus Win: {game.HasTheseusWon}");
			Console.WriteLine($"Minotaur Win: {game.HasMinotaurWon}\n");

			Console.WriteLine("Theseus goes left");
			game.MoveTheseus(Moves.LEFT);
			game.MoveMinotaur();
			game.MoveMinotaur();
			Console.WriteLine(game);
			Console.WriteLine($"Moves: {game.MoveCount}");
			Console.WriteLine($"Theseus Win: {game.HasTheseusWon}");
			Console.WriteLine($"Minotaur Win: {game.HasMinotaurWon}\n");

			Console.ReadKey();
			
		}
	}
}
