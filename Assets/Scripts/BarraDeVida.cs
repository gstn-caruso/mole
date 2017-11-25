using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
	private float _vida, _vidaMaxima = 100f;
	public Image BarraCantidadVida;

	void Start ()
	{
		_vida = _vidaMaxima;
	}

	public void RecibirDaño(float cantidadDeDaño)
	{
		_vida = Mathf.Clamp(_vida - cantidadDeDaño, 0f, _vidaMaxima);
		BarraCantidadVida.transform.localScale = new Vector2(_vida/_vidaMaxima, 1);
	}
}
