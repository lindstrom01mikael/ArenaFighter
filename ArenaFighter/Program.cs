using System;

namespace ArenaFighter
{
	/// <summary>
	/// The start class for this program / game
	/// </summary>
	internal class Program
	{
		/// <summary>
		/// The name of this program
		/// </summary>
		public const string ProgramName = "The Arena fighter 2000";

		/// <summary>
		/// A instans of Random class for handle and creating of randomly values
		/// </summary>
		public static Random random = new Random();
		
		/// <summary>
		/// The start point of this program / game
		/// </summary>
		/// <param name="args">Anything</param>
		static void Main(string[] args)
		{
			// Name list for options for names of opponent character
			string[] names = new string[6] { "David", "Gustav", "Fredrik", "Ulrik", "Krister", "Karl"};

			// Welcome the user to this program / game
			Console.WriteLine($"Welcome to {ProgramName}!");

			// Make a pause in this program
			Console.ReadKey();

			// Ask the user for name of their character
			Console.Write("Write a name of your character: ");
			string name = Console.ReadLine();

			// Create a character for the player
			Character player = new Character(name);

			// Run the program until the player not alive anymore or the player choise to retired the battle
			while(player.IsAlived == true && player.IsRetired == false)
			{
				// Create a charcter for opponent with randomly created name
				Character opponent = new Character(names[random.Next(0, names.Length)]);

				// Create a new battle with character for both the player and a opponent
				Battle battle = new Battle(player, opponent);

				// Make a pause in the program
				Console.ReadKey();
			}
		}
	}

}
