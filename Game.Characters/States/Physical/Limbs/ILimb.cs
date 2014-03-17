using System;
using System.Collections.Generic;
using Game.Characters.States.Physical.Organs;

namespace Game.Characters.States.Physical.Limbs
{
	public interface ILimb
	{
		Guid Id { get; set; }
		float FunctionRate { get; set; }
		bool IsFunctional { get; set; }
		float AppearanceRating { get; set; }
		List<ILimb> Limbs { get; set; }
		List<IOrgan> Organs { get; set; }
	}
}