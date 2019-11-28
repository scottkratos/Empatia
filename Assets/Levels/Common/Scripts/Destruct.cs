using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruct : MonoBehaviour
{
    public GameObject Particle;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "tiro")
        {
            Instantiate(Particle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
