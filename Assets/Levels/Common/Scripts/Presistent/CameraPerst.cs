using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPerst : MonoBehaviour
{
    public static CameraPerst control;
    private void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this)
        {
            Destroy(gameObject);
        }
    }
}
