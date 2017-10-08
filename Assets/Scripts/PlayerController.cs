using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float velocidadX = 0.2f;
	public float fuerzaDeSalto = 800f;
	public Transform pie;
	public float radioPie;
	public LayerMask suelo;
	public bool enSuelo;
	public bool enLaContraparte;

	void Update(){
		enLaContraparte = transform.position.y <= -20;

		float inputX = Input.GetAxis("Horizontal");
		float movimientoX = transform.position.x + (inputX * velocidadX);
		transform.position = new Vector3(movimientoX, transform.position.y, 0);
		if (inputX > 0) { transform.localScale = new Vector3(10, 10, 1); }
		if (inputX < 0) { transform.localScale = new Vector3(-10, 10, 1); }

		enSuelo = Physics2D.OverlapCircle(pie.position, radioPie, suelo);
		if (enSuelo && Input.GetKeyDown(KeyCode.Space)) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2 (0, fuerzaDeSalto));
		}

		if(Input.GetKeyDown(KeyCode.LeftShift)) {
			float nuevoY;
			if(!enLaContraparte) {
				nuevoY = transform.position.y - 39f;
			} else {
				nuevoY = transform.position.y + 39f;
			}
			transform.position = new Vector3(transform.position.x, nuevoY, 0);
		}
	}
}
