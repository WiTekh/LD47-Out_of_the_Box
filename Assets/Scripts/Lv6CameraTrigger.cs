using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv6CameraTrigger : MonoBehaviour
{
    private GameObject m_endCam;

    void Awake()
    {
        m_endCam = GameObject.Find("Cam_end");
        m_endCam.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D p_col)
    {
        if (p_col.CompareTag("Player"))
        {
            m_endCam.SetActive(true);
        }
    }
}
