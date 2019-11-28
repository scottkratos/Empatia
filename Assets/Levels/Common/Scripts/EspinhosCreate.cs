
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspinhosCreate : InteractBase
{
    public bool IsDestroy = false;

    private void Start()
    {
        if (!IsDestroy)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public override void Activate()
    {
        if (!IsDestroy)
        {
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            IsDestroy = true;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false);
            IsDestroy = false;
        }
    }
}
