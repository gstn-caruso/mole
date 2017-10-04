using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

	public GameObject goal;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other) {
     if (other.gameObject.CompareTag ("Player")) {
       goal.gameObject.SetActive(true);
			 Debug.Log("Crossed platform");
     }
   }
}
