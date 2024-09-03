using System;
using System.Collections.Generic;
using System.Linq;

namespace FussballProjekt
{
	class Program
	{
		static void Main(string[] args)
		{
			// Team 
			Team realMadrid = new Team("Real Madrid", "Carlo Ancelotti", 1902);
			Team fcBarcelona = new Team("FC Barcelona", "Xavi Hernàndez", 1899);

			// Spieler
			Player messi = new Player("Lionel Messi", "Stürmer", new DateTime(1987, 6, 24), 821, 361, true, "Inter Miami", "Gerardo Martino", 2018);

			// Matchday
			Matchday matchday = new Matchday(DateTime.Now);

			matchday.AddGame(new Game("FC Barcelona", "Real Madrid", DateTime.Now, "Barcelona", "Goal by FC Barcelona", 2, 1));

			Console.WriteLine("Do you want to search for a team? (yes/no)");
			string searchType = Console.ReadLine();

			if (string.Equals(searchType, "yes", StringComparison.OrdinalIgnoreCase))
			{
				Console.WriteLine("Enter the teamname: ");
				string searchTerm = Console.ReadLine();

				Team foundTeam = FindTeam(searchTerm, realMadrid, fcBarcelona);
				if (foundTeam != null)
				{
					Console.WriteLine("\nTeam found: ");
					DisplayTeamInfo(foundTeam);
				}
				else
				{
					Console.WriteLine($"Team '{searchTerm}' could not be found");
				}
			}
			else if (string.Equals(searchType, "no", StringComparison.OrdinalIgnoreCase))
			{
				Console.WriteLine("Do you want to search for a player? (yes/no)");
				string searchPlayerType = Console.ReadLine();

				if (string.Equals(searchPlayerType, "yes", StringComparison.OrdinalIgnoreCase))
				{
					Console.WriteLine("Enter the player's name: ");
					string searchPlayerTerm = Console.ReadLine();

					Player foundPlayer = FindPlayer(searchPlayerTerm, messi);
					if (foundPlayer != null)
					{
						Console.WriteLine("\nPlayer found: ");
						DisplayPlayerInfo(foundPlayer);
					}
					else
					{
						Console.WriteLine($"Player '{searchPlayerTerm}' could not be found");
					}
				}
				else
				{
					Console.WriteLine("Do you want to search for a game? (yes/no)");
					string searchGameType = Console.ReadLine();

					if (string.Equals(searchGameType, "yes", StringComparison.OrdinalIgnoreCase))
					{
						matchday.SearchAndDisplayGame();
					}
					else
					{
						Console.WriteLine("Do you want to search for a league? (yes/no)");
						string searchLeagueType = Console.ReadLine();

						if (string.Equals(searchLeagueType, "yes", StringComparison.OrdinalIgnoreCase))
						{
							LeagueManager leagueManager = new LeagueManager();

							leagueManager.CreateNewLeague("Premier League", DateTime.Now, "England");
							leagueManager.CreateNewLeague("Bundesliga", DateTime.Now, "Germany");

							leagueManager.SearchLeague();
						}
					}
				}
			}

			Console.ReadLine();
		}


		static Team FindTeam(string teamName, params Team[] teams)
		{
			return teams.FirstOrDefault(team => team.GetTeamName().Equals(teamName, StringComparison.OrdinalIgnoreCase));
		}


		static Player FindPlayer(string playerName, params Player[] players)
		{
			return players.FirstOrDefault(player => player.GetPlayerName().Equals(playerName, StringComparison.OrdinalIgnoreCase));
		}

		static void DisplayTeamInfo(Team team)
		{
			Console.WriteLine($"Teamname: {team.GetTeamName()}\nCoach: {team.GetCoach()}\nFoundet: {team.GetFoundingYear()}");
		}
			static void DisplayPlayerInfo(Player player)
			{
				Console.WriteLine($"Name: {player.GetPlayerName()}\nPosition: {player.GetPosition()}\nBirthdate: {player.GetBirthdate()}\nGoals: {player.GetGoalsScored()}\nAssists: {player.GetAssistsGiven()}\nInjured: {player.GetInjuries()}");
				Console.WriteLine($"Team: {player.TeamName}\nCoach: {player.Coach}\nFounding Year: {player.FoundingYear}");
			}
		
	}
}
