using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenChange : MonoBehaviour
{
    public static ScreenChange control;
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

    public GameObject renderScreen;

    public void ScreenFadeIn()
    {
        renderScreen.GetComponent<Animation>().Play("FadeInAnim");
    }
    public void ScreenFadeOut()
    {
        renderScreen.GetComponent<Animation>().Play("FadeOutAnim");
    }
}
