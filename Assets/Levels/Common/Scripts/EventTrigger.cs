using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventTrigger : MonoBehaviour
{
    public GameObject[] Link;
    private InteractBase[] script;
    private bool Enter = true;
    public int[] Type;

    private void Start()
    {
        script = new InteractBase[Link.Length];
        for (int i = 0; Link.Length > i; i++)
        {
            if (Type[i] == 0)
            {
                script[i] = Link[i].GetComponent<PlataformCreate>();
            }
            else if (Type[i] == 1)
            {
                script[i] = Link[i].GetComponent<PlataformMoving>();
            }
            else if (Type[i] == 2)
            {
                script[i] = Link[i].GetComponent<PlataformHalf>();
            }
            else if (Type[i] == 3)
            {
                script[i] = Link[i].GetComponent<SimpleMove>();
            }
            else if (Type[i] == 4)
            {
                script[i] = Link[i].transform.GetChild(0).gameObject.GetComponent<EspinhosCreate>();
            }
        }
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Enter)
            {
                for (int i = 0; Link.Length > i; i++)
                {
                    if (Type[i] == 0 || Type[i] == 1 || Type[i] == 2 || Type[i] == 3 || Type[i] == 4)
                    {
                        script[i].Activate();

                    }
                }
                Enter = false;
            }
        }
    }
}
