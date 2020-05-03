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


	private bool isPlayAgainButtonClicked;

	private int highScore;

	public bool isGameStarted 
	{ 
		get;
		set;
	}

	public bool isGameOver
	{
		get;
		set;
	}

	[SerializeField]
	public GameObject menuPanel, gamePanel, gameOverPanel;

	[SerializeField]
	private Text gameOverScore, gameOverHighScore;

	[SerializeField]
	private GameObject[] numberOfLives;
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
		score = 0;
		scoreText.text = "" + score;

		if (PlayerPrefs.HasKey(CONSTANTS.HIGHSCORESTRING))
		{
			highScore = PlayerPrefs.GetInt(CONSTANTS.HIGHSCORESTRING);
		}

		if (PlayerPrefs.HasKey(CONSTANTS.PLAY_AGAIN_BUTTON_CLICKED))
		{
			if (PlayerPrefs.GetString(CONSTANTS.PLAY_AGAIN_BUTTON_CLICKED) == "true")
			{
				isPlayAgainButtonClicked = true;
				PlayerPrefs.SetString(CONSTANTS.PLAY_AGAIN_BUTTON_CLICKED, "false");
			}
		}

		if (isPlayAgainButtonClicked == true)
		{
			PlayButtonClicked();
		}
	}

    // Update is called once per frame
    void Update()
    {
		if (isGameStarted == false || isGameOver == true) return;

		timerVal += Time.deltaTime;
		if (timerVal > 1)
		{
			score += 1*scoreMultiplier;
			scoreText.text = score.ToString();
			timerVal = 0;
		}

	}



	public void ReduceLife(int remaingLives)
	{
		//Debug.LogError("reduceLifeCalled" + remaingLives);
		for (int i = 0; i < numberOfLives.Length; i++)
		{
			numberOfLives[i].SetActive(false);	
		}
		for (int i = 0; i < remaingLives; i++)
		{
			numberOfLives[i].SetActive(true);
		}
	}


	public void PlayButtonClicked()
	{
		menuPanel.SetActive(false);
		gamePanel.SetActive(true);
		gameOverPanel.SetActive(false);
		isGameStarted = true;
	}


	public void GameOver()
	{
		isGameOver = true;
		gamePanel.SetActive(false);
		gameOverPanel.SetActive(true);
		gameOverScore.text = "Your Score : " + score;
		if (highScore < score)
		{
			highScore = score;
			PlayerPrefs.SetInt(CONSTANTS.HIGHSCORESTRING, score);

		}
		gameOverHighScore.text = "High Score : " + highScore;
	}



	public void PlayAgainButtonClicked()
	{
		PlayerPrefs.SetString(CONSTANTS.PLAY_AGAIN_BUTTON_CLICKED, "true");
		HomeButtonClicked();
	}


	public void HomeButtonClicked()
	{
		UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
	}
}
