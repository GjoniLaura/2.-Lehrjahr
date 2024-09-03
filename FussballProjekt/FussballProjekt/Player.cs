using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FussballProjekt
{
    public class Player : Team, IPlayable
    {
        private string _playerName;
        private string _position;
        private DateTime _birthdate;
        private int _goalsScored;
        private int _assistsGiven;
        private bool _injured;
		private List<Game> _games = new List<Game>();

		public List<Game> Games
		{
			get { return _games; }
		}

		public string PlayerName => _playerName;
        public string Position => _position;
        public DateTime Birthdate => _birthdate;
        public int GoalsScored => _goalsScored;
        public int AssistsGiven => _assistsGiven;   
        public bool Injured => _injured;


        public string GetPlayerName()
        {
            return _playerName;
        }

        public string GetPosition()
        {
            return _position;
        }

        public DateTime GetBirthdate()
        {
            return _birthdate;
        }

        public int GetGoalsScored()
        {
            return _goalsScored;
        }

        public int GetAssistsGiven()
        {
            return _assistsGiven;
        }

        public bool GetInjuries() 
        { 
            return _injured; 
        }

        public void ScoreGoal()
        {
            _goalsScored++;
        }

        public void GiveAssist()
        {
            _assistsGiven++;
        }

        public void TreatInjury()
        {
            _injured = false;
        }

        public Player(string playerName, string position, DateTime birthdate, int goalsScored, int assistsGiven, bool injured, string teamName, string coach, int foundingYear)
            : base(teamName, coach, foundingYear)
        {
            _playerName = playerName;
            _position = position;
            _birthdate = birthdate;
            _goalsScored = goalsScored;
            _assistsGiven = assistsGiven;
            _injured = injured;
        }


        private List<Game> _game = new List<Game>();

        public List<Game> Game
        {
            get { return _game; }
        }
    }
}




