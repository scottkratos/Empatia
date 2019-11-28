using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E : MonoBehaviour
{
    public Sprite[] Sprites;

    private void Update()
    {
        GetComponent<SpriteRenderer>().enabled = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().transform.Find("Balao").gameObject.GetComponent<SpriteRenderer>().enabled;
        if (PlayerMovement.control.FacingRight)
        {
            GetComponent<SpriteRenderer>().sprite = Sprites[0];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = Sprites[1];
        }
    }
}
