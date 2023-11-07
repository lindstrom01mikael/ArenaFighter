using System;

namespace ArenaFighter
{
	/// <summary>
	/// The class for round function in the battle
	/// </summary>
	internal class Round
	{
		/// <summary>
		/// Score for the result in the round
		/// </summary>
		enum Score
		{
			Lost = 2,
			Tied = 5,
			Win = 20
		}

		/// <summary>
		/// The factor for realdamage on character
		/// </summary>
		const int DAMAGE = 2;

		/// <summary>
		/// Create a new round in the battle
		/// </summary>
		/// <param name="battle">The battle that own the new round</param>
		public Round(Battle battle)
		{
			// Variables for this round
			int t1 = battle.Player.Strength + Program.random.Next(1, 6);
			int t2 = battle.Opponent.Strength + Program.random.Next(1, 6);
			int realdamage = 0;
			string message = $"{battle.Player.Name} hit {battle.Opponent.Name} and " +
				$"{battle.Opponent.Name} hit {battle.Player.Name}. ";
			char answer;

			// Tell the user that new round are started
			Console.WriteLine("New round in battle are started!");

			// Check which character win this round
			if(t1 == t2)
			{
				// The round result were tied
				message += "The round result were tied";
				Console.WriteLine("The round result were tied.");

				// Add value into character score
				battle.Player.Score += (int)Score.Tied;
				battle.Opponent.Score += (int)Score.Tied;
			}
			else if(t1 > t2) 
			{
				// The round result were the player win
				realdamage = t1 * DAMAGE;

				// Add text to message and chanage opponent health
				message += $"{battle.Player.Name} win this round and give {realdamage} damage on {battle.Opponent.Name} health.";
				battle.Opponent.Health -= realdamage;

				// Add value into character score
				battle.Player.Score += (int)Score.Win;
				battle.Opponent.Score += (int)Score.Lost;

				// Tell the user that result of this round and ask if their choise to give up
				Console.Write("The round result were that you win, will you give up? Y/N ");
				answer = Console.ReadKey().KeyChar;
				
				// Make a empty row
				Console.WriteLine();

				// Check the user answer
				if (answer.Equals('Y') || answer.Equals('y'))
					battle.Player.IsRetired = true;
			}
			else
			{
				// The round result were opponent win
				realdamage = t2 * DAMAGE;

				// Add text to message and change player health
				message += $"{battle.Opponent.Name} win this round and give {realdamage} damage on {battle.Player.Name} health.";
				battle.Player.Health -= realdamage;

				// Tell the user about the result of this round
				Console.WriteLine($"Your opponent win this round and give {realdamage} damage on your health.");

				// Add valeu into character score
				battle.Player.Score += (int)Score.Lost;
				battle.Opponent.Score += (int)Score.Win;
			}
			// Send a message to battle log
			battle.WriteALogMessage(message);
		}
	}
}
