using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class LevelCountAndTimer : MonoBehaviour
{
	[SerializeField] private TMP_Text _display;

#nullable enable
	private MasterSceneManager? master;
#nullable restore

	private bool _connectedToMasterSceneManager = false;


	void Start()
	{
		master = MasterSceneManager.Instance;

		if (master != null)
		{
			_connectedToMasterSceneManager = true;
		}
	}

	void Update()
	{
		// guard caluse to stop errors.
		if (!_connectedToMasterSceneManager)
		{
			Debug.LogWarningFormat("There is no Master Scene Manager for me to use!");
			return;
		}

		string textToDisplay = "";



		textToDisplay = $"{CreateTimerText(master.LevelTimer)}\nlvl {master.CurrentLevel}";

		_display.text = textToDisplay;
	}

	private string CreateTimerText(float seconds)
	{
		int minuets = Mathf.FloorToInt(seconds / 60f);

		seconds -= minuets * 60f;

		// int secs = Mathf.FloorToInt(seconds);

		string str = $"{minuets.ToString("00")}:{seconds.ToString("00.0")}";

		return str;
	}
}
