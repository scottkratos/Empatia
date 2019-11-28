using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aspirador : MonoBehaviour
{
    Transform Target;
    RaycastHit2D Hit;
    bool Follow;
    public float Speed;
    public GameObject explosion;
    private bool FacingRight = false, IsAttacking = false, CanMove = true;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Follow == true)
        {
            if (CanMove)
            {
                transform.position = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
            }
            if (Vector2.Distance(transform.position, Target.position) < 2f && !IsAttacking)
            {
                IsAttacking = true;
                CanMove = false;
            }
        }
        if (PlayerMovement.control.transform.position.x - transform.position.x > 0 && !FacingRight && CanMove)
        {
            Flip();
        }
        else if (PlayerMovement.control.transform.position.x - transform.position.x < 0 && FacingRight && CanMove)
        {
            Flip();
        }
        GetComponent<Animator>().SetBool("Follow", Follow);
        GetComponent<Animator>().SetBool("Attack", IsAttacking);
    }
    private void Flip()
    {
        if (FacingRight)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        FacingRight = !FacingRight;
    }
    private void FixedUpdate()
    {
        Hit = Physics2D.Raycast(transform.position, (transform.right) * -1);
        if (Hit.collider != null)
        {
            if (Hit.collider.tag == "Player")
            {
                if (Vector2.Distance(transform.position, Target.position) < 5)
                {
                    Follow = true;
                }
                else if (Vector2.Distance(transform.position, Target.position) > 8)
                {
                    Follow = false;
                }
            }
        }
        
    }
    public void Damage()
    {
        if (Vector2.Distance(transform.position, Target.position) < 2f)
        {
            if (PlayerMovement.control.IsAlive)
            {
                PlayerMovement.control.Damage();
            }
        }
        IsAttacking = false;
        CanMove = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "tiro")
        {
            Destroy(collision.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
