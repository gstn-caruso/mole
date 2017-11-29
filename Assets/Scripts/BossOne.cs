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
	public GameObject _barraDeVida;
	public GameObject _gateLevelTwo;

	private Animator _animator;

	private void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
		Saltando = false;
		_animator = GetComponent<Animator>();
	}

	private void Update()
	{
		if(Vida != 200) { _barraDeVida.SetActive(true); }
		if (Vida >= 0)
		{
			transform.position = new Vector3(transform.position.x + Velocidad, transform.position.y, 0);
			if (Velocidad < 0)
			{
				transform.localScale = new Vector3(-1, 1, 1);
			}
			if (Velocidad > 0)
			{
				transform.localScale = new Vector3(1, 1, 1);
			}

			Saltando = !EnSuelo();
			if (_animator.GetCurrentAnimatorStateInfo(0).IsName("boss_jumping"))
			{
				Saltar();
			}

			var random = Random.Range(0, PribabilidadDeAtaque) == 1;
			var b = Vida < 150 && !_animator.GetCurrentAnimatorStateInfo(0).IsName("boss_jumping") && random && !Saltando;
			_animator.SetBool("Atacando", b);
		}
		else
		{
			_animator.SetBool("Muerto", true);
			_gateLevelTwo.SetActive(true);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Attack"))
		{
			Vida -= 10;
			var lado = Mathf.Sign(transform.position.x);
			_barraDeVida.SetActive(true);
			_barraDeVida.SendMessage("RecibirDaño", 5);
			
		}
		else
		{
			if (other.CompareTag("limite"))
			{
				Velocidad *= -1.05f;
			}
		}
	}
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player") && Vida >= 1)
		{
			var args = new object[2];
			args[0] = transform.position.x;
			args[1] = 10;
			other.gameObject.SendMessage("RetrocesoPorDañoEnemigo", args);
		}
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
