using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterSceneManager : MonoBehaviour
{
	public delegate void OnLoadNewScene();
	public static event OnLoadNewScene onLoadNewScene;


	public static MasterSceneManager Instance { get; private set; }

	[Header("Variables")]

	[SerializeField] private int _buildIndexOffset = 1;

	[SerializeField] private float _timeAllocatedPerLevel = 180f;

	[SerializeField] private bool _overideLoad = false;

	[SerializeField] private String _loseSceneName;

	[SerializeField] private String[] _levelSceneNames = { "RND 1", "RND 2", "RND 3", "RND 4", "RND 5", "RND 6", "RND 7", "RND 8", "RND 9", "RND 10", };


	[Header("Do not change, for debuging")]

	public int CurrentLevel = 0;

	public float LevelTimer = 180f;

	// private variables.

	private bool _gameOver = false;

	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(this);
		}
		else
		{
			Instance = this;
			DontDestroyOnLoad(this);
		}
	}

	void Start()
	{
		if (_overideLoad)
		{
			try
			{
				Debug.LogWarningFormat("Debug overide is enabled on Master Scene Manager");


				//int? currentSceneIndex = null;
				//currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

				//if (currentSceneIndex == null) return; // * there is a return here.
				//CurrentLevel = currentSceneIndex.Value - _buildIndexOffset;
			}
			catch (ArgumentNullException e)
			{
				Debug.LogWarningFormat("A error occourd but I caught it.\nhappen at {0}\n{0}", e.Source, e.Message);
				CurrentLevel = 999;
			}
		}
		else
		{

			// not sure about this
			int currentSceneIndex = 0;
			currentSceneIndex = SceneManager.GetActiveScene().buildIndex - _buildIndexOffset;
			print(currentSceneIndex);
			CurrentLevel = currentSceneIndex - _buildIndexOffset;
		}
	}

	void Update()
	{
		if (_gameOver) // might be dumb, i think it is. could do this in the if statment below.
		{
			Destroy(PlayerInstance.Instance.transform.parent.gameObject);
			SceneManager.LoadScene(_loseSceneName);
			Destroy(this.gameObject);
			return;
		}

		if (CurrentLevel == 100)
		{
			Destroy(PlayerInstance.Instance.transform.parent.gameObject);
			// SceneManager.LoadScene(_loseSceneName);
			Destroy(this.gameObject);
			return;
		}

		if (SceneManager.GetActiveScene().buildIndex != 1 && CurrentLevel != 100)
			LevelTimer -= Time.deltaTime;


		if (LevelTimer <= 0)
		{
			_gameOver = true;
			// Kill player, restart, gameover
		}

		// score
		if (CurrentLevel > PlayerPrefs.GetInt("score"))
		{
			PlayerPrefs.SetInt("score", CurrentLevel);
		}

	}

	// call this once every level.
	public void LoadNextLevel()
	{
		CurrentLevel++;
		if (CurrentLevel != 100 && CurrentLevel <= 8)
		{
			SceneManager.LoadScene(CurrentLevel + _buildIndexOffset);
			LevelTimer = _timeAllocatedPerLevel;
			onLoadNewScene();
		}
		else if (CurrentLevel != 100 && CurrentLevel > 8)
		{
			SceneManager.LoadScene(_levelSceneNames[UnityEngine.Random.Range(0, 9)]);
			LevelTimer = _timeAllocatedPerLevel;
			onLoadNewScene();
		}
		else if (CurrentLevel == 100)
		{
			LevelTimer = _timeAllocatedPerLevel;
			SceneManager.LoadScene("End");
		}
	}
}
