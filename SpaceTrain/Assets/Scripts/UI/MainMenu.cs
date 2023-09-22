using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public int StartSceneBuildIndex = 1;

	public TMP_Text Score;

	private bool _windowMode = true;

	[Header("Hard")]
	public float TimeForHardLevel = 8f;
	public int LevelCountHard = 100;

	[Header("Normal")]
	public float TimeForNormalLevel = 8f;
	public int LevelCountNormal = 100;

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

		if (!PlayerPrefs.HasKey("time"))
		{
			PlayerPrefs.SetFloat("time", TimeForNormalLevel);
		}

		if (!PlayerPrefs.HasKey("lvl"))
		{
			PlayerPrefs.SetInt("lvl", LevelCountNormal);
		}
	}

	// Update is called once per frame
	void Update()
	{

	}



	public void ToggleWindowMode()
	{
		if (_windowMode)
		{
			_windowMode = !_windowMode;
			Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
		}
		else
		{
			_windowMode = !_windowMode;
			Screen.fullScreenMode = FullScreenMode.Windowed;
		}
	}

	public void ResetScore()
	{
		PlayerPrefs.SetInt("score", 0);
		Score.text = $"Score: {PlayerPrefs.GetInt("score")}";
	}

	public void StartGameNormal()
	{
		PlayerPrefs.SetFloat("time", TimeForNormalLevel);
		PlayerPrefs.SetInt("lvl", LevelCountNormal);
		SceneManager.LoadScene(StartSceneBuildIndex);
	}

	public void StartGameHard()
	{
		PlayerPrefs.SetFloat("time", TimeForHardLevel);
		PlayerPrefs.SetInt("lvl", LevelCountHard);
		SceneManager.LoadScene(StartSceneBuildIndex);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}
