using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private GameObject[] Points;
    private int localcheck = 0, locallocal = -1;
    public static Transform CheckPosition;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Check") != null)
        {
            Points = GameObject.FindGameObjectsWithTag("Check");
            for (int i = 0; Points.Length > i; i++)
            {
                if (Points[i].GetComponent<Checkpoint>().IsCurrent)
                {
                    localcheck = i;
                    if (localcheck != locallocal)
                    {
                        locallocal = localcheck;
                        CheckPosition = Points[i].transform;
                        SaveSystem.control.Save();
                    }
                }
            }
        }
    }
}
