using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance : MonoBehaviour
{
	public static PlayerInstance Instance { get; private set; }

	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			// Destroy(this);
		}
		else
		{
			Instance = this;
		}
	}

	public void MovePlayer(Transform positionToMoveTo)
	{
		transform.position = positionToMoveTo.position;
	}

	public void MovePlayer(Vector2 positionToMoveTo)
	{
		transform.position = new Vector3(positionToMoveTo.x, positionToMoveTo.y, 0f);
	}

	public void MovePlayer(Vector3 positionToMoveTo)
	{
		transform.position = positionToMoveTo;
	}
}
