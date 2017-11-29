using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelThree : MonoBehaviour {
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			SceneManager.LoadScene(4, LoadSceneMode.Single);
		}
	}
}
