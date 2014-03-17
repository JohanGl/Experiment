using Game.Characters;

namespace Game.Narrators
{
	public interface INarrator
	{
		string DescribeCharacter(ICharacter self, ICharacter target);
	}
}