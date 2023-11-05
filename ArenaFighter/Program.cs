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
		/// The start point of this program / game
		/// </summary>
		/// <param name="args">Anything</param>
		static void Main(string[] args)
		{
			// Welcome the user to this program / game
			Console.WriteLine($"Welcome to {ProgramName}!");

			// Make a pause in this program
			Console.ReadKey();
		}
	}
}
