using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrsoSide : MonoBehaviour
{
    public bool IsRight = false;
    private void FixedUpdate()
    {
        if (GameObject.FindWithTag("David") != null) {
            if (GameObject.FindWithTag("David").transform.eulerAngles.y == 0)
            {
                if (IsRight)
                {
                    GameObject.Find("DavidRigged/Joojdir/Sprites").SetActive(false);
                }
                else
                {
                    GameObject.Find("DavidRigged/Jooj/Sprites").SetActive(true);
                }
            }
            else
            {
                if (IsRight)
                {
                    GameObject.Find("DavidRigged/Joojdir/Sprites").SetActive(true);
                }
                else
                {
                    GameObject.Find("DavidRigged/Jooj/Sprites").SetActive(false);
                }
            }
        }
    }
}
