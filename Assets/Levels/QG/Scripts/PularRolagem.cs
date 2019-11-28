using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PularRolagem : MonoBehaviour
{
    public string fase;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pularRolagem()//botão de pular na cutscene de contextualização
    {
        SceneManager.LoadScene(fase);
    }
}
