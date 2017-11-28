using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOne : MonoBehaviour
{
	public int Vida;
	public int PribabilidadDeAtaque;
	public int FuerzaDeSalto;
	public bool Saltando;
	public LayerMask Suelo;
	public float RadioPie;
	public Transform Pie;
	public float Velocidad = 0.1f;
	private Rigidbody2D _rb;

	private Animator _animator;

	private void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
		Saltando = false;
		_animator = GetComponent<Animator>();
	}

	private void Update()
	{
		GetComponent<Renderer>().material.color = Color.white;
			
		transform.position = new Vector3(transform.position.x+Velocidad, transform.position.y, 0);
		if (Velocidad < 0) { transform.localScale = new Vector3(-1, 1, 1); }
		if (Velocidad > 0) { transform.localScale = new Vector3(1, 1, 1); }
		
		Saltando = !EnSuelo();
		if (_animator.GetCurrentAnimatorStateInfo(0).IsName("boss_jumping"))
		{
			Saltar();
		}
		
		var random = Random.Range(0, PribabilidadDeAtaque) == 1;
		var b = Vida < 150 && !_animator.GetCurrentAnimatorStateInfo(0).IsName("boss_jumping") && random && !Saltando;
		_animator.SetBool("Atacando", b);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Attack"))
		{
			Vida -= 10;
			var lado = Mathf.Sign(transform.position.x);
			
		}
		else
		{
			if (other.CompareTag("limite"))
			{
				Velocidad *= -1.05f;
			}
		}
	}
	
	public void RestarVida(int cantidadDeVida)
	{
		Vida -= cantidadDeVida;
	}
	
	public void Saltar()
	{
		if (EnSuelo() && !Saltando)
		{
			Saltando = true;
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, FuerzaDeSalto));
		}
	}
	
	private bool EnSuelo()
	{
		return Physics2D.OverlapCircle(Pie.position, RadioPie, Suelo);
	}
}
