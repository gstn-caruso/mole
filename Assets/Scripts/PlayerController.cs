using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed = 5f;
	public float jumpSpeed = 2;
	private Rigidbody2D rb;
	public bool gorunded;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

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
			if (Input.GetKeyDown(KeyCode.Space))
			{
				rb.AddForce(Vector2.up * jumpSpeed);
			}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		// grounded = true;
	}

	void OnTriggerStay2D(Collider2D other)
	{
		// grounded = true;
	}

	void OnTriggerExit2D(Collider2D other)
	{
		// grounded = false;
	}
}
