using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject[] Link;
    private PlayerMovement scripto;
    private InteractBase[] script;
    public int[] Type;
    public bool CanEnterInfinite = false, HaveInfo = false;
    public int[] Numbers;
    private bool Enter = true, DavidInteract = false, PlayerInteract = false, IsLeft = false;

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
			else if (Type[r] == 5) {
				script[r] = Link[r].GetComponent<Puzzle1>();
			}
        }
    }

    public void Press()
    {
        GetComponent<AudioSource>().Play();
        for (int r = 0; r < Type.Length; r++)
        {
            if (Type[r] == 0 || Type[r] == 1 || Type[r] == 2 || Type[r] == 3 || Type[r] == 4)
            {
                script[r].Activate();
            }
			else if (Type[r] == 5) 
			{
				script[r].SendIntInfo(Numbers[r]);
			}
        }
        if (!CanEnterInfinite)
        {
            Enter = false;
        }
        if (PlayerInteract)
        {
            scripto.IsInteracting = false;
            scripto.CanMove = false;
            scripto.IsLevering = true;
            if (scripto.FacingRight)
            {
                scripto.gameObject.transform.position = new Vector3(transform.position.x + 0.4f, scripto.gameObject.transform.position.y, scripto.gameObject.transform.position.z);
            }
            else
            {
                scripto.gameObject.transform.position = new Vector3(transform.position.x - 0.4f, scripto.gameObject.transform.position.y, scripto.gameObject.transform.position.z);
            }
            IsLeft = !IsLeft;
            if (IsLeft)
            {
                if(scripto.FacingRight)
                {
                    scripto.Flip();
                }
            }
            else
            {
                if (!scripto.FacingRight)
                {
                    scripto.Flip();
                }
            }
            GetComponent<Animator>().SetBool("IsLeft", IsLeft);
        }
        else
        {
            CompanionMovement.control.transform.position = new Vector3(transform.position.x, CompanionMovement.control.transform.position.y, CompanionMovement.control.transform.position.z);
            CompanionMovement.control.CanMove = false;
            CompanionMovement.control.IsLevering = true;
            IsLeft = !IsLeft;
            if (IsLeft)
            {
                if (CompanionMovement.control.FacingRight)
                {
                    CompanionMovement.control.Flip();
                }
            }
            else
            {
                if (!CompanionMovement.control.FacingRight)
                {
                    CompanionMovement.control.Flip();
                }
            }
            GetComponent<Animator>().SetBool("IsLeft", IsLeft);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Enter)
        {
            if (collision.tag == "Player")
            {
                collision.GetComponent<PlayerMovement>().CanInteract = true;
                PlayerInteract = true;
                collision.transform.Find("Balao").gameObject.GetComponent<SpriteRenderer>().enabled = true;
                scripto = collision.GetComponent<PlayerMovement>();
            }
            if (collision.tag == "David")
            {
                DavidInteract = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerMovement>().CanInteract = false;
            PlayerInteract = false;
            collision.transform.Find("Balao").gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (collision.tag == "David")
        {
            DavidInteract = false;
        }
    }

    private void Update()
    {
        if (GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().IsInteracting)
        {
            if (PlayerInteract)
            {
                Press();
            }
        }
        if (DavidInteract)
        {
            if (GameObject.FindWithTag("David").GetComponent<CompanionMovement>().CanInteract)
            {
                Press();
                GameObject.FindWithTag("David").GetComponent<CompanionMovement>().CanInteract = false;
                DavidInteract = false;
            }
        }
    }
}
