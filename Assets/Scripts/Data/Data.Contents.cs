using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

using static Define;

#region DataEnum
public enum SkillType
{
	[XmlEnum("BasicAtk")]
	BasicAtk,
	[XmlEnum("TestSkill")]
	TestSkill
}

public enum Grade
{
	[XmlEnum("Unknown")]
	Unknown,
	[XmlEnum("Common")]
	Common,
	[XmlEnum("WellKnown")]
	WellKnown,
	[XmlEnum("Zenith")]
	Zenith,
	[XmlEnum("Transcendence")]
	Transcendence
}

public enum MartialArt
{
	[XmlEnum("Sorcery")]
	Sorcery,
	[XmlEnum("Swordsmanship")]
	Swordsmanship,
	[XmlEnum("HandMartialArt")]
	HandMartialArt,
	[XmlEnum("Knifemanship")]
	Knifemanship
}
#endregion

namespace Data
{
	#region CharacterData


	[Serializable]
	public class CharacterData
    {
		[XmlAttribute]
		public int id;
		[XmlElement("level")]
		public int level;
		[XmlElement("grade")]
		public Grade grade;
		[XmlElement("martialArt")]
		public MartialArt martialArt;
		[XmlElement("maxHp")]
		public int maxHp;
		[XmlElement("hp")]
		public int hp;
		[XmlElement("atk")]
		public int atk;
		[XmlElement("atkSpeed")]
		public int atkSpeed;
		[XmlElement("def")]
		public int def;
		[XmlElement("critRatio")]
		public float critRatio;
		[XmlElement("critDamageRatio")]
		public float critDamageRatio;
		[XmlElement("decCoolTime")]
		public float decCoolTime;
		[XmlArray("skills")]
		[XmlArrayItem("skill")]
		public List<SkillType> skills;

        #region DeepCopy
        public CharacterData DeepCopy()
		{
			CharacterData copy = new CharacterData();
			copy.id = this.id;
			copy.level = this.level;
			copy.grade = this.grade;
			copy.martialArt = this.martialArt;
			copy.maxHp = this.maxHp;
			copy.hp = this.hp;
			copy.atk = this.atk;
			copy.atkSpeed = this.atkSpeed;
			copy.def = this.def;
			copy.critRatio = this.critRatio;
			copy.critDamageRatio = this.critDamageRatio;
			copy.decCoolTime = this.decCoolTime;
			copy.skills = new List<SkillType>(this.skills);

			return copy;
		}
        #endregion
    }

    [Serializable, XmlRoot("CharacterDatas")]
	public class CharacterDataLoader : ILoader<int, CharacterData>
	{
		[XmlElement("CharacterData")]
		public List<CharacterData> stats = new List<CharacterData>();

		public Dictionary<int, CharacterData> MakeDict()
		{
			Dictionary<int, CharacterData> dict = new Dictionary<int, CharacterData>();
			foreach (CharacterData stat in stats)
			{
				dict.Add(stat.id, stat);
			}
			return dict;
		}

	}

	#endregion

	#region MonsterData

	public class MonsterData
	{
		[XmlAttribute]
		public string name;
		[XmlAttribute]
		public string prefab;
		[XmlAttribute]
		public int level;
		[XmlAttribute]
		public int maxHp;
		[XmlAttribute]
		public int attack;
		[XmlAttribute]
		public float speed;
	}

	#endregion
}