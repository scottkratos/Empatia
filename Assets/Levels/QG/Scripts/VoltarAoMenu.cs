using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VoltarAoMenu : MonoBehaviour
{
    public float tempoEntreTextos;

    public string menu;

    public bool podeSair;

    public Text grupo, programador, escritor, artista, músico, level, animador, documentador, livro, mensagem;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MostrarTextosCo());
    }

    // Update is called once per frame
    void Update()
    {
        if (podeSair && Input.anyKeyDown)//qualquer tecla para sair desta scene
        {
            SceneManager.LoadScene(0);//ir para o menu principal
        }
    }

    public IEnumerator MostrarTextosCo()//Lógica: Esperar tempo determinado > aparece texto > destroi texto > continua em loop até o fim
    {
        yield return new WaitForSeconds(tempoEntreTextos);
        grupo.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        Destroy(grupo.gameObject);
        yield return new WaitForSeconds(tempoEntreTextos);
        programador.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        Destroy(programador.gameObject);
        yield return new WaitForSeconds(tempoEntreTextos);
        escritor.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        Destroy(escritor.gameObject);
        yield return new WaitForSeconds(tempoEntreTextos);
        artista.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        Destroy(artista.gameObject);
        yield return new WaitForSeconds(tempoEntreTextos);
        músico.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        Destroy(músico.gameObject);
        yield return new WaitForSeconds(tempoEntreTextos);
        level.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        Destroy(level.gameObject);
        yield return new WaitForSeconds(tempoEntreTextos);
        animador.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        Destroy(animador.gameObject);
        yield return new WaitForSeconds(tempoEntreTextos);
        documentador.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        Destroy(documentador.gameObject);
        yield return new WaitForSeconds(tempoEntreTextos);
        livro.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        Destroy(livro.gameObject);
        yield return new WaitForSeconds(1f);
        mensagem.gameObject.SetActive(true);
        podeSair = true;
    }
}
