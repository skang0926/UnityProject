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

    #region Contents
    public enum ObjectType
	{
		Player,
		Monster,
		Projectile
	}

	public enum CreatureType
    {
		Knight,
		Slime,
		Snake,
		None
	}
	#endregion
}
