
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformCreate : InteractBase
{
    public bool IsDestroy = false;

    private void Start()
    {
        if (!IsDestroy)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
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
    }
}
