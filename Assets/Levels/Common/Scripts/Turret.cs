using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    float Pos_x, rotation;
    bool RotationOn;
    public bool RotationOff;
    public GameObject Laser;
    public GameObject explosion;

    void Start()
    {
        Laser.transform.position = transform.position;
        RotationOn = true;
        RotationOff = true;
    }


    void Update()
    {
        if (Mathf.Abs((PlayerMovement.control.transform.position.magnitude - transform.position.magnitude)) <= 15)
        {
            Laser.SetActive(true);
        }
        else
        {
            Laser.SetActive(false);
        }
        rotation = Laser.transform.rotation.z * 1000;
        Rotation();
    }
    public void Rotation()
    {
        if (RotationOff == true)
        {
            if (rotation < 600 && RotationOn == true)
            {
                Laser.transform.Rotate(0, 0, Pos_x);
            }
            else
            {
                RotationOn = false;
            }
            if (RotationOn == false && rotation > 300)
            {
                Laser.transform.Rotate(0, 0, -Pos_x);
            }
            else
            {
                RotationOn = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "tiro")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

}
