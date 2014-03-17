using System.Collections.Generic;
using System.Linq;
using Game.Characters;
using Game.Characters.Memories;

namespace Game.Narrators
{
	public class DefaultNarrator : INarrator
	{
		private List<NarratorItem> narratorItems;
		private ParameterHelper parameterHelper;

		public DefaultNarrator()
		{
			var parser = new NarratorFileParser();
			narratorItems = parser.Parse("Narrator/Narrator.txt");
			parameterHelper = new ParameterHelper();
		}

		public string DescribeCharacter(ICharacter self, ICharacter target)
		{
			var memory = self.Memory.Memories.OfType<MemoryOfPersonEvent>().FirstOrDefault(p => p.PersonId == target.Id);

			if (memory == null)
			{
				return CanNotRecall(self, target);
			}

			var item = narratorItems.SingleOrDefault(p => p.Name == "Character.Question.OtherCharacter.MentalImage");

			switch (memory.Action)
			{
				case Action.Positive:
					{
						var line = item.GetRandomLine("Positive");
						ApplyParameters(ref line, "Self", self, "Target", target);
						return line;
					}

				case Action.Negative:
					{
						var line = item.GetRandomLine("Negative");
						ApplyParameters(ref line, "Self", self, "Target", target);
						return line;
					}
	
				case Action.Neutral:
					{
						var line = item.GetRandomLine("Default");
						ApplyParameters(ref line, "Self", self, "Target", target);
						return line;
					}

				default:
					return "Missing action for memory found.";
			}
		}

		private string CanNotRecall(ICharacter self, ICharacter other)
		{
			var item = narratorItems.SingleOrDefault(p => p.Name == "Character.Question.OtherCharacter.DontKnow");
			var line = item.GetRandomLine("Default");
			ApplyParameters(ref line, "Self", self, "Target", other);
			return line;
		}

		private void ApplyParameters(ref string input, params dynamic[] parameters)
		{
			int startIndex = 0;

			while (true)
			{
				int index = input.IndexOf('{', startIndex);

				if (index == -1)
				{
					break;
				}

				var parameter = parameterHelper.GetParameter(input, index);

				for (int i = 0; i < parameters.Length; i += 2)
				{
					if (parameter == parameters[i])
					{
						var parameterElement = parameterHelper.GetParameterElements(input, index);
						var value = parameterHelper.GetEntitySpecificParameterValue(parameters[i + 1], parameterElement);
						parameterHelper.ReplaceParameter(ref input, index, value);

						break;
					}
				}

				startIndex = index + 1;
			}
		}
	}
}