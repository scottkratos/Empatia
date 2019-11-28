using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LetteringFinal : MonoBehaviour
{
    public float tempoEntreTextos;

    public string créditos;

    public bool podeSair;

    public TextMeshProUGUI mensagem1, mensagem2, mensagem3, mensagem4, mensagem5, mensagem6;//número de mensagens no inspector

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MostrarFinalCo());
    }

    // Update is called once per frame
    void Update()
    {
        if (podeSair && Input.anyKeyDown)//qualquer tecla para sair desta scene
        {
            SceneManager.LoadScene(créditos);//ir para os créditos
        }
    }

    public IEnumerator MostrarFinalCo()
    {
        yield return new WaitForSeconds(tempoEntreTextos);
        mensagem1.gameObject.SetActive(true);
        yield return new WaitForSeconds(tempoEntreTextos);
        Destroy(mensagem1.gameObject);
        yield return new WaitForSeconds(tempoEntreTextos);
        mensagem2.gameObject.SetActive(true);
        yield return new WaitForSeconds(tempoEntreTextos);
        Destroy(mensagem2.gameObject);
        yield return new WaitForSeconds(tempoEntreTextos);
        mensagem3.gameObject.SetActive(true);
        yield return new WaitForSeconds(tempoEntreTextos);
        Destroy(mensagem3.gameObject);
        yield return new WaitForSeconds(tempoEntreTextos);
        mensagem4.gameObject.SetActive(true);
        yield return new WaitForSeconds(tempoEntreTextos);
        Destroy(mensagem4.gameObject);
        yield return new WaitForSeconds(tempoEntreTextos);
        mensagem5.gameObject.SetActive(true);
        yield return new WaitForSeconds(tempoEntreTextos);
        Destroy(mensagem5.gameObject);
        yield return new WaitForSeconds(tempoEntreTextos);
        mensagem6.gameObject.SetActive(true);
        yield return new WaitForSeconds(tempoEntreTextos);
        Destroy(mensagem6.gameObject);
        podeSair = true;
    }
}
