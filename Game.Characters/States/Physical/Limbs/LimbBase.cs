using System;
using System.Collections.Generic;
using Game.Characters.Helpers;
using Game.Characters.States.Physical.Organs;
using Game.Core.Random;

namespace Game.Characters.States.Physical.Limbs
{
	public abstract class LimbBase : ILimb
	{
		public Guid Id { get; set; }
		public float FunctionRate { get; set; }
		public bool IsFunctional { get; set; }
		public float AppearanceRating { get; set; }
		public List<ILimb> Limbs { get; set; }
		public List<IOrgan> Organs { get; set; }

		public LimbBase()
		{
			Id = Guid.NewGuid();
			FunctionRate = 10;
			IsFunctional = true;
			AppearanceRating = Randomizer.Random.Next(0, 10);
			Limbs = new List<ILimb>();
			Organs = new List<IOrgan>();
		}
	}
}