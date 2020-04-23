using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

	public static UIManager instance;
	// Start is called before the first frame update
	[SerializeField]
	private Text scoreText;
	public int score=0;
	public int scoreMultiplier;
	private float timerVal;


	public int Score
	{
		get;
		set;
	}

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

		timerVal += Time.deltaTime;
		if (timerVal > 1)
		{
			score += 1*scoreMultiplier;
			scoreText.text = score.ToString();
			timerVal = 0;
		}

	}
}
