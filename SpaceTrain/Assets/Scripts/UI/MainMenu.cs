using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public int StartSceneBuildIndex = 1;

	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

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