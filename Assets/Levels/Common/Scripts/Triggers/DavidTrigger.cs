using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DavidTrigger : MonoBehaviour
{
    public GameObject linked;
    private bool IsDavidIn = false;
    private GameObject David;

    private void Update()
    {
        if (IsDavidIn)
        {
            if (David.GetComponent<CompanionMovement>().IsFollowing)
            {
                if (David.GetComponent<CompanionMovement>().CanInteract && David.GetComponent<CompanionMovement>().NearPlayer)
                {
                    David.transform.position = new Vector2(linked.transform.position.x, linked.transform.position.y);
                    IsDavidIn = false;
                    David.GetComponent<CompanionMovement>().CanInteract = false;
                }
            }
            else
            {
                if (David.GetComponent<CompanionMovement>().CanInteract)
                {
                    David.transform.position = new Vector2(linked.transform.position.x, linked.transform.position.y);
                    IsDavidIn = false;
                    David.GetComponent<CompanionMovement>().CanInteract = false;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.transform.Find("Balao").gameObject.GetComponent<SpriteRenderer>().enabled = true;
            col.gameObject.GetComponent<PlayerMovement>().HaveObjective = true;
        }
        if (col.gameObject.tag == "David")
        {
            if (linked != null)
            {
                IsDavidIn = true;
                David = col.gameObject;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.transform.Find("Balao").gameObject.GetComponent<SpriteRenderer>().enabled = false;
            col.gameObject.GetComponent<PlayerMovement>().HaveObjective = false;
        }
        if (col.gameObject.tag == "David")
        {
            IsDavidIn = false;
        }
    }
}
