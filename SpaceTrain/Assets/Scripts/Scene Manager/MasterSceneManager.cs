using System;
using System.Collections;
using System.Collections.Generic;
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

	[Header("Do not change, for debuging")]

	public int CurrentLevel = 0;

	public float LevelTimer = 180f;

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


				int? currentSceneIndex = null;
				currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

				if (currentSceneIndex == null) return; // * there is a return here.
				CurrentLevel = currentSceneIndex.Value - _buildIndexOffset;
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
			int? currentSceneIndex = null;
			currentSceneIndex = SceneManager.GetActiveScene().buildIndex - _buildIndexOffset;

			if (currentSceneIndex == null) return; // * there is a return here.
			CurrentLevel = currentSceneIndex.Value - _buildIndexOffset;
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
		CurrentLevel++;
		SceneManager.LoadScene(CurrentLevel + _buildIndexOffset);
		LevelTimer = _timeAllocatedPerLevel;
		onLoadNewScene();
	}



	// move player

	// so on


}
