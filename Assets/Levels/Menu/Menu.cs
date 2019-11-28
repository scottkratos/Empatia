using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.IO;

public class Menu : MonoBehaviour
{
    public AudioMixer ConfigAudio;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void NewGame()
    {
        if (File.Exists(Application.persistentDataPath + "/playerinfo.scott"))
        {
            File.Delete(Application.persistentDataPath + "/playerinfo.scott");
        }
        Invoke("StartNewGame", 3);
    }
    public void StartNewGame()
    {
        SceneManager.LoadScene(3);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void MusicGame(float Volume)
    {
        ConfigAudio.SetFloat("Music_volume", Volume);

    }
    public void EffectsGame(float Volume)
    {
        ConfigAudio.SetFloat("Effects_volume", Volume);

    }
    public void AllSoundGame(float Volume)
    {
        ConfigAudio.SetFloat("Master_Volume", Volume);

    }

}
