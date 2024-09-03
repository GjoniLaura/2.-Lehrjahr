using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFussballProjekt
{
	[TestFixture]
	public class Player
	{
		private string _playerName;
		private string _position;
		public string PlayerName => _playerName;
		public string Position => _position;

		[Test]
		public string GetPlayerName()
		{
			return _playerName;
		}

		[Test]
		public string GetPosition()
		{
			return _position;
		}
	}
}
