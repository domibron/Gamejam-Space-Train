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

	PuzzleManager PManager;

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

	void OnTriggerEnter2D(Collider2D other)
	{

		PManager.UpdateValueInCollection(_ID.Value, true);

	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		PManager.UpdateValueInCollection(_ID.Value, true);
	}

	void OnTriggerExit2D(Collider2D other)
	{
		PManager.UpdateValueInCollection(_ID.Value, false);

	}


}