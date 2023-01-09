using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Item Data/Projectile")]
public class BulletData : InventoryItemData
{
	public TypeOfEffect typeOfProjectile;
	public int charges;
}
