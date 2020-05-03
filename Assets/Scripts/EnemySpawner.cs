using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

	public static EnemySpawner instance;

	[SerializeField]
	private int scoreMileStone = 100;                   //this will define number of cars in the scene
	private int milestoneIncreaser = 100;               //this sets new milestone once old is reached

	[SerializeField]
	private Transform[] spawnPos;                       //store all the available spawn position

	[SerializeField]
	private int policeCarRequired;                      //this will tell how much cars are needed in the scene at a time

	private int currentPoliceCar;                       //this variables keep track of total number of cars in the scene
	private GameObject target;                          //store player reference in this variable
	private int lastPosition, r;

	public int CurrentPoliceCar { get { return currentPoliceCar; } set { currentPoliceCar = value; } }  //getter and setter

	// Use this for initialization
	void Awake()
	{
		if (instance == null) instance = this;
	}

	// Update is called once per frame
	void Update()
	{

		if (UIManager.instance.isGameStarted == false || UIManager.instance.isGameOver == true)
		{
			return;
		}
		else
		{
			if (target == null)                                         //if target is null
			{
				target = GameObject.FindGameObjectWithTag("Player");    //try detecting target again
				return;                                                 //return from the method
			}

			MilestoneIncreaser();                                       //increase milestone

			if (currentPoliceCar <= policeCarRequired)                   //if currentPoliceCar is less than policeCarRequired
			{
				SpawnPoliceCar();                                       //spawn police car
			}
		}

	}
	string EnemyToSpawn;
	void SpawnPoliceCar()                                           //spawn police car
	{
		

		//int numberToChooseEnemyToSpawn = Random.Range(0, 2);
		//if (numberToChooseEnemyToSpawn % 2 == 0)
		//{
		//	EnemyToSpawn = "Enemy_2";
		//}
		//else
		//{
		//	EnemyToSpawn = "Enemy";
		//}

		EnemyToSpawn = "Enemy_2";
		GameObject policeCar = ObjectPooling.instance.GetPooledObject(EnemyToSpawn);     //get police car reference from objectpooling
		RandomPos();

		policeCar.transform.position = new Vector3(spawnPos[r].position.x, 0, spawnPos[r].position.z);  //set the transform
		policeCar.SetActive(true);                                                      //set it active in scene
		policeCar.GetComponent<EnemyDamage>().DefaultSetting();                              //call DefaultSettings method

		currentPoliceCar++;                                                             //increase currentPoliceCar by 1
		lastPosition = r;
	}

	void MilestoneIncreaser()                                               //increase the milestone  
	{
		if (UIManager.instance.Score >= scoreMileStone)                    //if currentScore is greater or equal to scoreMilestone
		{
			scoreMileStone += milestoneIncreaser;                           //increase the milestone 

			if (policeCarRequired < 8)                                      //if max policeCarRequired is less than 8
				policeCarRequired++;                                        //increase policeCarRequired by 1
		}
	}

	void RandomPos()
	{
		int r = Random.Range(0, spawnPos.Length);                                       //get random number between zero and total spawnpos

		while (lastPosition == r)
			r = Random.Range(0, spawnPos.Length);
		Debug.Log("the position chosen is " + r);
	}

}