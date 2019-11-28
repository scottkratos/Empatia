using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCompanion : MonoBehaviour
{
    public bool AddDavid;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerMovement>().AddCompanion(AddDavid);
            Destroy(gameObject);
        }
    }
}
