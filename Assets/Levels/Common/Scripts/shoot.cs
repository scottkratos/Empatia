using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shoot : MonoBehaviour
{
    public float velocidade;
    void Awake()
    {
        Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), GameObject.FindWithTag("Player").GetComponent<Collider2D>());
        if (GameObject.FindWithTag("David") != null)
        {
            Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), GameObject.FindWithTag("David").GetComponent<Collider2D>());
        }
        Invoke("Kill", 5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "David" && collision.gameObject.tag != "tiro")
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void Kill()
    {
        GameObject.Destroy(this.gameObject);
    }
}