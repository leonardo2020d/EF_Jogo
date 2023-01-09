using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using StarterAssets;

public class ItemObject : MonoBehaviour
{
	public InventoryItemData referenceItem;
	
	public GameObject player;
	private ThirdPersonController thirdPersonController;
	private StarterAssetsInputs starterAssetsInputs;

	public void OnHandlePickupItem()
	{
		InventorySystem.current.Add(referenceItem);
		Destroy(gameObject);
	}

	public void Start()
	{
		player = GameObject.FindGameObjectsWithTag("Player")[0];
		thirdPersonController = player.GetComponent<ThirdPersonController>();
		starterAssetsInputs = player.GetComponent<StarterAssetsInputs>();
		if(starterAssetsInputs == null)
		{
			Debug.Log("Deu ruim");
		}
	}

	public void Update()
	{
		if (starterAssetsInputs.pickup)
		{
			if(Vector3.Distance(player.transform.position, this.transform.position) <= 3f)
			{
				//to do: animation
				OnHandlePickupItem();
			}
		}
		

	}

}
