using System.Collections.Generic;
using System.IO;

namespace Game.Narrators
{
	public class NarratorFileParser
	{
		private List<NarratorItem> items;
		private int index;
		private string[] lines;
		private int separators;
		private const string separator = "----";
		private NarratorItem narratorItem;

		public List<NarratorItem> Parse(string file)
		{
			lines = File.ReadAllLines(file);
			items = new List<NarratorItem>();
			narratorItem = null;
			index = 0;
			separators = 0;

			while (index < lines.Length)
			{
				if (lines[index].StartsWith(separator))
				{
					ParseSeparators();
				}
				else if (lines[index].EndsWith(":"))
				{
					ParseOptions();
				}

				index++;

				if (index >= lines.Length)
				{
					break;
				}
			}

			lines = null;

			return items;
		}

		private bool IsEndOfFile()
		{
			return index + 1 >= lines.Length;
		}

		private void ParseSeparators()
		{
			separators++;

			if (separators == 1)
			{
				index++;
				narratorItem = new NarratorItem();
				narratorItem.Name = lines[index];
				index++;
			}
			else if (separators == 2)
			{
				items.Add(narratorItem);
				separators = 0;

				// If we havent reached the end of the file, then adjust the index for the next item
				if (index + 1 < lines.Length)
				{
					index -= 2;
				}
			}
		}

		private void ParseOptions()
		{
			var name = lines[index].Substring(0, lines[index].Length - 1);

			if (!narratorItem.Options.ContainsKey(name))
			{
				narratorItem.Options.Add(name, new List<string>());
			}

			index++;

			while (true)
			{
				if (lines[index] != string.Empty)
				{
					if (!lines[index].StartsWith(separator))
					{
						narratorItem.Options[name].Add(lines[index]);
					}
					else
					{
						index--;
						break;
					}
				}
				else
				{
					break;
				}

				index++;
			}
		}
	}
}