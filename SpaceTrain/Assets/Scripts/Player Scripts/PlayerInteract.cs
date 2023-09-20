using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(FInputDetection))]
public class PlayerInteract : MonoBehaviour, IFInput
{
	[SerializeField] float _reachRadius = 2f;

	// comment this please ~me

	// super slow and can be optimised.
	void IFInput.F_Key_Pressed()
	{
		RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, _reachRadius, Vector2.zero);

		List<RaycastHit2D> allHits = new();
		List<RaycastHit2D> finalList = new();

		foreach (RaycastHit2D hit in hits)
		{
			allHits.Add(hit);
		}

		// allHits = hits.OfType<RaycastHit2D>().ToList();
		finalList = allHits;

		if (allHits == null || finalList == null) { Debug.LogWarning("null"); return; }
		else if (allHits.Count <= 0 || finalList.Count <= 0) { Debug.LogWarning("emp"); return; }

		foreach (RaycastHit2D hit in allHits.ToList())
		{
			if (hit.transform.GetComponent<IPlayerInteractable>() == null)
			{
				Debug.LogWarningFormat("{0}", hit.transform.name);
				finalList.Remove(hit);
			}
		}

		if (finalList.Count <= 0) { Debug.LogWarning("low count"); return; }

		float distance = Mathf.Infinity;
		RaycastHit2D? finalHit = null;

		if (finalList.Count > 1)
		{
			foreach (RaycastHit2D hit in finalList.ToList())
			{
				float dist = hit.distance;

				if (dist < distance)
				{
					finalHit = hit;
					distance = dist;
				}
			}
		}
		else if (finalList.Count == 1)
		{
			distance = allHits[0].distance;
			finalHit = allHits[0];
		}

		if (distance != Mathf.Infinity && finalHit != null)
		{
			finalHit.Value.transform.GetComponent<IPlayerInteractable>().Interacted();
		}
	}
}
