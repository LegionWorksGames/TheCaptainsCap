using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
	public string itemName;
	public int itemID;
	public string itemDesc;	
	public int itemValue;
	public ItemType itemType;

	public enum ItemType
	{
		oneTime,
		levels
	}

	public Item(string name, int id, string desc, int value, ItemType type)
	{
		itemName = name;
		itemID = id;
		itemDesc = desc;		
		itemValue = value;
		itemType = type;
	}
	public Item()
	{
		itemID = -1;
	}
}
