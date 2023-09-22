using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
	[SerializeField] private Sprite _idle;
	[SerializeField] private Sprite _run1;
	[SerializeField] private Sprite _run2;
	[SerializeField] private Sprite _jump;
	[SerializeField] private Sprite _fall;

	[SerializeField] private SpriteRenderer _playerRenderer;

	[SerializeField] private float _delayPerFrameAnimation = 1f;

	[Header("Debug Values, do not touch")]

	public Vector2 MoveDir;

	private bool _wasForwad = true;

	private bool _secondAnimation = false;

	private float _time = 0f;

	private float _waitTime = 0f;




	void Update()
	{
		FlipSprite(_wasForwad);

		_time += Time.deltaTime;

		if (MoveDir.x > 0) // right
		{
			_wasForwad = true;


			if (MoveDir.y > 0)
			{
				ChangeSprite(_jump);
				_secondAnimation = false;
			}
			else if (MoveDir.y < -0.01f)
			{
				ChangeSprite(_fall);
				_secondAnimation = false;
			}
			else if (MoveDir.y == 0)
			{
				AnimateRun();
			}
		}
		else if (MoveDir.x < 0) // left
		{
			_wasForwad = false;

			if (MoveDir.y > 0)
			{
				ChangeSprite(_jump);
				_secondAnimation = false;
			}
			else if (MoveDir.y < -0.01f)
			{
				ChangeSprite(_fall);
				_secondAnimation = false;
			}
			else if (MoveDir.y == 0)
			{
				AnimateRun();
			}
		}
		else if (MoveDir.x == 0) // no dir on x
		{
			if (MoveDir.y > 0)
			{
				ChangeSprite(_jump);
				_secondAnimation = false;
			}
			else if (MoveDir.y < -0.01f)
			{
				ChangeSprite(_fall);
				_secondAnimation = false;
			}
			else if (MoveDir.y == 0)
			{
				ChangeSprite(_idle);
				_secondAnimation = false;
			}
		}
	}

	private void ChangeSprite(Sprite sprite)
	{
		_playerRenderer.sprite = sprite;
	}

	private void FlipSprite(bool b)
	{
		_playerRenderer.flipX = b;
	}

	private void AnimateRun()
	{
		if (_time >= _waitTime)
		{
			if (_secondAnimation)
			{
				_secondAnimation = false;
				ChangeSprite(_run2);
			}
			else
			{
				_secondAnimation = true;
				ChangeSprite(_run1);
			}

			_waitTime = _time + _delayPerFrameAnimation;
		}
	}
}
