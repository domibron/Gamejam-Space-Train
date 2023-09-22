using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPuzzle : MonoBehaviour, IPlayerInteractable
{
	public int ID = -1;

#nullable enable
	private int? _ID;
#nullable restore

	private PuzzleManager _pManager;

	private bool _leverStatus = false;

	[SerializeField] private SpriteRenderer _lever;

	[SerializeField] private Sprite _leverUp;
	[SerializeField] private Sprite _leverDown;


	void Start()
	{
		_pManager = PuzzleManager.Instance;

		if (_ID == null && ID < 0)
		{
			_ID = _pManager.Objectives.Count;
			_pManager.AddToCollection(_ID.Value);
			ID = _ID.Value;
		}
		else
		{
			_ID = ID;
			_pManager.AddToCollection(_ID.Value);
		}

		ToggleLever(false);

	}

	private void ToggleLever()
	{
		if (_leverStatus)
		{
			_leverStatus = false;
			_lever.sprite = _leverUp;
			_pManager.UpdateValueInCollection(_ID.Value, _leverStatus);
		}
		else
		{
			_leverStatus = true;
			_lever.sprite = _leverDown;
			_pManager.UpdateValueInCollection(_ID.Value, _leverStatus);
		}
	}

	private void ToggleLever(bool b)
	{
		if (!b)
		{
			_leverStatus = false;
			_lever.sprite = _leverUp;
		}
		else
		{
			_leverStatus = true;
			_lever.sprite = _leverDown;

		}
	}

	void IPlayerInteractable.Interacted()
	{
		ToggleLever();
	}

}
