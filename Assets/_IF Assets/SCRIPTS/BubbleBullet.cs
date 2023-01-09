using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBullet : MonoBehaviour
{
	private Rigidbody bulletRigidBody;

	[SerializeField] private GameObject hitEnemyFX;
	[SerializeField] private GameObject hitFailFX;

	public float speed = 5f;

	// Start is called before the first frame update
	void Awake()
	{
		bulletRigidBody = GetComponent<Rigidbody>();
	}

	private void Start()
	{
		bulletRigidBody.velocity = transform.forward * speed;
	}

	private void OnTriggerEnter(Collider other)
	{
		DummyEnemyController dummy = other.GetComponent<DummyEnemyController>();
		if (dummy != null)
		{
			//Hit enemy
			Instantiate(hitEnemyFX, transform.position, Quaternion.identity);
			if(dummy.weakness == TypeOfEffect.Bubble)
			{
				dummy.lifePoints -= 5; 
			}
			else
			{
				dummy.lifePoints--;
			}

			Debug.Log(dummy.lifePoints);
			if(dummy.lifePoints <= 0)
			{
				Destroy(other.gameObject);
				Debug.Log("Destroy");
			}
			
		}
		else
		{
			//hit something else
			Instantiate(hitFailFX, transform.position, Quaternion.identity);
		}

		Destroy(gameObject);
	}

	// Update is called once per frame
	void Update()
	{

	}
}
