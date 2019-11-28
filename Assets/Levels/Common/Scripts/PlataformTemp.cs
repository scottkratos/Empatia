using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformTemp : MonoBehaviour
{
    // Start is called before the first frame update
    public float SecondsPersist = 2, SecondsToRespawn = 2;
    public bool IsRespawning = false, HasInvokeStarted = false;
    public GameObject Particles;
    
    public void StartInvoke()
    {
        Instantiate(Particles, transform.position, transform.rotation);
        Invoke("Disappear", SecondsPersist);
    }
    private void Disappear()
    {
        HasInvokeStarted = false;
        IsRespawning = true;
        Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), GameObject.FindWithTag("Player").GetComponent<CapsuleCollider2D>(), true);
        if (GameObject.FindWithTag("David") != null)
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), GameObject.FindWithTag("David").GetComponent<CapsuleCollider2D>(), true);
        }
        if (GameObject.FindWithTag("tiro") != null)
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), GameObject.FindWithTag("tiro").GetComponent<Collider2D>(), true);
        }
        if (GameObject.FindWithTag("inimigo") != null)
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), GameObject.FindWithTag("inimigo").GetComponent<Collider2D>(), true);
        }
        GetComponent<Renderer>().enabled = false;
        Invoke("Appear", SecondsToRespawn);
    }

    private void Appear()
    {
        IsRespawning = false;
        Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), GameObject.FindWithTag("Player").GetComponent<CapsuleCollider2D>(), false);
        if (GameObject.FindWithTag("David") != null)
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), GameObject.FindWithTag("David").GetComponent<CapsuleCollider2D>(), false);
        }
        if (GameObject.FindWithTag("tiro") != null)
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), GameObject.FindWithTag("tiro").GetComponent<Collider2D>(), false);
        }
        if (GameObject.FindWithTag("inimigo") != null)
        {
            Physics2D.IgnoreCollision(GetComponent<BoxCollider2D>(), GameObject.FindWithTag("inimigo").GetComponent<Collider2D>(), false);
        }

        GetComponent<Renderer>().enabled = true;
    }
}
