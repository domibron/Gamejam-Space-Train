using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableItem : MonoBehaviour, IPlayerInteractable
{
	[SerializeField] public UnityEvent OnInteract;

	[SerializeField] private bool _turnOnTrigger = true;

	void Awake()
	{
#nullable enable
		Collider2D? anyCollider = GetComponent<Collider2D>();
#nullable restore

		if (anyCollider != null && _turnOnTrigger)
		{
			anyCollider.isTrigger = true;
			Debug.LogWarningFormat("Enabled the trigger on {0}", transform.name);
		}
		else
		{
			anyCollider.isTrigger = false;
			Debug.LogWarningFormat("Disabled the trigger on {0}", transform.name);
		}

		gameObject.layer = 6;
	}

	void IPlayerInteractable.Interacted()
	{
		OnInteract.Invoke();
	}
}
