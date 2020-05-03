using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
	// Start is called before the first frame update




	[SerializeField]
	private int enemyTotalLife = 3;
	public float invincibleTime = 2;


	[SerializeField]
	private GameObject smokeEffect, fireEffect, explosionEffect;
	[SerializeField]
	private int enemyRemainingLife;
	public float currentInvincibleTime;
	private bool isColliding = false;

	void Start()
    {
		enemyRemainingLife = enemyTotalLife;
    }



	private void Update()
	{
		if (isColliding)
		{
			currentInvincibleTime -= Time.deltaTime;
			if (currentInvincibleTime <= 0)
			{
				ReduceEnemyLife();
			}
		}
	}

	private void OnCollisionStay(Collision other)
	{
		if (other.collider.CompareTag("Enemy"))
		{
			isColliding = true;
		}
	}

	public void OnCollisionExit(Collision other)
	{

		if (other.collider.CompareTag("Enemy"))
		{
			isColliding = false;
		}
	}

	public void ReduceEnemyLife()
	{
		enemyRemainingLife--;
		currentInvincibleTime = invincibleTime;

		if (enemyRemainingLife == 2)
		{
			smokeEffect.SetActive(true);
		}
		else	if(enemyRemainingLife == 1)
		{
			smokeEffect.SetActive(false);
			fireEffect.SetActive(true);
		}
		else
		if (enemyRemainingLife <= 0)
		{
			gameObject.SetActive(false);
			EnemySpawner.instance.CurrentPoliceCar--;
			GameObject explosion = ObjectPooling.instance.GetPooledObject("Explosion");
			explosion.SetActive(true);
			explosion.transform.position = this.transform.position;
			Instantiate(explosionEffect, transform.position, Quaternion.identity);
			Debug.Log("It Ends Here");//Deactivate the Object and Destroy it as The Enemy Has Lost its Life
		}
	}

	public void DefaultSetting()
	{
		//Setting the Default Values of the prefab
		//life deactivate smoke and Fire Fxx
		//Reset the life
		enemyRemainingLife = enemyTotalLife;
	}
}
