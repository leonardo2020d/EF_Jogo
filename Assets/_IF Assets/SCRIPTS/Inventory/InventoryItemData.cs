using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Inventory Item Data/Simple")]
public class InventoryItemData : ScriptableObject
{
	public string id;
	public string displayNameBR;
	public string displayNameEN; 
	public Sprite icon;
	public GameObject prefab;
}
