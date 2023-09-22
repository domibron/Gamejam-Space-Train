using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamShake : MonoBehaviour
{
	public float Aplitude;

	public float YFrequency;
	public float XFrequency;

	private float _time;

	void FixedUpdate()
	{
		_time += Time.deltaTime;

		// float lerp = Mathf.Lerp(UnityEngine.Random.Range(-1, 1), UnityEngine.Random.Range(-1, 1), Mathf.Sin(_time));


		transform.position = new Vector3(Mathf.Sin(Mathf.Sin(_time * XFrequency)) - Mathf.Sin(_time * 2f * XFrequency) * Aplitude, Mathf.Cos(_time * YFrequency) * Aplitude, -10);
	}
}
