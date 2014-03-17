using Game.Characters;
using Game.Characters.Common;

namespace Game.Narrators
{
	public class ParameterHelper
	{
		public string GetParameter(string input, int index)
		{
			index++;

			int index2;

			for (index2 = index; index2 < input.Length; index2++)
			{
				if (input[index2] == '.' || input[index2] == '}')
				{
					return input.Substring(index, index2 - index);
				}
			}

			return null;
		}

		public string GetFullParameter(string input, int index)
		{
			var indexEnd = input.IndexOf('}', index);

			if (indexEnd > index)
			{
				var parameter = input.Substring(index, (indexEnd + 1) - index);
				return parameter;
			}

			return null;
		}

		public string GetParameterElements(string input, int index)
		{
			index++;

			var indexEnd = input.IndexOf('}', index);
			var indexElement = input.IndexOf('.', index);

			if (indexEnd > index && indexElement < indexEnd)
			{
				indexElement++;
				return input.Substring(indexElement, indexEnd - indexElement);
			}

			return null;
		}

		public void ReplaceParameter(ref string input, int index, string value)
		{
			var parameter = GetFullParameter(input, index);
			input = input.Replace(parameter, value);
		}

		public string GetEntitySpecificParameterValue<T>(T entity, string parameter)
		{
			if (entity is ICharacter)
			{
				return GetCharacterParameterValue((ICharacter)entity, parameter);
			}

			return null;
		}

		private string GetCharacterParameterValue(ICharacter entity, string parameter)
		{
			switch (parameter)
			{
				case "Name":
					return entity.Common.Name.Full;

				case "Name.First":
					return entity.Common.Name.First;

				case "Name.Last":
					return entity.Common.Name.Last;

				case "HeShe":
					return entity.Common.Gender == Gender.Male ? "He" : "She";

				default:
					return null;
			}
		}
	}
}