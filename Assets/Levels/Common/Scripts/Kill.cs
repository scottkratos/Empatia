using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "David")
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().Damage();
        }
    }
}
