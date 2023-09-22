using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public int StartSceneBuildIndex = 1;

	public TMP_Text Score;

	// Start is called before the first frame update
	void Start()
	{
		if (PlayerPrefs.HasKey("score"))
		{
			Score.text = $"Score: {PlayerPrefs.GetInt("score")}";
		}
		else
		{
			PlayerPrefs.SetInt("score", 0);
			Score.text = $"Score: {PlayerPrefs.GetInt("score")}";
		}
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void ResetScore()
	{
		PlayerPrefs.SetInt("score", 0);
		Score.text = $"Score: {PlayerPrefs.GetInt("score")}";
	}

	public void StartGame()
	{
		SceneManager.LoadScene(StartSceneBuildIndex);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
