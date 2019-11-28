using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EscolherFinal : MonoBehaviour
{

    public string matarPolokov;
    public string acreditarPolokov;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MatarPolokov()//carregar final 1
    {
        SceneManager.LoadScene(matarPolokov);
    }

    public void AcreditarPolokov()//carregar final 2
    {
        SceneManager.LoadScene(acreditarPolokov);
    }
}
