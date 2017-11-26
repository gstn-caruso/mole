using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruible : MonoBehaviour
{
    public GameObject Objeto;
    public int Vida;
    public float FuerzaDeSalto;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Vida <= 0) { Destroy(Objeto); }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Attack"))
        {
            Vida -= 10;
            var lado = Mathf.Sign(transform.position.x);
            _rb.AddForce(Vector2.left * lado * 15f, ForceMode2D.Impulse);
            _rb.AddForce(new Vector2(0, FuerzaDeSalto));

        }
    }
    
    public void RestarVida(int cantidadDeVida)
    {
        Vida -= cantidadDeVida;
    }

}
