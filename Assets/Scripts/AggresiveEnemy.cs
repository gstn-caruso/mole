using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using NUnit.Framework.Constraints;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class AggresiveEnemy : MonoBehaviour
{

	public float RadioDeVision;
	public float RadioDeAtaque;
	public float Velocidad;
	public GameObject Enemigo;

	private Vector3 _posicionInicial;
	private Rigidbody2D _rigidbody2D;

	private void Start ()
	{
		_posicionInicial = transform.position;
		_rigidbody2D = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		var target = _posicionInicial;
		var hit = Physics2D.Raycast(
			transform.position,
			Enemigo.transform.position - transform.position,
			RadioDeVision,
			1 << LayerMask.NameToLayer("Default")
		);
		var foward = transform.TransformDirection(Enemigo.transform.position - transform.position);
		Debug.DrawRay(transform.position, foward, Color.red);
		if (hit.collider != null && hit.collider.CompareTag("Player"))
		{
			Debug.Log("Moviendo");
			target = Enemigo.transform.position;
			var distance = Vector3.Distance(target, transform.position);
			var dir = (target - transform.position).normalized;
			_rigidbody2D.MovePosition(transform.position + dir * Velocidad * Time.deltaTime);
		}

//		if (target != _posicionInicial && distance < RadioDeAtaque)
//		{
//			// Animacion de descanso
//		}
//		else
//		{
//			_rigidbody2D.MovePosition(transform.position + dir * Velocidad * Time.deltaTime);
//		}
		
		Debug.DrawLine(transform.position, target, Color.green);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position, RadioDeVision);
		Gizmos.DrawWireSphere(transform.position, RadioDeAtaque);
	}
}
