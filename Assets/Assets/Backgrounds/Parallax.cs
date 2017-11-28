using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
	public Transform[] objects;
	public float[] scales;
	public float smoothing;

	private Vector3 previousPosition;
	
	void Start ()
	{
		previousPosition = transform.position;
	}

	void Update()
	{
		if (previousPosition != transform.position)
		{
			for (var i = 0; i < objects.Length; i++)
			{
				var parallax = (previousPosition.x - transform.position.x) * scales[i];
				var position = objects[i].position;
				position.x -= parallax;

				objects[i].position = Vector3.Lerp(objects[i].position, position, smoothing);
			}

			previousPosition = transform.position;
		}
	}
}
