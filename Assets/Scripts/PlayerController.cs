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
	public bool EnSuelo;
	public bool EnLaContraparte;

	private void Update(){
		EnLaContraparte = transform.position.y <= -20f;

		var inputX = Input.GetAxis("Horizontal");
		var movimientoX = transform.position.x + (inputX * VelocidadX);
		transform.position = new Vector3(movimientoX, transform.position.y, 0);
		if (inputX > 0) { transform.localScale = new Vector3(10, 10, 1); }
		if (inputX < 0) { transform.localScale = new Vector3(-10, 10, 1); }

		EnSuelo = Physics2D.OverlapCircle(Pie.position, RadioPie, Suelo);
		if (EnSuelo && Input.GetKeyDown(KeyCode.Space)) {
			GetComponent<Rigidbody2D>().AddForce(new Vector2 (0, FuerzaDeSalto));
		}

		if (Input.GetKeyDown(KeyCode.LeftShift)) {
			var multiplicadorContraparte = EnLaContraparte ? 1 : - 1;
			var nuevoY = transform.position.y + (DiferenciaDeAlturaEntreContrapartes * multiplicadorContraparte);
			transform.position = new Vector3(transform.position.x, nuevoY, 0);
		}

}
}
