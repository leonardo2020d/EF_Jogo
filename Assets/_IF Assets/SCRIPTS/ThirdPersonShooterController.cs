using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;

using StarterAssets;

public class ThirdPersonShooterController : MonoBehaviour
{
	[SerializeField] private CinemachineVirtualCamera aimVirtualCamera;

	[SerializeField] private float normalSensitivity;

	[SerializeField] private float aimSensitivity;

	[SerializeField] private LayerMask aimColliderMask;

	[SerializeField] private Transform debugTransform;

	[SerializeField] private Transform[] bulletProjectilePrefab;
	[SerializeField] private Transform spawnBulletPosition;

	private  ThirdPersonController thirdPersonController;

	private StarterAssetsInputs starterAssetsInputs;

	private void Awake()
	{
		thirdPersonController = GetComponent<ThirdPersonController>();
		starterAssetsInputs = GetComponent<StarterAssetsInputs>();
	}

	private void Update()
	{
		Vector3 mouseWorldPosition = Vector3.zero;
		Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
		Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
		if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderMask))
		{
			mouseWorldPosition = raycastHit.point;
		}

		if (starterAssetsInputs.aim)
		{
			aimVirtualCamera.gameObject.SetActive(true);
			thirdPersonController.SetSensitivity(aimSensitivity);
			thirdPersonController.SetRotateOnMove(false);

			// aim direction
			Vector3 worldAimTarget = mouseWorldPosition;
			worldAimTarget.y = transform.position.y;
			Vector3 aimDirection = worldAimTarget - transform.position.normalized;
			transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
		}
		else
		{
			aimVirtualCamera.gameObject.SetActive(false);
			thirdPersonController.SetSensitivity(normalSensitivity);
			thirdPersonController.SetRotateOnMove(true);
		}

		if (starterAssetsInputs.shoot)
		{
			Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
			Instantiate(bulletProjectilePrefab[0], spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
			starterAssetsInputs.shoot = false;
			
		}
	}
}
