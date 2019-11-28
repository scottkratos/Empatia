using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayLever : MonoBehaviour
{
    public GameObject[] Link;
    public Sprite Pressed, Not;
    public AudioClip[] clips;
    private InteractBase[] script;
    public int[] Type;
    private bool IsPlayer = false, IsDavid = false, IsBox = false;

    private void Start()
    {
        script = new InteractBase[Link.Length];
        for (int r = 0; r < Type.Length; r++)
        {
            if (Type[r] == 0)
            {
                script[r] = Link[r].GetComponent<PlataformCreate>();
            }
            else if (Type[r] == 1)
            {
                script[r] = Link[r].GetComponent<PlataformMoving>();
            }
            else if (Type[r] == 2)
            {
                script[r] = Link[r].GetComponent<PlataformHalf>();
            }
            else if (Type[r] == 3)
            {
                script[r] = Link[r].GetComponent<SimpleMove>();
            }
            else if (Type[r] == 4)
            {
                script[r] = Link[r].transform.GetChild(0).gameObject.GetComponent<EspinhosCreate>();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!IsPlayer && !IsDavid && !IsBox)
            {
                for (int r = 0; r < Type.Length; r++)
                {
                    if (Type[r] == 0 || Type[r] == 1 || Type[r] == 2 || Type[r] == 3 || Type[r] == 4)
                    {
                        script[r].Activate();
                    }
                }
                IsPlayer = true;
                GetComponent<AudioSource>().clip = clips[0];
                GetComponent<AudioSource>().Play();
            }
        }
        if (collision.tag == "David")
        {
            if (!IsPlayer && !IsDavid && !IsBox)
            {
                for (int r = 0; r < Type.Length; r++)
                {
                    if (Type[r] == 0 || Type[r] == 1 || Type[r] == 2 || Type[r] == 3 || Type[r] == 4)
                    {
                        script[r].Activate();
                    }
                }
                IsDavid = true;
                GetComponent<AudioSource>().clip = clips[0];
                GetComponent<AudioSource>().Play();
            }
        }
        if (collision.tag == "box")
        {
            if (!IsPlayer && !IsDavid && !IsBox)
            {
                for (int r = 0; r < Type.Length; r++)
                {
                    if (Type[r] == 0 || Type[r] == 1 || Type[r] == 2 || Type[r] == 3 || Type[r] == 4)
                    {
                        script[r].Activate();
                    }
                }
                IsBox = true;
                GetComponent<AudioSource>().clip = clips[0];
                GetComponent<AudioSource>().Play();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (IsPlayer)
            {
                for (int r = 0; r < Type.Length; r++)
                {
                    if (Type[r] == 0 || Type[r] == 1 || Type[r] == 2 || Type[r] == 4)
                    {
                        script[r].Activate();
                    }
                }
                IsPlayer = false;
                GetComponent<AudioSource>().clip = clips[1];
                GetComponent<AudioSource>().Play();
            }
        }
        if (collision.tag == "David")
        {
            if (IsDavid)
            {
                for (int r = 0; r < Type.Length; r++)
                {
                    if (Type[r] == 0 || Type[r] == 1 || Type[r] == 2 || Type[r] == 4)
                    {
                        script[r].Activate();
                    }
                }
                IsDavid = false;
                GetComponent<AudioSource>().clip = clips[1];
                GetComponent<AudioSource>().Play();
            }
        }
        if (collision.tag == "box")
        {
            if (IsBox)
            {
                for (int r = 0; r < Type.Length; r++)
                {
                    if (Type[r] == 0 || Type[r] == 1 || Type[r] == 2 || Type[r] == 4)
                    {
                        script[r].Activate();
                    }
                }
                IsBox = false;
                GetComponent<AudioSource>().clip = clips[1];
                GetComponent<AudioSource>().Play();
            }
        }
    }

    private void Update()
    {
        if (IsPlayer || IsDavid || IsBox)
        {
            GetComponent<SpriteRenderer>().sprite = Pressed;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = Not;
        }
    }
}
