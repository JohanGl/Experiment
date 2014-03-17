using System;

namespace Game.Core.Random
{
	public static class Randomizer
	{
		public static MersenneTwister Random { get; set; }

		static Randomizer()
		{
			Random = new MersenneTwister(DateTime.Now.Millisecond);
		}
	}
}