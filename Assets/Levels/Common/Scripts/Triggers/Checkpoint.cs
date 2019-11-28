using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool IsCurrent = false;
    public int Level = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            for (int i = 0; GameObject.FindGameObjectsWithTag("Check").Length > i; i++)
            {
                if (GameObject.FindGameObjectsWithTag("Check")[i] == gameObject)
                {
                    IsCurrent = true;
                    collision.GetComponent<PlayerMovement>().Level = Level;
                }
                else
                {
                    GameObject.FindGameObjectsWithTag("Check")[i].GetComponent<Checkpoint>().IsCurrent = false;
                }
            }
        }
    }
}
