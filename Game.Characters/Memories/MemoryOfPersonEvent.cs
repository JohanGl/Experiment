using System;
using System.Collections.Generic;

namespace Game.Characters.Memories
{
	public class MemoryOfPersonEvent : IMemory
	{
		public Guid Id { get; set; }
		public MemoryType Type { get; set; }

		public Guid PersonId { get; set; }
		public Action Action { get; set; }
		public byte Strength { get; set; }
		public List<string> Analysis { get; set; }

		public MemoryOfPersonEvent()
		{
			Id = Guid.NewGuid();
			Type = MemoryType.Person;
			Analysis = new List<string>();
		}
	}
}