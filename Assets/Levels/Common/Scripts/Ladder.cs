using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private bool IsPlayer = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerMovement>().CanInteract = true;
            collision.GetComponent<PlayerMovement>().HaveObjective = true;
            IsPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerMovement>().CanInteract = false;
            collision.GetComponent<PlayerMovement>().IsInteracting = false;
            IsPlayer = false;
            collision.GetComponent<PlayerMovement>().HaveObjective = false;
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().rb.gravityScale = 2;
            Physics2D.IgnoreCollision(GetComponent<CapsuleCollider2D>(), GameObject.FindWithTag("Player").GetComponent<Collider2D>(), false);
            collision.GetComponent<PlayerMovement>().IsInLadder = false;
            GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().transform.Find("Balao").gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void Update()
    {
        if (IsPlayer)
        {
            if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().IsInteracting)
            {
                Physics2D.IgnoreCollision(GetComponent<CapsuleCollider2D>(), GameObject.FindWithTag("Player").GetComponent<Collider2D>(), true);
                GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().IsInLadder = true;
                GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().transform.Find("Balao").gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().transform.position = new Vector2(transform.position.x, GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().transform.position.y);
                GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().rb.gravityScale = 0;

            }
            else
            {
                Physics2D.IgnoreCollision(GetComponent<CapsuleCollider2D>(), GameObject.FindWithTag("Player").GetComponent<Collider2D>(), false);
                GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().IsInLadder = false;
                GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().transform.Find("Balao").gameObject.GetComponent<SpriteRenderer>().enabled = true;
                GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().rb.gravityScale = 2;
            }
        }
    }
}
