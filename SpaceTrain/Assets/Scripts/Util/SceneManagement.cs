using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
	public void LoadScene(int buildIndex)
	{
		SceneManager.LoadScene(buildIndex);
	}

	public void DestroyPlayerAndLoadScene(int buildIndex)
	{
		Destroy(PlayerInstance.Instance.transform.parent.gameObject);
		SceneManager.LoadScene(buildIndex);
	}
}
