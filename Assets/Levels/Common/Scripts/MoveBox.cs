using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBox : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerMovement script;
    private CompanionMovement compscript;
    private float axis, MaxSpeed;
    private Rigidbody2D rb;
    private float size;
    private bool Grab = false, IsPlayer = false, IsDavid = false, PlayerRange = false, DavidRange = false;
    public static bool IsWithAny = false;
    void Start()
    {
        script = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        rb = GetComponent<Rigidbody2D>();
        size = this.transform.localScale.x * this.transform.localScale.y;
        if (GameObject.FindWithTag("David") != null)
        {
            compscript = GameObject.FindWithTag("David").GetComponent<CompanionMovement>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerRange || DavidRange)
        {
            if (script.IsInteracting)
            {
                script.IsCarring = true;
                script.CarringSpeed(size);
                IsPlayer = true;
                IsWithAny = true;
            }
            else
            {
                IsWithAny = false;
            }
            if (compscript != null)
            {
                if (compscript.CanInteract && IsDavid)
                {
                    compscript.IsCarring = true;
                    compscript.CarringSpeed(size);
                }
                else
                {
                    compscript.IsCarring = false;
                }
            }
            if (IsPlayer)
            {
                axis = script.move;
                MaxSpeed = script.MaxSpeed;
            }
            else
            {
                if (compscript != null)
                {
                    if (compscript.FacingRight)
                    {
                        axis = 1;
                    }
                    else
                    {
                        axis = -1;
                    }
                    MaxSpeed = compscript.MaxSpeed;
                }
            }
            if (script.IsInteracting && IsPlayer)
            {
                Grab = true;
            }
            else
            {
                if (compscript != null)
                {
                    if (compscript.CanInteract && IsDavid)
                    {
                        Grab = true;
                    }
                    else
                    {
                        Grab = false;
                    }
                }
                else
                {
                    Grab = false;
                }
            }
        }
        if (!PlayerRange && !IsWithAny)
        {
            script.IsCarring = false;
            IsPlayer = false;
        }
        if (PlayerRange)
        {
            if (script.IsInteracting)
            {
                GameObject.FindWithTag("Player").transform.Find("Balao").gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                GameObject.FindWithTag("Player").transform.Find("Balao").gameObject.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (Grab)
        {
            rb.velocity = new Vector2(axis * MaxSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            script.CanInteract = true;
            collision.gameObject.GetComponent<PlayerMovement>().HaveObjective = true;
            PlayerRange = true;
        }
        else if (collision.tag == "David")
        {
            IsDavid = true;
            DavidRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            script.CanInteract = false;
            script.IsInteracting = false;
            collision.gameObject.GetComponent<PlayerMovement>().HaveObjective = false;
            collision.gameObject.GetComponent<PlayerMovement>().IsCarring = false;
            GameObject.FindWithTag("Player").transform.Find("Balao").gameObject.GetComponent<SpriteRenderer>().enabled = false;
            PlayerRange = false;
            IsWithAny = false;

        }
        else if (collision.tag == "David")
        {
            IsDavid = false;
            DavidRange = false;
        }
    }
}
