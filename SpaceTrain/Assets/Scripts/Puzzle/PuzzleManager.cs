using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
	public static PuzzleManager Instance { get; private set; }

	public Dictionary<int, bool> Objectives = new Dictionary<int, bool>();

	// public GameObject Door;

	public SpriteRenderer DoorSprite;

	public Collider2D DoorCollider;

	public Sprite DoorClosed;
	public Sprite DoorOpen;


	void Awake()
	{
		if (Instance != null && Instance != this)
		{
			//Destroy(this)
		}
		else
		{
			Instance = this;
		}
	}

	void Update()
	{
		if (Objectives.Count <= 0 || DoorSprite == null) return;

		bool allCompleate = false;

		for (int i = 0; i < Objectives.Count; i++)
		{
			if (Objectives[i] == true)
			{
				allCompleate = true;
			}
			else
			{
				allCompleate = false;
				//continue;
				break;
			}
		}

		if (allCompleate == true)
		{
			DoorCollider.enabled = false;
			DoorSprite.sprite = DoorOpen;
		}
		else
		{
			// if (!DoorCollider.enabled)
			// {
			DoorCollider.enabled = true;
			DoorSprite.sprite = DoorClosed;
			// }
		}
	}

	public void AddToCollection(int ID, bool value = false)
	{
		Objectives.Add(ID, value);
	}

	public void RemoveFromCollection(int ID)
	{
		Objectives.Remove(ID);
	}

	public void UpdateValueInCollection(int ID, bool value)
	{
		Objectives[ID] = value;
	}



}
