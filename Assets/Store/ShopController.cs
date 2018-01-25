using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour {

	public List<Item> items = new List<Item>();
	public List<Item> inventory = new List<Item>();
	public List<Item> shop = new List<Item>();

	public GameObject[] shopItems, invItems;
	public Text gems, itemType, itemDesc;
		
	//maybe switch this with global later TODO
	private int gemsVal;
	private int selectItem = 4;
	private int[] itemNumPurchase = new int[4];

	// Use this for initialization
	void Start () {

		gemsVal = GameManager.GEMS;
		SetupInventory();
		SetUpShop();
		if (PlayerPrefsManager.GetShop() == 1)
		{
			LoadShop();
		}
		else
		{			
			PlayerPrefsManager.SetShop(1);
		}
		SetInventoryName();
		SetShopItemNames();
		SetGems();
		SetItemDesc(-1);
	}

	void SetUpShop()
	{
		shop.Add(items[0]);
		shop.Add(items[10]);
		shop.Add(items[5]);
		shop.Add(items[11]);		
	}

	void SetShopItemNames()
	{
		for (int i = 0; i < shopItems.Length; i++)
		{
			shopItems[i].GetComponentInChildren<Text>().text = shop[i].itemName;
		}		
	}
	void SetInventoryName()
	{		
		for (int i = 0; i < invItems.Length; i++)
		{
			ItemBoxDisplay ibd = invItems[i].GetComponentInChildren<ItemBoxDisplay>();
			// if avalible else text = null
			if (inventory[i].itemID != -1)
			{
				ibd.itemName.text = inventory[i].itemName;
			}
			else
			{
				ibd.itemName.text = "";
				ibd.toggle.gameObject.SetActive(false);
			}
		}
	}

	private void SetupInventory()
	{
		for (int i = 0; i < invItems.Length; i++)
		{
			inventory.Add(new Item());
		}
		// LOAD GOES HERE TODO
	}

	void SetGems()
	{
		// change text for gems int value
		gems.text = "Gems: " + gemsVal;
	}
	void SetItemDesc(int itemID)
	{
		if (itemID != -1)
		{
			itemType.text = items[itemID].itemName + ": " + items[itemID].itemValue;
			itemDesc.text = items[itemID].itemDesc;
		}
	}

	public void ShopItemIsPressed(int btnID)
	{
		ShopController shopCont = FindObjectOfType<ShopController>();
		shopCont.itemDesc.text = shopCont.shop[btnID].itemDesc;
		shopCont.itemType.text = shopCont.shop[btnID].itemName;
		shopCont.selectItem = btnID;
		print(shopCont.selectItem);
	}
	public void PurchaseIsPressed()
	{
		ShopController shopCont = FindObjectOfType<ShopController>();
		shopCont.CanItemBePurchased(shopCont.selectItem);
	}
	void CanItemBePurchased(int itemID)
	{
		print(itemID);
		if (gemsVal >= shop[itemID].itemValue)
		{
			gemsVal -= shop[itemID].itemValue;
			ItemBoxDisplay ibd = invItems[itemID].GetComponentInChildren<ItemBoxDisplay>();
			ibd.itemName.text = shop[itemID].itemName;
			ibd.toggle.gameObject.SetActive(true);
			SetItemInInventory(itemID);
			if (shop[itemID].itemType == Item.ItemType.levels)
			{				
				for (int i = 0; i < items.Count; i++)
				{
					if (items[i].itemID == (shop[itemID].itemID + 1))
					{						
						shop[itemID] = items[i];
						break;
					}
				}				
			}
			if (shop[itemID].itemType == Item.ItemType.oneTime)
			{
				shopItems[itemID].GetComponent<Button>().interactable = false;
			}

			SetShopItemNames();
			SetGems();
			// if out of stock disable			
		}
	}

	private void SetItemInInventory(int itemID)
	{
		if (shop[itemID].itemID >= 0 && shop[itemID].itemID <= 4)
		{
			inventory[0] = shop[itemID];
		}
		if (shop[itemID].itemID >= 5 && shop[itemID].itemID <= 9)
		{
			inventory[2] = shop[itemID];
		}
		if (shop[itemID].itemID == 10)
		{
			inventory[1] = shop[itemID];
		}
		if (shop[itemID].itemID == 11)
		{
			inventory[3] = shop[itemID];
		}
	}


	public void ExitAndSaveButton()
	{
		ShopController shopctrl = FindObjectOfType<ShopController>();
		shopctrl.ExitAndSave();
		LevelManager lvl = FindObjectOfType<LevelManager>();
		lvl.LoadLevel("01a Start");
	}

	void ExitAndSave()
	{
		for (int i = 0; i < inventory.Count; i++)
		{			
			GameManager.UPGRADE[i] = inventory[i].itemID;
		}
		SaveShop();
	}

	void SaveShop()
	{
		for (int i = 0; i < inventory.Count; i++)
		{
			print("saved");
			PlayerPrefs.SetInt("Inventory_" + i, inventory[i].itemID);
			print(PlayerPrefs.GetInt("Inventory_" + i));
		}
		for (int i = 0; i < shop.Count; i++)
		{
			print("saved");
			PlayerPrefs.SetInt("Shop_" + i, shop[i].itemID);
			print(PlayerPrefs.GetInt("Shop_" + i));
		}
	}
	void LoadShop()
	{
		for (int i = 0; i < inventory.Count; i++)
		{			
			for (int j = 0; j < items.Count; j++)
			{
				if (items[j].itemID == PlayerPrefs.GetInt("Inventory_" + i))
				{
					inventory[i] = items[j];
					break;
				}
			}					
		}
		for (int i = 0; i < shop.Count; i++)
		{
			for (int j = 0; j < items.Count; j++)
			{
				if (items[j].itemID == PlayerPrefs.GetInt("Shop_" + i))
				{
					shop[i] = items[j];
					break;
				}
			}
		}		
	}
}
