using System;
using Game.Characters.States.Physical.Limbs;

namespace Game.Characters.States.Physical.Organs
{
	public abstract class OrganBase : IOrgan
	{
		public Guid Id { get; set; }
		public ILimb Limb { get; set; }
		public float FunctionRate { get; set; }
		public bool IsFunctional { get; set; }

		public OrganBase()
		{
			Id = Guid.NewGuid();
			FunctionRate = 10;
			IsFunctional = true;
		}
	}
}