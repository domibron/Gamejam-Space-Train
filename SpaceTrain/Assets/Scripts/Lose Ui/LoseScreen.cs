using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoseScreen : MonoBehaviour
{
	public TMP_Text Score;



	// Start is called before the first frame update
	void Start()
	{
		Score.text = $"Score: {PlayerPrefs.GetInt("score")}";
	}

	// Update is called once per frame
	void Update()
	{

	}

	public void Retry()
	{
		SceneManager.LoadScene(1);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene(0);
	}
}
