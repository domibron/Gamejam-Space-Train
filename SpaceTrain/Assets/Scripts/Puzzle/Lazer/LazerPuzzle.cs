using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;

public class LazerPuzzle : MonoBehaviour
{
	public int ID = -1;

#nullable enable
	private int? _ID;
#nullable restore

	private PuzzleManager _pManager;

	[SerializeField] Transform _laserEmitter;
	[SerializeField] Transform _laserBase;

	[SerializeField] LineRenderer _laserBeam;

	[SerializeField] LayerMask _hittableLayers;

	private Vector3 _startPos = Vector3.zero;
	private Vector3 _endPos = Vector3.zero;


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

		_startPos.y = _laserEmitter.position.y;
		_endPos.y = _laserBase.position.y;
	}

	void Update()
	{
		float dist = Vector2.Distance(_laserEmitter.position, _laserBase.position);


		RaycastHit2D hit = Physics2D.Raycast(_laserEmitter.position, Vector2.down, dist + 0.1f);

		//if ((!hit.transform.tag.Contains("Laser") || hit.distance < dist - 1.1f) && ((hit.transform.gameObject.layer & (1 << LayerMask.GetMask("Physics Object"))) != 0 || (hit.transform.gameObject.layer & (1 << LayerMask.GetMask("Player"))) != 0))
		if (hit.transform.gameObject.layer == 3 || hit.transform.gameObject.layer == 8)
		{
			_pManager.UpdateValueInCollection(_ID.Value, true);
			_endPos.y = hit.transform.position.y;

		}
		else
		{
			_pManager.UpdateValueInCollection(_ID.Value, false);
			_endPos.y = _laserBase.position.y;
		}



		_laserBeam.SetPosition(0, _startPos);
		_laserBeam.SetPosition(1, _endPos);
	}

}
