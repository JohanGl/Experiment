using System.Collections.Generic;
using Game.Characters.Common;
using Game.Characters.Helpers;
using Game.Characters.Helpers.Names;
using Game.Characters.States.Mental;
using Game.Characters.States.Mental.Emotions;
using Game.Characters.States.Mental.Personality;
using Game.Characters.States.Physical.Limbs;
using Game.Characters.States.Physical.Limbs.Facial;
using Game.Characters.States.Physical.Organs;
using Game.Core.Random;

namespace Game.Characters.Types.Humans
{
	public class HumanCreator
	{
		private readonly NameGenerator nameGenerator;

		public HumanCreator()
		{
			nameGenerator = new NameGenerator();
		}

		public ICharacter CreateHuman()
		{
			var character = new Human();
			character.Common = GetCommon();
			character.States.Mental = GetMentalState();
			character.States.Physical.Limbs = GetLimbs();

			return character;
		}

		private CharacterCommon GetCommon()
		{
			var common = new CharacterCommon();

			common.Gender = Randomizer.Random.Next(100) < 60 ? Gender.Male : Gender.Female;
			common.Age = Randomizer.Random.Next(100) < 75 ? 20 + Randomizer.Random.Next(15) : 30 + Randomizer.Random.Next(25);

			if (common.Gender == Gender.Male)
			{
				common.Weight = 70 + Randomizer.Random.Next(28);
				common.Height = 175 + Randomizer.Random.Next(15);
			}
			else
			{
				common.Weight = 55 + Randomizer.Random.Next(18);
				common.Height = 165 + Randomizer.Random.Next(20);
			}

			common.Name = nameGenerator.Create(common.Gender);

			return common;
		}

		private MentalState GetMentalState()
		{
			var state = new MentalState();

			state.Status = MentalStatus.Normal;
			state.EmotionSecondary = EmotionSecondary.Default;
			state.PersonalityState.Personality = (PersonalityType)Randomizer.Random.Next(0, 16);
			state.PersonalityState.Charisma = Randomizer.Random.Next(0, 10);

			return state;
		}

		private List<ILimb> GetLimbs()
		{
			var limbs = new List<ILimb>();
	
			limbs.Add(GetHead());
			limbs.Add(new Neck());
			limbs.Add(GetTorso());
			limbs.Add(new Abdomen());
			limbs.Add(new Arm());
			limbs.Add(new Arm());
			limbs.Add(new Leg());
			limbs.Add(new Leg());

			return limbs;
		}

		private ILimb GetHead()
		{
			var head = new Head();

			head.Limbs.AddRange(GetEyes());
			head.Limbs.AddRange(GetEars());
			head.Limbs.Add(new Mouth());
			head.Limbs.Add(new Nose());

			head.Organs.Add(new Brain());

			return head;
		}

		private IEnumerable<Eye> GetEyes()
		{
			var color = (EyeColor)Randomizer.Random.Next(0, 4);

			var result = new Eye[2];

			result[0] = new Eye();
			result[1] = new Eye();

			result[0].Color = color;
			result[1].Color = color;
			result[1].AppearanceRating = result[0].AppearanceRating;

			return result;
		}

		private IEnumerable<Ear> GetEars()
		{
			var result = new Ear[2];

			result[0] = new Ear();
			result[1] = new Ear();

			result[1].AppearanceRating = result[0].AppearanceRating;

			return result;
		}

		private ILimb GetTorso()
		{
			var torso = new Torso();
			torso.Organs.Add(new Heart());
			torso.Organs.Add(new Lung());
			torso.Organs.Add(new Lung());
			return torso;
		}
	}
}