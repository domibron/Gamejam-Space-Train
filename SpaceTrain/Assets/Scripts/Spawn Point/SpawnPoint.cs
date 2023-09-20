using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
	public bool Enabled = true;

	void Start()
	{
		if (Enabled && PlayerInstance.Instance != null)
			PlayerInstance.Instance.MovePlayer(transform.position);
	}

}
