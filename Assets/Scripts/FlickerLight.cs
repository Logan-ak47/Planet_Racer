using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLight : MonoBehaviour
{
	// Start is called before the first frame update


	float t;
	Light testLight;
    void Start()
    {
		testLight = GetComponent<Light>();
		t = Random.Range(0f, 1f);
		StartCoroutine(FlashLight());
    }

    // Update is called once per frame
    IEnumerator FlashLight()
	{
		while (true)
		{
			
			yield return new WaitForSeconds(t);
			testLight.enabled = !testLight.enabled;
		}
	}
}
