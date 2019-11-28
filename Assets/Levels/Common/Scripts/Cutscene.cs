using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    public int Level;
    public int Local;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!CutsceneManager.control.Cutscenesss[Local])
        {
            if (collision.tag == "Player")
            {
                CutsceneManager.control.Cutscenesss[Local] = true;
                SceneManager.LoadSceneAsync(Level, LoadSceneMode.Additive);
            }
        }
    }
}
