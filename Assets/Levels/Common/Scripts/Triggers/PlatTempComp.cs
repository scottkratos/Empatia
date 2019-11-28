using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatTempComp : MonoBehaviour
{
    private PlataformTemp script;
    private bool UpDavid = false;

    private void Start()
    {
        script = gameObject.GetComponentInParent<PlataformTemp>();
    }

    private void Update()
    {
        if (UpDavid)
        {
            GameObject.FindWithTag("David").GetComponent<CompanionMovement>().IsDetectingPlataforms = !script.IsRespawning;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "David")
        {
            UpDavid = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "David")
        {
            UpDavid = false;
        }
    }
}
