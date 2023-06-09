using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public interface ILoader<Key, Value>
{
	Dictionary<Key, Value> MakeDict();
}

public class DataManager
{
	public Dictionary<int, Data.CharacterData> CharacterDic { get; private set; } = new Dictionary<int, Data.CharacterData>();

	public void Init()
	{
		//PlayerDic = LoadJson<Data.PlayerDataLoader, int, Data.PlayerData>("PlayerData.json").MakeDict();
		CharacterDic = LoadXml<Data.CharacterDataLoader, int, Data.CharacterData>("CharacterData.xml").MakeDict();
	}

    #region Generic
    Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
	{
		TextAsset textAsset = Managers.Resource.Load<TextAsset>($"{path}");
		return JsonUtility.FromJson<Loader>(textAsset.text);
	}

	Item LoadSingleXml<Item>(string name)
	{
		XmlSerializer xs = new XmlSerializer(typeof(Item));
		TextAsset textAsset = Managers.Resource.Load<TextAsset>(name);
		using (MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(textAsset.text)))
			return (Item)xs.Deserialize(stream);
	}

	Loader LoadXml<Loader, Key, Item>(string name) where Loader : ILoader<Key, Item>, new()
	{
		XmlSerializer xs = new XmlSerializer(typeof(Loader));
		TextAsset textAsset = Managers.Resource.Load<TextAsset>(name);
		using (MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(textAsset.text)))
			return (Loader)xs.Deserialize(stream);
	}
	#endregion
}