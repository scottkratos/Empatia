using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : MonoBehaviour
{
    public GameObject explosion;
    Transform Target;
    RaycastHit2D Hit;
    bool Follow;
    public float Speed;
    public Sprite[] Sprites;
    private bool FacingRight;
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
            transform.position = Vector2.MoveTowards(transform.position, Target.position, Speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, Target.position) < 1.2f)
            {
                if (PlayerMovement.control.IsAlive)
                {
                    PlayerMovement.control.Damage();
                    Instantiate(explosion, transform.position, transform.rotation);
                    Destroy(gameObject);
                }
            }
        }
        if (PlayerMovement.control.transform.position.x - transform.position.x > 0 && !FacingRight)
        {
            Flip();
        }
        else if (PlayerMovement.control.transform.position.x - transform.position.x < 0 && FacingRight)
        {
            Flip();
        }
        GetComponent<Animator>().SetBool("Follow", Follow);
        if (Follow)
        {
            transform.GetChild(0).transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = Sprites[0];
        }
        else
        {
            transform.GetChild(0).transform.GetChild(6).GetComponent<SpriteRenderer>().sprite = Sprites[1];
        }
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
        void FixedUpdate()
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
                else if (Vector2.Distance(transform.position, Target.position) < 8)
                {
                    Follow = false;
                }
            }
        }
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
