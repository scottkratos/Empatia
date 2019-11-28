using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float vel;
    private float inipos;
    private string nomeBack;
    // Start is called before the first frame update
    void Start()
    {
        nomeBack = this.gameObject.tag;
        switch (nomeBack)
        {
            case "bg1":
                vel = 2;
                break;

            case "bg2":
                vel = 0.5f;
                break;

            case "bg3":
                vel = 0.3f;
                break;

            case "bg4":
                vel = 0.1f;
                break;
        }
        inipos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3((TargetPerst.control.transform.position.x - inipos) * vel * -1, transform.position.y, transform.position.z);
    }
}
