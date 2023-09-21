using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ButtonPuzzle : MonoBehaviour
{
	public int ID = -1;

#nullable enable
	private int? _ID;
#nullable restore

	private int count = 0;

	PuzzleManager PManager;

	[SerializeField] private Transform _buttonObject;

	void Start()
	{
		PManager = PuzzleManager.Instance;

		if (_ID == null && ID < 0)
		{
			_ID = PManager.Objectives.Count;
			PManager.AddToCollection(_ID.Value);
			ID = _ID.Value;
		}
		else
		{
			_ID = ID;
			PManager.AddToCollection(_ID.Value);
		}

	}

	void ButtonPress(bool b)
	{
		if (b)
			_buttonObject.localPosition = new Vector3(0f, 0.05f, 0f);
		else
			_buttonObject.localPosition = new Vector3(0f, 0.125f, 0f);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		count++;

		PManager.UpdateValueInCollection(_ID.Value, true);
		ButtonPress(true);
	}

	private void OnTriggerStay2D(Collider2D collision)
	{

		PManager.UpdateValueInCollection(_ID.Value, true);
		ButtonPress(true);

	}

	void OnTriggerExit2D(Collider2D other)
	{
		count--;
		if (count <= 0)
		{
			PManager.UpdateValueInCollection(_ID.Value, false);
			ButtonPress(false);
		}
	}


}