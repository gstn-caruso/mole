using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 5f;
	public float jumpSpeed = 2f;

	void Update ()
	{
			if (Input.GetKey(KeyCode.LeftArrow))
			{
					transform.position += Vector3.left * speed * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.RightArrow))
			{
					transform.position += Vector3.right * speed * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.Space))
			{
					transform.position += Vector3.up * speed * jumpSpeed * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.DownArrow))
			{
					transform.position += Vector3.down * speed * Time.deltaTime;
			}
	}
}
