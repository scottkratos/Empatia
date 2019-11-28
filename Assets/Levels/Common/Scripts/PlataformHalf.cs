using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformHalf : InteractBase
{
    public bool IsDestroy = false;

    private void Start()
    {
        if (!IsDestroy)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Renderer>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<Renderer>().enabled = true;
        }
    }

    public override void Activate()
    {
        if (!IsDestroy)
        {
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<Renderer>().enabled = true;
            IsDestroy = true;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Renderer>().enabled = false;
            IsDestroy = false;
        }
        if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().IsInteracting)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().IsInteracting = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), GameObject.FindWithTag("Player").GetComponent<CapsuleCollider2D>(), true);
        }
        if (collision.tag == "David")
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), GameObject.FindWithTag("David").GetComponent<CapsuleCollider2D>(), true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), GameObject.FindWithTag("Player").GetComponent<CapsuleCollider2D>(), false);
        }
        if (collision.tag == "David")
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), GameObject.FindWithTag("David").GetComponent<CapsuleCollider2D>(), false);
        }
    }
}
