using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

	public float MovingDistance = 3f;
	private float _initialPosition;
	private Rigidbody2D _bodyGameObject;
	public float Speed = 2f;

	private void Start ()
	{
		_bodyGameObject = GetComponent<Rigidbody2D>();
		_initialPosition = CurrentPositionX();
	}

	private void Update ()
	{
		if (Mathf.Abs(CurrentPositionX()) >= Mathf.Abs(_initialPosition + MovingDistance))
		{
			Speed *= -1f;
		}

		var movimientoX = CurrentPositionX() + Speed;
		transform.position = new Vector3(movimientoX, transform.position.y, 0);
		
		if (Speed < 0) { transform.localScale = new Vector3(10, 10, 1); }
		if (Speed > 0) { transform.localScale = new Vector3(-10, 10, 1); }
	}

	private float CurrentPositionX()
	{
		return transform.position.x;
	}
}
