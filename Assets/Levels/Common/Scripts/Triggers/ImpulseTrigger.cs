using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseTrigger : MonoBehaviour
{
    public Vector2 Impulse;
    private bool IsPlayerIn = false, IsDavidIn = false;

    private void Update()
    {
        if (IsPlayerIn && IsDavidIn)
        {
            if (GameObject.FindWithTag("David").GetComponent<CompanionMovement>().CanInteract)
            {
                GameObject.FindWithTag("David").GetComponent<CompanionMovement>().rb.velocity = Impulse;
                GameObject.FindWithTag("David").GetComponent<CompanionMovement>().CanInteract = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IsPlayerIn = true;
            collision.transform.Find("Balao").gameObject.GetComponent<SpriteRenderer>().enabled = true;
            collision.gameObject.GetComponent<PlayerMovement>().HaveObjective = true;
        }
        if (collision.tag == "David")
        {
            IsDavidIn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            IsPlayerIn = false;
            collision.transform.Find("Balao").gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.GetComponent<PlayerMovement>().HaveObjective = false;
        }
        if (collision.tag == "David")
        {
            IsDavidIn = false;
            GameObject.FindWithTag("David").GetComponent<CompanionMovement>().CanInteract = false;
        }
    }
}
