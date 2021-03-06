﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float VelocidadX = 0.2f;
	public float FuerzaDeSalto = 800f;
	public float DiferenciaDeAlturaEntreContrapartes = 39f;
	public Transform Pie;
	public GameObject ataque;
	public AudioSource audioSource;
	public AudioClip jumpSound;
	public AudioClip punchSound;
	public AudioClip atkSound;
	public float RadioPie;
	public LayerMask Suelo;
	public bool EnLaContraparte;
	public bool Saltando;
	public int Vida;
	private Animator _animator;
	public GameObject _barraDeVida;

	private void Start()
	{
		Vida = 100;
		_animator = GetComponent<Animator>();
	}

	private void Update()
	{
		if (Vida < 1) { GameOver(); }
		var stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
		var attacking = stateInfo.IsName("Player_attack");
		
		EnLaContraparte = transform.position.y <= -20f;
		Saltando = !EnSuelo();

		var inputX = Input.GetAxis("Horizontal");
		
		var playerSpeed = Mathf.Abs(inputX);
		_animator.SetFloat("Speed", playerSpeed);

		var movimientoX = transform.position.x + (inputX * VelocidadX);
		transform.position = new Vector3(movimientoX, transform.position.y, 0);
		if (inputX > 0) { transform.localScale = new Vector3(10, 10, 1); }
		if (inputX < 0) { transform.localScale = new Vector3(-10, 10, 1); }

		if (EnSuelo() && Input.GetKeyDown(KeyCode.Space)) { Saltar(); }

		if (Input.GetKeyDown(KeyCode.LeftShift)) {
//			var multiplicadorContraparte = EnLaContraparte ? 1 : - 1;
//			var nuevoY = transform.position.y + (DiferenciaDeAlturaEntreContrapartes * multiplicadorContraparte);
//			transform.position = new Vector3(transform.position.x, nuevoY, 0);
		}

		if (Input.GetKeyDown(KeyCode.LeftAlt))
		{
	 		_animator.SetTrigger("Atacando");
			audioSource.PlayOneShot(atkSound);
		}

		if (attacking)
		{
			var playbackTime = stateInfo.normalizedTime;
			ataque.SetActive(playbackTime > 0.1 && playbackTime < 0.9);
		}

}

	private void GameOver()
	{
		SceneManager.LoadScene(1, LoadSceneMode.Single);
	}

	private bool EnSuelo()
	{
		return Physics2D.OverlapCircle(Pie.position, RadioPie, Suelo);
	}

	public void Saltar()
	{
		if (EnSuelo() && !Saltando)
		{
			Saltando = true;
			audioSource.PlayOneShot(jumpSound);
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, FuerzaDeSalto));
		}
	}

	public void RestarVida(int cantidadDeVida)
	{
		Vida -= cantidadDeVida;
	}

	public void RetrocesoPorDañoEnemigo(object[] args)
	{
		audioSource.PlayOneShot(punchSound);
		Saltando = true;
		Vida -= (int) args[1];
		var lado = Mathf.Sign((float) args[0] - transform.position.x);
		GetComponent<Rigidbody2D>().AddForce(Vector2.left * lado * 15f, ForceMode2D.Impulse);
		_barraDeVida.SendMessage("RecibirDaño", (int) args[1]);
	}
}
