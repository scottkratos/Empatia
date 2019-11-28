using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTrigger : MonoBehaviour
{
    public string loadName;
    public string unloadName;

    private void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (loadName != "")
            {
                SceneMan.LoadSceneAsync(loadName);
            }
            if (unloadName != "")
            {
                SceneMan.UnloadSceneAsync(unloadName);
            }
            Destroy(gameObject);
        }
    }
}
