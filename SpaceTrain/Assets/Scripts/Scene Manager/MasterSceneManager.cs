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
