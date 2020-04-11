using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	// Start is called before the first frame update

	public GameObject Player;


	public Vector3 offSet;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
		Movement();

	}

	void Movement()
	{
		float posX = Player.transform.position.x;
		float posZ = Player.transform.position.z - offSet.z;

		transform.position = new Vector3(posX, transform.position.y, posZ);

	}
}
