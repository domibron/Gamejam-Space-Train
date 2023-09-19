using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterSceneManager : MonoBehaviour
{
	[Header("Variables")]

	public static MasterSceneManager Instance;

	[SerializeField] private int _buildIndexOffset = 1;

	[SerializeField] private float _timeAllocatedPerLevel = 180f;

	[SerializeField] private bool _overideLoad = false;

	[Header("Do not change, for debuging")]

	public int CurrentLevel = 0;

	public float LevelTimer = 180f;

	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
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


				int? currentSceneIndex = null;
				currentSceneIndex = SceneManager.GetActiveScene().buildIndex - _buildIndexOffset;

				if (currentSceneIndex == null) return; // * there is a return here.
				CurrentLevel = currentSceneIndex.Value;
			}
			catch (ArgumentNullException e)
			{
				Debug.LogWarningFormat("A error occourd but I caught it.\nhappen at {0}\n{0}", e.Source, e.Message);
				CurrentLevel = 999;
			}
		}
	}

	void Update()
	{
		LevelTimer -= Time.deltaTime;

		if (LevelTimer <= 0)
		{
			// Kill player, restart, gameover
		}
	}

	// call this once every level.
	public void LoadNextLevel()
	{
		SceneManager.LoadScene(CurrentLevel + _buildIndexOffset);
		CurrentLevel++;
	}

	// move player

	// so on


}
