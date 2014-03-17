using System;
using Game.Characters.States.Physical.Limbs;

namespace Game.Characters.States.Physical.Organs
{
	public interface IOrgan
	{
		Guid Id { get; set; }
		ILimb Limb { get; set; }
		float FunctionRate { get; set; }
		bool IsFunctional { get; set; }
	}
}