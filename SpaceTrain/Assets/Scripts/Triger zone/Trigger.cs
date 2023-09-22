using System.Collections;
using System.Collections.Generic;
using PlasticGui;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Trigger : MonoBehaviour
{
	public UnityEvent OnEnterTrigger;

	public bool RunOnce = true;


	private bool _beenTriggered = false;

	private Collider2D _collider;

	void Start()
	{
		_collider = GetComponent<Collider2D>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		// check to see if its the player and it has not been triggered before
		if (other.tag.Contains("Player") && !_beenTriggered && RunOnce)
		{
			_beenTriggered = true;
			_collider.enabled = false;

			// calls the event.
			OnEnterTrigger.Invoke();
		}
		else if (!RunOnce && other.tag.Contains("Player"))
		{
			OnEnterTrigger.Invoke();
		}
	}
}
