using System;

namespace Game.Characters.Memories
{
	public interface IMemory
	{
		Guid Id { get; set; }
		MemoryType Type { get; set; }
	}
}