namespace ArenaFighter
{
	/// <summary>
	/// The class for information of character
	/// </summary>
	internal class Character
	{
		// Some properties for information of the character
		public string Name { get; set; }

		public int Strength { get; set; }
		public int Health { get; set; }

		public int Score { get; set; }

		public bool IsAlived { get; set; }
		public bool IsRetired { get; set; }

		/// <summary>
		/// Create a new character
		/// </summary>
		/// <param name="initName">The name of the new character</param>
		public Character(string initName)
		{
			// Set the name of character
			Name = initName;

			// Create random value for both strength and health of the character
			Strength = Program.random.Next(1, 10);
			Health = Program.random.Next(1, 100);

			// Set the score of character to zero
			Score = 0;

			// Set that character are alive and not retired
			IsAlived = true;
			IsRetired = false;
		}
	}
}
