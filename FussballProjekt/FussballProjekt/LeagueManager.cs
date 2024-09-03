using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FussballProjekt
{
    public class League
    {
        public string LeagueName { get; set; }
        public List<Team> Teams { get; set; } = new List<Team>();
        public DateTime StartDate { get; set; }
        public string Location { get; set; }
        public List<Matchday> Matchdays { get; set; } = new List<Matchday>();

        public League(string leagueName, DateTime startDate, string location)
        {
            LeagueName = leagueName;
            StartDate = startDate;
            Location = location;
        }

        public void AddTeam(Team team)
        {
            Teams.Add(team);
        }

        public void CreateMatchday(DateTime date)
        {
            Matchday matchday = new Matchday(date);
            Matchdays.Add(matchday);
        }
    }

    public class LeagueManager
    {
        private List<League> _leagues = new List<League>();

        public void CreateNewLeague(string leagueName, DateTime startDate, string location)
        {
            League league = new League(leagueName, startDate, location);
            _leagues.Add(league);
        }

        public void AddTeamToLeague(string leagueName, Team team)
        {
            League league = _leagues.FirstOrDefault(l => l.LeagueName == leagueName);

            if (league != null)
            {
                league.AddTeam(team);
            }
            else
            {
                Console.WriteLine($"League '{leagueName}' not found.");
            }
        }

        public void CreateMatchdayInLeague(string leagueName, DateTime date)
        {
            League league = _leagues.FirstOrDefault(l => l.LeagueName == leagueName);

            if (league != null)
            {
                league.CreateMatchday(date);
            }
            else
            {
                Console.WriteLine($"League '{leagueName}' not found.");
            }
        }

		public void SearchLeague()
		{
			Console.WriteLine("Do you want to search for a league? (yes/no)");
			string response = Console.ReadLine().ToLower();

			if (response == "yes")
			{
				Console.WriteLine("Enter the league name:");
				string leagueName = Console.ReadLine();

				SearchAndDisplayLeague(leagueName);
			}
			else if (response == "no")
			{
				Console.WriteLine("Search canceled.");
			}
			else
			{
				Console.WriteLine("Invalid response. Please enter 'yes' or 'no'.");
			}
		}

		private void SearchAndDisplayLeague(string leagueName)
		{
			League foundLeague = _leagues.FirstOrDefault(league => league.LeagueName == leagueName);

			if (foundLeague != null)
			{
				Console.WriteLine($"League found: {foundLeague.LeagueName}");
				Console.WriteLine($"Start Date: {foundLeague.StartDate}");
				Console.WriteLine($"Location: {foundLeague.Location}");
				Console.WriteLine($"Teams: {string.Join(", ", foundLeague.Teams.Select(t => t.TeamName))}");
			}
			else
			{
				Console.WriteLine($"League '{leagueName}' not found.");
			}
		}
	}
}
