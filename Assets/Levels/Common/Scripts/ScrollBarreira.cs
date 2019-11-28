using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBarreira : MonoBehaviour
{
    public float vel;
    private Renderer back;
    private Vector2 offset;

    private void Start()
    {
        back = this.gameObject.GetComponent<Renderer>();
        offset = new Vector2(0, vel);
    }
    void FixedUpdate()
    {
        back.material.mainTextureOffset += offset;
    }
}
