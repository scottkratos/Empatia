using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public int[] ID;
    public GameObject[] View;
    private Cinemachine.CinemachineTargetGroup targetGroup;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            targetGroup = GameObject.Find("TargetGroup1").GetComponent<Cinemachine.CinemachineTargetGroup>();
            Cinemachine.CinemachineTargetGroup.Target target;
            for (int i = 0; i < ID.Length; i++)
            {
                if (ID[i] == 0)
                {
                    View[i] = PlayerMovement.control.gameObject;
                }
                else if (ID[i] == 1 && PlayerMovement.control.HaveCompanion)
                {
                    View[i] = CompanionMovement.control.gameObject;
                }
                if (View[i] != null)
                {
                    target.target = View[i].transform;
                }
                else
                {
                    target.target = null;
                }
                target.weight = 1;
                target.radius = 1;
                for (int r = 0; r < targetGroup.m_Targets.Length; r++)
                {
                    if (r == ID[i])
                    {
                        targetGroup.m_Targets.SetValue(target, r);
                    }
                }
            }
        }
    }
}
