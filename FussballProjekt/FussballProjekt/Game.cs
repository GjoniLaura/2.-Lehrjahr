using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FussballProjekt
{
	public class Game
	{
		public string HomeTeam { get; set; }
		public string AwayTeam { get; set; }
		public DateTime Time { get; set; }
		public string Location { get; set; }
		public string Description { get; set; }
		public int HomeTeamScore { get; set; }
		public int AwayTeamScore { get; set; }

		public Game(string homeTeam, string awayTeam, DateTime time, string location, string description, int homeTeamScore, int awayTeamScore)
		{
			HomeTeam = homeTeam;
			AwayTeam = awayTeam;
			Time = time;
			Location = location;
			Description = description;
			HomeTeamScore = homeTeamScore;
			AwayTeamScore = awayTeamScore;
			
		}
	}
}
