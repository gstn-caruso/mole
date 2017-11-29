using UnityEngine;

public class EnemyController : MonoBehaviour
{

	public float DistanciaMaxima = 3f;
	public float Velocidad = 0.1f;
	private float _minX, _maxX;

	private void Start ()
	{
		var posicionInicialX = PosicionActualEnX();
		_minX = posicionInicialX - DistanciaMaxima;
		_maxX = posicionInicialX + DistanciaMaxima;
	}

	private void Update ()
	{
		if (EstaFueraDelRango()) { Velocidad *= -1f; }
		var movimientoX = PosicionActualEnX() + Velocidad;
		transform.position = new Vector3(movimientoX, transform.position.y, 0);
		
		if (Velocidad < 0) { transform.localScale = new Vector3(10, 10, 1); }
		if (Velocidad > 0) { transform.localScale = new Vector3(-10, 10, 1); }
	}

	private bool EstaFueraDelRango()
	{
		return PosicionActualEnX() > _maxX || PosicionActualEnX() < _minX;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			var args = new object[2];
			args[0] = PosicionActualEnX();
			args[1] = 10;
			other.gameObject.SendMessage("RetrocesoPorDañoEnemigo", args);
		}
	}

	private float PosicionActualEnX()
	{
		return transform.position.x;
	}
}
