using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartTextSetterTimer : MonoBehaviour
{

	private TMP_Text _uiText;

	// [SerializeField, TextArea] private string Text;

	private int _maxLevel;
	private float _allocatedTime;

	// Start is called before the first frame update
	void Start()
	{
		// print(MasterSceneManager.Instance != null);
		if (MasterSceneManager.Instance != null)
		{
			_uiText = GetComponent<TMP_Text>();

			_maxLevel = MasterSceneManager.Instance.HighLevel;
			_allocatedTime = MasterSceneManager.Instance.TimeAllocatedPerLevel;

			_uiText.text = $"CountDown and Level counter.\nEvery level has {_allocatedTime} seconds to be compleated.\nGet to level {_maxLevel}!";
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}
