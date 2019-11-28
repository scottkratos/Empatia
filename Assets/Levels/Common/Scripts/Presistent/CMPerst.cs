using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMPerst : MonoBehaviour
{
    public static CMPerst control;
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
