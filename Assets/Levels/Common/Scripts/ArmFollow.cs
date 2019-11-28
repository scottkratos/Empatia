using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmFollow : MonoBehaviour
{
    private void Update()
    {
        GetComponent<Rigidbody2D>().MovePosition(new Vector2(GameObject.Find("Hips/Spine1/Spine2/Spine3/Rombro/Rcotovelo/Jooj").transform.position.x, GameObject.Find("Hips/Spine1/Spine2/Spine3/Rombro/Rcotovelo/Jooj").transform.position.y));
        GetComponent<Rigidbody2D>().MoveRotation(GameObject.Find("Hips/Spine1/Spine2/Spine3/Rombro/Rcotovelo/Jooj").transform.eulerAngles.z);
    }
}
