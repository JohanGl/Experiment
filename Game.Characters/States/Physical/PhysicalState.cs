using System;
using System.Collections.Generic;
using Game.Characters.States.Physical.Limbs;

namespace Game.Characters.States.Physical
{
	public class PhysicalState
	{
		public float Health { get; set; }
		public bool IsDead { get; set; }
		public DateTime? TimeOfDeath { get; set; }
		public List<ILimb> Limbs { get; set; }

		public PhysicalState()
		{
			Health = 10;
			Limbs = new List<ILimb>();
		}
	}
}