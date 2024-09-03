using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FussballProjekt
{
    public class Team
    {
        private string _teamName;
        private string _coach;
        private int _foundingYear;
        private List<Player> _players = new List<Player>();

		public List<Player> Players
		{
			get { return _players; }
		}

		public string TeamName => _teamName;
        public string Coach => _coach;
        public int FoundingYear => _foundingYear;

        public IReadOnlyList<Player> Player => _players;


        public void AddPlayer(Player player)
        {
            _players.Add(player);
        }

        public string GetTeamName()
        {
            return _teamName;
        }

        public string GetCoach()
        {
            return _coach;
        }

        public int GetFoundingYear()
        {
            return _foundingYear;
        }


        public Team(string teamName, string coach, int foundingYear)
        {
            _teamName = teamName;
            _coach = coach;
            _foundingYear = foundingYear;
        }
    }
}


