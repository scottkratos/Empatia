using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrigger : MonoBehaviour
{
    public bool MoveToPlayer = false, MakeInteract = false, IsPlayerCalling = false, IsBoxInPosition = false, IsPlatInPosition = false;
    public Vector3 Location;
    public int HowManyUses = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("David"))
        {
            if (!IsPlayerCalling)
            {
                if (!IsBoxInPosition)
                {
                    if (!IsPlatInPosition)
                    {
                        if (HowManyUses > 0)
                        {
                            if (!MoveToPlayer)
                            {
                                collision.GetComponent<CompanionMovement>().GotoLoc = Location;
                                collision.GetComponent<CompanionMovement>().IsFollowing = false;
                            }
                            else
                            {
                                collision.GetComponent<CompanionMovement>().IsFollowing = true;
                            }
                            if (MakeInteract)
                            {
                                collision.GetComponent<CompanionMovement>().CanInteract = true;
                            }
                            else
                            {
                                collision.GetComponent<CompanionMovement>().CanInteract = false;
                            }
                            HowManyUses--;
                        }
                    }
                }
            }
        }
        if (collision.tag == ("Player"))
        {
            if (IsPlayerCalling)
            {
                if (!IsBoxInPosition)
                {
                    if (!IsPlatInPosition)
                    {
                        if (HowManyUses > 0)
                        {
                            if (!MoveToPlayer)
                            {
                                GameObject.FindWithTag("David").GetComponent<CompanionMovement>().GotoLoc = Location;
                                GameObject.FindWithTag("David").GetComponent<CompanionMovement>().IsFollowing = false;
                            }
                            else
                            {
                                GameObject.FindWithTag("David").GetComponent<CompanionMovement>().IsFollowing = true;
                            }
                            if (MakeInteract)
                            {
                                GameObject.FindWithTag("David").GetComponent<CompanionMovement>().CanInteract = true;
                            }
                            else
                            {
                                GameObject.FindWithTag("David").GetComponent<CompanionMovement>().CanInteract = false;
                            }
                            HowManyUses--;
                        }
                    }
                }
            }
        }
        if (collision.tag == ("box"))
        {
            if (IsBoxInPosition)
            {
                if (!IsPlatInPosition)
                {
                    if (HowManyUses > 0)
                    {
                        if (!MoveToPlayer)
                        {
                            GameObject.FindWithTag("David").GetComponent<CompanionMovement>().GotoLoc = Location;
                            GameObject.FindWithTag("David").GetComponent<CompanionMovement>().IsFollowing = false;
                        }
                        else
                        {
                            GameObject.FindWithTag("David").GetComponent<CompanionMovement>().IsFollowing = true;
                        }
                        if (MakeInteract)
                        {
                            GameObject.FindWithTag("David").GetComponent<CompanionMovement>().CanInteract = true;
                        }
                        else
                        {
                            GameObject.FindWithTag("David").GetComponent<CompanionMovement>().CanInteract = false;
                        }
                        HowManyUses--;
                    }
                }
            }
        }
        if (collision.tag == "plat")
        {
            if (!IsPlayerCalling)
            {
                if (!IsBoxInPosition)
                {
                    if (IsPlatInPosition)
                    {
                        if (HowManyUses > 0)
                        {
                            if (!MoveToPlayer)
                            {
                                GameObject.FindWithTag("David").GetComponent<CompanionMovement>().GotoLoc = Location;
                                GameObject.FindWithTag("David").GetComponent<CompanionMovement>().IsFollowing = false;
                            }
                            else
                            {
                                GameObject.FindWithTag("David").GetComponent<CompanionMovement>().IsFollowing = true;
                            }
                            if (MakeInteract)
                            {
                                GameObject.FindWithTag("David").GetComponent<CompanionMovement>().CanInteract = true;
                            }
                            else
                            {
                                GameObject.FindWithTag("David").GetComponent<CompanionMovement>().CanInteract = false;
                            }
                            HowManyUses--;
                        }
                    }
                }
            }
        }
    }
}
