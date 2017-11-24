using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruible : MonoBehaviour
{
    public GameObject Objeto;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Attack")) { Destroy(Objeto); }
    }
}
