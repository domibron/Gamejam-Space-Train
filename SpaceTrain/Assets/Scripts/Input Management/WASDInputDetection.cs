using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDInputDetection : MonoBehaviour
{
#nullable enable
	// the interface that the result should be outputted to.
	private IWASDInput? _iWASDInput;
#nullable restore

	// bool to save if there are any connected scripts.
	private bool _connectedToScript;

	void Awake()
	{
		// sets the refernce to the interface (if there is one).
		_iWASDInput = GetComponent<IWASDInput>();

		// this checks that there is a script with the interface, otherwise it will give a null error.
		// Also reduce runtime load when no script is using WASD.
		_connectedToScript = (_iWASDInput != null ? true : false);
	}

	void Update()
	{
		// * could add a check to see if connected interface is removed.

		// check to see if there is a connected script. (if a script is using WASD interface "IWASDInput")
		// guard clause.
		if (!_connectedToScript) return;

		// TODO Could make this better.
		// stops a error when there is no interface.
		if (_iWASDInput == null)
		{
			_connectedToScript = false;
			return;
		}


		if (Input.GetKeyDown(KeyCode.W)) // W
		{
			_iWASDInput.W_Key_Held(true);
		}
		else if (Input.GetKeyUp(KeyCode.W))
		{
			_iWASDInput.W_Key_Held(false);
		}

		if (Input.GetKeyDown(KeyCode.A)) // A
		{
			_iWASDInput.A_Key_Held(true);
		}
		else if (Input.GetKeyUp(KeyCode.A))
		{
			_iWASDInput.A_Key_Held(false);
		}

		if (Input.GetKeyDown(KeyCode.S)) // S
		{
			_iWASDInput.S_Key_Held(true);
		}
		else if (Input.GetKeyUp(KeyCode.S))
		{
			_iWASDInput.S_Key_Held(false);
		}

		if (Input.GetKeyDown(KeyCode.D)) // D
		{
			_iWASDInput.D_Key_Held(true);
		}
		else if (Input.GetKeyUp(KeyCode.D))
		{
			_iWASDInput.D_Key_Held(false);
		}
	}
}
