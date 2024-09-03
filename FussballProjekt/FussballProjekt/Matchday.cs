using System;
using System.Collections.Generic;
using System.Linq;

namespace FussballProjekt
{
    public class Matchday
    {
        public List<Game> Games { get; set; }

        public Matchday(DateTime date)
        {
            Games = new List<Game>();
        }

        public void AddGame(Game game)
        {
            Games.Add(game);
        }

		public void SearchAndDisplayGame()
		{
			Console.WriteLine("Do you want to search for a game? (yes/no)");
			string response = Console.ReadLine().ToLower();

			while (response == "yes")
			{
				Console.WriteLine("Enter the Home Team:");
				string homeTeam = Console.ReadLine();

				Console.WriteLine("Enter the Away Team:");
				string awayTeam = Console.ReadLine();

				var game = Games.FirstOrDefault(g =>
					g.HomeTeam == homeTeam && g.AwayTeam == awayTeam);

				if (game != null)
				{
					Console.WriteLine($"Game between {homeTeam} and {awayTeam}");
					Console.WriteLine($"Game Location: {game.Location}");
					Console.WriteLine($"Result: {game.HomeTeamScore} - {game.AwayTeamScore}");
					Console.WriteLine($"Description: {game.Description}");
					// Füge weitere relevante Informationen hinzu
				}
				else
				{
					Console.WriteLine($"No game found between {homeTeam} and {awayTeam}");
				}

				Console.WriteLine("Do you want to search for another game? (yes/no)");
				response = Console.ReadLine().ToLower();
			}

			if (response == "no")
			{
				Console.WriteLine("Search canceled.");
			}
			else
			{
				Console.WriteLine("Invalid response. Please enter 'yes' or 'no'.");
			}
		}

	}
}
