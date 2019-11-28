using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinzas : MonoBehaviour
{
    public AudioClip[] Clips;
    private void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, 180);
        if (SceneManager.GetActiveScene().name == "Floresta") {
            GetComponent<AudioSource>().clip = Clips[0];
            GetComponent<AudioSource>().Play();
        }
        else
        {
            GetComponent<AudioSource>().clip = Clips[1];
            GetComponent<AudioSource>().Play();
        }
        Invoke("Kill", 1);
    }
    private void Kill()
    {
        Destroy(gameObject);
    }
}
