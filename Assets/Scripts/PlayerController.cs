using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float VelocidadX = 0.2f;
	public float FuerzaDeSalto = 800f;
	public float DiferenciaDeAlturaEntreContrapartes = 39f;
	public Transform Pie;
	public float RadioPie;
	public LayerMask Suelo;
	public bool EnLaContraparte;
	public bool Saltando;
	private Animator _animator;

	private void Start()
	{
		_animator = GetComponent<Animator>();
	}

	private void Update(){
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
		}

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
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0, FuerzaDeSalto));
		}
	}

	public void RetrocesoPorDañoEnemigo(float posicionEnemigaEnX)
	{
		var lado = Mathf.Sign(posicionEnemigaEnX - transform.position.x);
		GetComponent<Rigidbody2D>().AddForce(Vector2.left * lado * FuerzaDeSalto, ForceMode2D.Impulse);
	}
}
