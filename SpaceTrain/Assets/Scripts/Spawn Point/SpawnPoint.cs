using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
	[SerializeField] private bool Enabled = true;

	void Awake()
	{
		if (Enabled && PlayerInstance.Instance != null)
			PlayerInstance.Instance.MovePlayer(transform.position);
	}

}
