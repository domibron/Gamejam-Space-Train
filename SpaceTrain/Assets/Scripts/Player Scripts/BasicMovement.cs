using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

// we will need input detection and a character controller.
[RequireComponent(typeof(WASDInputDetection), typeof(Rigidbody2D))]
public class BasicMovement : MonoBehaviour, IWASDInput
{
	[Header("Changeable variables")]

	// [SerializeField] private float _gravity = -9.81f;

	[SerializeField] private float _jumpHeight = 1.4f;

	[SerializeField] private float _multiplyer = 10;

	[SerializeField] private float _walkSpeed = 5;

	[SerializeField] public LayerMask DoNotDetectLayers;


	// Core 
	private Rigidbody2D _rb;

	private PlayerAnimations _ani;

	private Dictionary<bool[], string> _fourAxisOfMovement;

	private bool[] _currentInputArray = new bool[4]; // structured as W A S D = 0 1 2 3

	private Vector3 _velocity;

	private bool _isGrounded = false;

	void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
		_ani = GetComponent<PlayerAnimations>();
	}

	void Start()
	{
		InitInputDictionary();
		if (MasterSceneManager.Instance != null)
			MasterSceneManager.onLoadNewScene += OnLoadNewScene;
	}

	void Update()
	{
		HandleGroundCheck();
	}

	void FixedUpdate() // runs 50 times every 60 frames
	{
		HandleMovement();
	}

	private void OnLoadNewScene()
	{
		print("Check");

		if (Input.GetKey(KeyCode.W))
		{
			_currentInputArray[0] = true;
		}
		else
			_currentInputArray[0] = false;
		if (Input.GetKey(KeyCode.A))
		{
			_currentInputArray[1] = true;
		}
		else
			_currentInputArray[1] = false;
		if (Input.GetKey(KeyCode.S))
		{
			_currentInputArray[2] = true;
		}
		else
			_currentInputArray[2] = false;
		if (Input.GetKey(KeyCode.D))
		{
			_currentInputArray[3] = true;
		}
		else
			_currentInputArray[3] = false;
		_isGrounded = false;

		print($"{_currentInputArray[0]} {_currentInputArray[1]} {_currentInputArray[2]} {_currentInputArray[3]}");
	}

	private void HandleMovement()
	{
		// TODO add more control.

		Vector2 moveDir = MoveDir();

		// animation
		_ani.MoveDir = new Vector2(moveDir.x, _rb.velocityY);


		// movement
		float ySpeed = _rb.velocity.y;

		_rb.velocity = new Vector2(_rb.velocity.x, 0);

		// clamps to max speed
		if (_rb.velocity.magnitude > _walkSpeed)
		{
			_rb.velocity = _rb.velocity.normalized * _walkSpeed;
		}

		_rb.velocity = new Vector2(_rb.velocity.x, ySpeed);



		// jumping
		if (moveDir.y > 0 && _rb.velocityY <= 0.1f && _isGrounded)
		{
			_rb.AddForce(new Vector2(0, _jumpHeight * _jumpHeight), ForceMode2D.Impulse);
		}

		// left right movement
		_rb.AddForce(new Vector2(moveDir.x, 0) * _walkSpeed * _multiplyer, ForceMode2D.Force);


		// TODO replace this with sting interpitation
		// we are not taking W or S in account.

		if (moveDir.x > 0 && _rb.velocityX < 0)
		{
			// print("right");s
			_rb.velocityX = 0f;
		}
		else if (moveDir.x < 0 && _rb.velocityX > 0)
		{
			// print("left");
			_rb.velocityX = 0f;
		}
		else if ((!_currentInputArray[1] && !_currentInputArray[3]) && (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)))
		{
			_rb.velocityX = 0f; // stops any movement
		}
		// else if ((!_currentInputArray[1] && !_currentInputArray[3]) || (_currentInputArray[1] && _currentInputArray[3]))
		// {
		// 	_rb.velocityX = 0f; // stops any movement
		// }
		else if ((moveDir.x > 0 && _rb.velocityX > 0) || (moveDir.x < 0 && _rb.velocityX < 0))
		{
			// nothing
		}
		else
		{
			// nothing
		}


		// // if we are going left and only A is being held, set velocity to 0.
		// if (_moveDir.x > -0.1 && (_currentInputArray[1] && !_currentInputArray[3]))
		// {
		// 	_rb.velocityX = 0f;
		// }

		// // if we are going right and only D is being held, set velocity to 0.
		// if (_moveDir.x < 0.1 && (!_currentInputArray[1] && _currentInputArray[3]))
		// {
		// 	_rb.velocityX = 0f;
		// }



		// TODO end of todo.
	}

	void HandleGroundCheck()
	{
		// binary shift, the player layer is 3, this takes the player binary int and inverts it so 111111111011 so the player can be ignored. // ignore
		// layer = (1 << layer) | (1 << 6);
		// layer = ~layer;

		int layer = ~DoNotDetectLayers;

		if (Physics2D.Raycast(transform.position, Vector2.down, (transform.localScale.y / 2) + 0.1f, layer))
		{
			_isGrounded = true;
		}
		else
		{
			_isGrounded = false;
		}
	}

	private Vector2 MoveDir()
	{
		bool[] _boolArr = _currentInputArray;

		// if A and D are being held, return false.
		if (_boolArr[1] && _boolArr[3])
		{
			_boolArr[1] = false;
			_boolArr[3] = false;
		}

		if (_boolArr[0] && _boolArr[2])  // W and S
		{
			_boolArr[0] = false;
			_boolArr[2] = false;
		}

		if (_boolArr[0] && _boolArr[1] && _boolArr[2] && _boolArr[3]) // all
		{
			_boolArr[0] = false;
			_boolArr[1] = false;
			_boolArr[2] = false;
			_boolArr[3] = false;
		}

		// convert current input after changes into string axis from dictionary.
		string inputType = GetInputType(_fourAxisOfMovement, _boolArr);

		// value to return.
		Vector2 _dir = Vector2.zero;

		// questioning this if statement.
		if (true)
		{
			// compacted switch statement with lambda.
			_dir = inputType switch  // TODO plan to redo
			{
				"No Input" => Vector2.zero,
				"Jump" => new Vector2(0, 1),
				"Left" => new Vector2(-1, 0),
				"Crouch" => new Vector2(0, -1),
				"Right" => new Vector2(1, 0),
				"Jump Left" => new Vector2(-1, 1),
				"Jump Right" => new Vector2(1, 1),
				"Crouch Left" => new Vector2(-1, -1),
				"Crouch Right" => new Vector2(1, -1),
				_ => Vector2.zero,
			};
		}

		// // ! remove from here, this is not where it should go.
		// if (_boolArr[0] == true && _rb.velocityY <= 0.1f && _isGrounded)
		// {
		// 	_rb.AddForce(new Vector2(0, _jumpHeight * _jumpHeight), ForceMode2D.Impulse);
		// }

		// input is converted to transform directions.
		//_dir = transform.right * _dir.x + transform.up * _dir.y;

		return _dir.normalized; // stops speed boost for strafing. (vectors multiplied by vetors will result of 1 now)

	}

	private string GetInputType(Dictionary<bool[], string> dic, bool[] boolArray)
	{
		string inputType = "";
		for (int keyIndex = 0; keyIndex < dic.Count; keyIndex++)
		{
			if (dic.Keys.ElementAt(keyIndex).SequenceEqual(boolArray))
			{
				dic.TryGetValue(dic.Keys.ElementAt(keyIndex), out inputType);
				return inputType;
			}
		}
		return inputType;
	}

	private void InitInputDictionary() // ordered W, A, S, D
	{
		_fourAxisOfMovement = new Dictionary<bool[], string>
		{
			{ new bool[] { false, false, false, false }, "No Input" },
			{ new bool[] { true, false, false, false }, "Jump" },
			{ new bool[] { false, true, false, false }, "Left" },
			{ new bool[] { false, false, true, false }, "Crouch" },
			{ new bool[] { false, false, false, true }, "Right" },
			{ new bool[] { true, true, false, false }, "Jump Left" },
			{ new bool[] { true, false, false, true }, "Jump Right" },
			{ new bool[] { false, true, true, false }, "Crouch Left" },
			{ new bool[] { false, false, true, true }, "Crouch Right" },
			{ new bool[] { true, false, true, false }, "Jump Crouch" },
			{ new bool[] { false, true, false, true }, "Left Right" },
			{ new bool[] { true, true, true, false }, "Jump Crouch Left" },
			{ new bool[] { true, false, true, true }, "Jump Crouch Right" },
			{ new bool[] { true, true, false, true }, "Left Right jump" },
			{ new bool[] { false, true, true, true }, "Left Right Crouch" },
			{ new bool[] { true, true, true, true }, "All Inputs" }
		};
	}

	// latteral movement keys
	void IWASDInput.D_Key_Held(bool b)
	{
		_currentInputArray[3] = b;
	}

	void IWASDInput.A_Key_Held(bool b)
	{
		_currentInputArray[1] = b;
	}

	// Crouch and jump keys
	void IWASDInput.S_Key_Held(bool b)
	{
		_currentInputArray[2] = b;
	}

	void IWASDInput.W_Key_Held(bool b)
	{
		_currentInputArray[0] = b;
	}
}

