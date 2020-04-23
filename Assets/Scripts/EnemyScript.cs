
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
	// Start is called before the first frame update

	[SerializeField]
	private float enemeySpeed = 30 , rotatingSpeed=8;

	[SerializeField]
	private GameObject target;
	private Rigidbody myBody;


	void Start()
    {
		myBody = GetComponent<Rigidbody>();
		target= GameObject.FindGameObjectWithTag("Player");
	}

	private void FixedUpdate()
	{
		if (target == null)
		{
			GameObject.FindGameObjectWithTag("Player");
			return;
		}

		Vector3 pointTarget = transform.position - target.transform.position;  //calculate Distance between player and enemy


		pointTarget.Normalize(); // When normalized, a vector keeps the same direction but its length is 1.0. it basically provides the value between zero and one

		float val = Vector3.Cross(pointTarget, transform.forward).y;  //get the cross product between two vectors that is target and Enemy and their Y position
	
		myBody.angularVelocity = rotatingSpeed * val * new Vector3(0, 1, 0);
		myBody.velocity = transform.forward * enemeySpeed;
	}

	// Update is called once per frame
	void Update()
    {
        
    }
}
