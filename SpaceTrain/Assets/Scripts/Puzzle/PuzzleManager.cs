using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
	public static PuzzleManager Instance { get; private set; }

	public Dictionary<int, bool> Objectives = new Dictionary<int, bool>();

	public GameObject Door;

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
		if (Objectives.Count <= 0 || Door == null) return;

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
			Door.SetActive(false);
		}
		else
		{
			if (!Door.activeSelf) Door.SetActive(true);
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
