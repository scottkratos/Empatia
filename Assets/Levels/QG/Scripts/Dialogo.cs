using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogo : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] frases;
    private int index;
    public float typingSpeed;

    public GameObject botãoContinue;
    public GameObject botãoPular;
    //int currentSceneIndex;

    public string fase;

    void Start()
    {
        StartCoroutine(Type());
        //currentSceneIndex = SceneManager.sceneCount;

    }

    void Update()
    {
        if (textDisplay.text == frases[index])
        {
            botãoPular.SetActive(true);
            botãoContinue.SetActive(true);
           
        }
    }
    //
    IEnumerator Type()//Regulando a velocidade das frases e de suas letras
    {
        foreach (char letter in frases[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void proximaFrase()//Configurando o botão continue
    {
        botãoContinue.SetActive(false);

        if (index < frases.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            botãoContinue.SetActive(false);
        }
        if(index == frases.Length - 1)
        {
            SceneManager.LoadScene(fase);
        }
    }
    

    public void BotãoPular()//Para carregar a Primeira Fase
    {
        botãoPular.SetActive(false);
        /*if (index < frases.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            botãoPular.SetActive(false);
        }*/
        SceneManager.LoadScene(fase);
    }
}
