using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    RaycastHit2D Hit;
    PlayerMovement playerMoviment;
    Turret Turret;
    public GameObject Shoot;
    bool TimeShoot;

    // Start is called before the first frame update
    void Start()
    {
        playerMoviment = FindObjectOfType<PlayerMovement>();
        Turret = GetComponentInParent<Turret>();
        StartCoroutine(ShootTime());
    }
    private void FixedUpdate()
    {
        Hit = Physics2D.Raycast(transform.position, (transform.right) * -1, 90);
        if (Hit.collider != null)
        {
            transform.localScale = new Vector3(Hit.point.x * 1, 0.01f, 0);
        }
        if (Hit.collider.tag == "Player")
        {
            GetComponentInParent<Turret>().RotationOff = false;
            if (TimeShoot == true)
            {
                Instantiate(Shoot, transform.position, transform.rotation);
            }
            //Shoot.transform.position = Vector3.MoveTowards(transform.position, Hit.point, 0.1f);
        }
        else
        {
            GetComponentInParent<Turret>().RotationOff = true;
        }
    }
    private IEnumerator ShootTime()
    {
        if (TimeShoot == false)
        {
            TimeShoot = true;
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(Reset());
    }
    private IEnumerator Reset()
    {
        if (TimeShoot == true)
        {
            TimeShoot = false;
        }
        StartCoroutine(ShootTime());
        yield return new WaitForSeconds(0.05f);
    }
}
