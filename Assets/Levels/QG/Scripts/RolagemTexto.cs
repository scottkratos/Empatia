﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RolagemTexto : MonoBehaviour
{

    public float velocidadeTexto;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, velocidadeTexto, 0);//movendo o texto no eixo y
    }
}
