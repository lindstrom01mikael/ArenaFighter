using System;
using System.Collections.Generic;

namespace ArenaFighter
{
	/// <summary>
	/// The class for the battle itself
	/// </summary>
	internal class Battle
	{
		// Properties for character in this battle
        public Character Player { get; set; }
        public Character Opponent { get; set; }

		// Private field for battle log
		private IList<string> _log;

		/// <summary>
		/// Create new battle for two character
		/// </summary>
		/// <param name="player">The player character in this battle</param>
		/// <param name="opponent">The opponent character in this battle</param>
        public Battle(Character player, Character opponent)
        {
			// Set character for this battle
            Player = player;
			Opponent = opponent;

			// Create a new battle log
			_log = new List<string>();

			// Start the battle
			GoBattle();
        }

		/// <summary>
		/// The battle itself
		/// </summary>
		private void GoBattle()
		{
            // Tell the user that battle are started
            Console.WriteLine("********** Battle are started! **********");
			
			do
			{
				// Start new round in the battle
				Round round = new Round(this);

				// Check if the battle character are still alive
				if (Player.Health < 1)
					Player.IsAlived = false;
				if(Opponent.Health < 1)
					Opponent.IsAlived = false;


			} while (Player.IsAlived == true && Player.IsRetired == false && Opponent.IsAlived == true);
            
			// Add Last message to battle log
            WriteALogMessage($"The score for {Player.Name} are {Player.Score} and for {Opponent.Name} are {Opponent.Score}.");

			// Tell the user that battle are ended and show charcter score and the health for player character
			Console.WriteLine("********** Battle are ended! **********");
            Console.WriteLine($"The score for {Player.Name} are {Player.Score} and for {Opponent.Name} are {Opponent.Score}.");
            Console.WriteLine($"Your character ended with a health {Player.Health}.");

			// Show the battle log in console window
            ShowBattleLog();
		}

		/// <summary>
		/// Add new message in the battle log 
		/// </summary>
		/// <param name="message">The text in the battle log</param>
		public void WriteALogMessage(string message) => _log.Add(message);
		/// <summary>
		/// Show the battle log in console window
		/// </summary>
		private void ShowBattleLog()
		{
            // Show a header that tell the user below are battle log
            Console.WriteLine("********** Battle log **********");
			foreach (string log in _log) 
			{
				Console.WriteLine(log);
			}
        }
    }
}
