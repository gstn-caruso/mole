using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pinches : MonoBehaviour {

	private void OnCollisionEnter2D(Collision2D other)
	{
		other.gameObject.SendMessage("RestarVida",100);
	}
}
