using System;
using Game.Characters.Types.Humans;
using Game.Core;
using Game.Narrators;

namespace Game.Console
{
	public class Program
	{
		static void Main(string[] args)
		{
			Initialize();

			var narrator = new DefaultNarrator();
			var reply = narrator.DescribeCharacter(GameContext.Characters[0], GameContext.Characters[1]);

			// Print reply
			reply = GameContext.Characters[0].Common.Name.First + ": " + reply;
			System.Console.WriteLine(reply);

			while (true)
			{
				System.Console.Write("> ");
				var input = System.Console.ReadLine();

				if (input == "quit" || input == "q")
				{
					break;
				}
				else
				{
					System.Console.WriteLine("Unknown command" + Environment.NewLine);
				}
			}

			//string json = JsonConvert.SerializeObject(creator.CreateHuman(), Formatting.Indented);
		}

		public static void Initialize()
		{
			// Create characters
			var creator = new HumanCreator();

			for (int i = 0; i < 2; i++)
			{
				var human = creator.CreateHuman();
				GameContext.Characters.Add(human);

				System.Console.WriteLine("{0}\t{1}\t\t{2} kg\t\t{3} cm\t\t{4}",
					human.Common.Name.Full.PadRight(20),
					human.Common.Age,
					human.Common.Weight,
					human.Common.Height,
					human.States.Mental.PersonalityState.Personality);
			}

			System.Console.WriteLine();

			// Create character memories
			var memoryCreator = new HumanMemoryCreator();
			memoryCreator.CreateMemory(GameContext.Characters[0], GameContext.Characters[1]);
		}
	}
}