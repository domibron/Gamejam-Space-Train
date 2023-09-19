using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FInputDetection : MonoBehaviour
{
#nullable enable
	// the interface that the result should be outputted to.
	private IFInput? _iFInput;
#nullable restore

	// bool to save if there are any connected scripts.
	private bool _connectedToScript;

	void Awake()
	{
		// sets the refernce to the interface (if there is one).
		_iFInput = GetComponent<IFInput>();

		// this checks that there is a script with the interface, otherwise it will give a null error.
		// Also reduce runtime load when no script is using WASD.
		_connectedToScript = (_iFInput != null ? true : false);
	}

	void Update()
	{
		if (_iFInput == null)
		{
			_connectedToScript = false;
			//return;
		}

		if (_iFInput != null) FKeyDetection();
	}

	private void FKeyDetection()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			_iFInput.F_Key_Pressed();
		}
	}

}
