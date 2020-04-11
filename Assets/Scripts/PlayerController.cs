using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private float speed;
	[SerializeField]
	private float angleSpeed;


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


}
