using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Define
{
	public enum Scene
	{
		Unknown,
		DevScene,
		GameScene,
	}

	public enum Sound
	{
		Bgm,
		Effect,
	}

	public enum ObjectType
	{
		Player,
		Monster,
		Projectile
	}

	public enum CreatureType
    {
		Goblin,
		Slime,
		Snake,
		None
	}

	public enum SkillType
	{
		TestSkill1,
		TestSkill2
	}
}
