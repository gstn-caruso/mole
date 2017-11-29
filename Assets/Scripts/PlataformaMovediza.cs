using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.Timeline;

public class PlataformaMovediza : MonoBehaviour
{
	public float Speed;
	public float Distance;
//	public GameObject player;
	private float _initialX;
	private float _initialY;

	private void Start()
	{
//		player = GameObject.FindGameObjectWithTag("Player");
		_initialX = transform.position.x;
		_initialY = transform.position.y;
	}

	void Update() {
		var pos = new Vector3 (_initialX+Mathf.PingPong (Speed * Time.time, Distance),_initialY,0);
		transform.position = pos;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		other.transform.SetParent(transform);
	}
	private void OnCollisionExit2D(Collision2D other)
	{
		other.transform.SetParent(null);
	}
}
