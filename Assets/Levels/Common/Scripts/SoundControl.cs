using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundControl : MonoBehaviour
{
    public SoundControl control;
    public AudioClip[] som;
    public bool IsFloresta = true;
    public int type;
    public int delay;

    private void Awake()
    {
        if (control != null)
        {
            Destroy(control.gameObject);
        }
        control = this;
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "Floresta")
        {
            IsFloresta = true;
        }
        else
        {
            IsFloresta = false;
        }
        ChangeMusic();
    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Floresta")
        {
            IsFloresta = true;
        }
        else
        {
            IsFloresta = false;
        }
    }
    private void ChangeMusic()
    {
        if (IsFloresta)
        {
            switch (type)
            {
                case 0:
                    GetComponent<AudioSource>().clip = som[0];
                    GetComponent<AudioSource>().Stop();
                    GetComponent<AudioSource>().Play();
                    type = 1;
                    delay = 15;
                    Invoke("ChangeMusic", delay);
                    break;
                case 1:
                    GetComponent<AudioSource>().clip = som[1];
                    GetComponent<AudioSource>().Stop();
                    GetComponent<AudioSource>().Play();
                    type = 2;
                    delay = 15;
                    Invoke("ChangeMusic", delay);
                    break;
                case 2:
                    GetComponent<AudioSource>().clip = som[2];
                    GetComponent<AudioSource>().Stop();
                    GetComponent<AudioSource>().Play();
                    type = 2;
                    delay = 47;
                    Invoke("ChangeMusic", delay);
                    break;
            }
        }
        else
        {
            switch (type)
            {
                case 0:
                    GetComponent<AudioSource>().clip = som[3];
                    GetComponent<AudioSource>().Stop();
                    GetComponent<AudioSource>().Play();
                    type = 1;
                    delay = 21;
                    Invoke("ChangeMusic", delay);
                    break;
                case 1:
                    GetComponent<AudioSource>().clip = som[4];
                    GetComponent<AudioSource>().Stop();
                    GetComponent<AudioSource>().Play();
                    type = 2;
                    delay = 16;
                    Invoke("ChangeMusic", delay);
                    break;
                case 2:
                    GetComponent<AudioSource>().clip = som[5];
                    GetComponent<AudioSource>().Stop();
                    GetComponent<AudioSource>().Play();
                    type = 2;
                    delay = 43;
                    Invoke("ChangeMusic", delay);
                    break;
                case 3:
                    GetComponent<AudioSource>().clip = som[6];
                    GetComponent<AudioSource>().Stop();
                    GetComponent<AudioSource>().Play();
                    type = 3;
                    delay = 44;
                    Invoke("ChangeMusic", delay);
                    break;
            }
        }
    }
}
