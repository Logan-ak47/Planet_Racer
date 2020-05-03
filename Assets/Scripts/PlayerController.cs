using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private float speed;
	[SerializeField]
	private float angleSpeed;

	[SerializeField]
	private GameObject MenuPanel;


	[SerializeField]
	private int currentLifeOfPlayer = 3;


	public float Speed { get { return speed; } }

	private Rigidbody playerBody;
	private int currentAngle;
	// Start is called before the first frame update
    void Start()
    {
		playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

	private void Update()
	{
		if (Input.GetMouseButton(0))
		{
			if (MenuPanel.activeSelf == true)
			{
				Debug.Log("game started");
				MenuPanel.SetActive(false);
				UIManager.instance.isGameStarted = true;
				UIManager.instance.gamePanel.SetActive(true);
			}


			float x = Input.mousePosition.x;
			if(x < Screen.width/2 && x > 0)
			{
				MoveLeft();
			}
			if (x > Screen.width / 2 && x < Screen.width)
			{
				MoveRight();
			}
		}
	}


	public void MoveLeft()
	{
		Debug.Log("Moveleft called");
		transform.Rotate(-Vector3.up * angleSpeed * Time.deltaTime);
	}

	public void MoveRight()
	{
		Debug.Log("MoveRight called");
		transform.Rotate(Vector3.up * angleSpeed * Time.deltaTime);
	}



	public void ReduceEnemyLife()
	{
		currentLifeOfPlayer--;

		UIManager.instance.ReduceLife(currentLifeOfPlayer);
		if (currentLifeOfPlayer <= 0)
		{
			UIManager.instance.GameOver();
			Debug.Log("Players game Over");
			gameObject.SetActive(false);
		}

	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Enemy"))
		{
			ReduceEnemyLife();//ReduceLife
			other.GetComponent<EnemyDamage>().ReduceEnemyLife();
		}
	}


}
