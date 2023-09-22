using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscToMainMenu : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Destroy(PlayerInstance.Instance.transform.parent.gameObject);
			Destroy(MasterSceneManager.Instance.gameObject);
			SceneManager.LoadScene(0);
		}
	}
}
