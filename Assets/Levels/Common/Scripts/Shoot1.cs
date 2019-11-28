using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, FindObjectOfType<PlayerMovement>().transform.position, 2f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && PlayerMovement.control.IsAlive)
        {
            PlayerMovement.control.Damage();
            Destroy(gameObject);
        }
    }
}
