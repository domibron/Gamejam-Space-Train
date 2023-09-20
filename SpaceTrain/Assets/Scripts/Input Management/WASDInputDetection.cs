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



		// TODO Could make this better.
		// stops a error when there is no interface.
		if (_iWASDInput == null)
		{
			_connectedToScript = false;
			//return;
		}

		// check to see if there is a connected script. (if a script is using WASD interface "IWASDInput") 
		if (_iWASDInput != null) WKeyDetection();

		if (_iWASDInput != null) AKeyDetection();

		if (_iWASDInput != null) SKeyDetection();

		if (_iWASDInput != null) DKeyDetection();
	}

	private void WKeyDetection()
	{
		// Need to check if the key was pressed and is currently being held.
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKey(KeyCode.W)) // W
		{
			_iWASDInput.W_Key_Held(true);
		}
		else if (Input.GetKeyUp(KeyCode.W) || !Input.GetKeyDown(KeyCode.W))
		{
			_iWASDInput.W_Key_Held(false);
		}
	}

	private void AKeyDetection()
	{
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKey(KeyCode.A)) // A
		{
			_iWASDInput.A_Key_Held(true);
		}
		else if (Input.GetKeyUp(KeyCode.A) || !Input.GetKeyDown(KeyCode.A))
		{
			_iWASDInput.A_Key_Held(false);
		}
	}

	private void SKeyDetection()
	{
		if (Input.GetKeyDown(KeyCode.S) || Input.GetKey(KeyCode.S)) // S
		{
			_iWASDInput.S_Key_Held(true);
		}
		else if (Input.GetKeyUp(KeyCode.S) || !Input.GetKeyDown(KeyCode.S))
		{
			_iWASDInput.S_Key_Held(false);
		}
	}

	private void DKeyDetection()
	{
		if (Input.GetKeyDown(KeyCode.D) || Input.GetKey(KeyCode.D)) // D
		{
			_iWASDInput.D_Key_Held(true);
		}
		else if (Input.GetKeyUp(KeyCode.D) || !Input.GetKeyDown(KeyCode.D))
		{
			_iWASDInput.D_Key_Held(false);
		}
	}

}
