using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatTempPlayer : MonoBehaviour
{
    private PlataformTemp script;

    private void Start()
    {
        script = gameObject.GetComponentInParent<PlataformTemp>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!script.IsRespawning && !script.HasInvokeStarted)
        {
            if (collision.tag == "Player" || collision.tag == "David" || collision.tag == "tiro" || collision.tag == "inimigo")
            {
                script.HasInvokeStarted = true;
                script.StartInvoke();
            }
        }
    }
}
