using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinityGround : MonoBehaviour
{
	// Start is called before the first frame update

	[SerializeField]
	private Renderer groundRenderer;
	[SerializeField]
	private float parallaxSpeed = 10f;

	[SerializeField]
	private float groundMovementSpeed = 40f;


	private GameObject playerReference;
	private float offSetX, offSetY;


    // Update is called once per frame
    void Update()
    {
		if (playerReference == null)
		{
			playerReference = GameObject.FindGameObjectWithTag("Player");
			return;
		}

		if (playerReference != null)
		{
			ScrollBackground(parallaxSpeed, groundRenderer);
		}

    }

	private void FixedUpdate()
	{
		if (playerReference != null)
		{
			Movement();
		}
		else
			return;
	}

	void Movement()
	{
		float posX = playerReference.transform.position.x;
		float posZ = playerReference.transform.position.z;

		transform.position = new Vector3(posX, transform.position.y, posZ);
	}

	void ScrollBackground(float scrollSpeed,Renderer rend)
	{
		offSetX = transform.position.x / parallaxSpeed;
		offSetY = transform.position.z / parallaxSpeed;
		rend.material.SetTextureOffset("_MainTex", new Vector2(offSetX, offSetY));
	}
}
