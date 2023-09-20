using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NextLevelTrigger : MonoBehaviour
{
	[SerializeField] public UnityEvent OnEnterTrigger;

	private MasterSceneManager _master;

	private bool _beenTriggered = false;

	Collider2D _collider;

	void Start()
	{
		_master = MasterSceneManager.Instance;

		_collider = GetComponent<Collider2D>();

		if (_master != null)
		{
			// adds the NextLevel funtion to the list of listerners, so you dont have to.
			OnEnterTrigger.AddListener(NextLevel);
		}

		if (_collider != null)
		{
			_collider.isTrigger = true;
		}
	}

	void NextLevel()
	{
		_master.LoadNextLevel();
	}

	// this is called when a collider enters a trigger. 
	void OnTriggerEnter2D(Collider2D other)
	{
		// check to see if its the player and it has not been triggered before
		if (other.tag.Contains("Player") && !_beenTriggered)
		{
			_beenTriggered = true;
			_collider.enabled = false;

			// calls the event.
			OnEnterTrigger.Invoke();
		}
	}
}
