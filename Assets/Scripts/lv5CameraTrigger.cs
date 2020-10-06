using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv5CameraTrigger : MonoBehaviour
{
    private GameObject m_endCam;
    
    void Awake()
    {
        m_endCam = GameObject.Find("Cam_end");
    }
    
    void OnTriggerEnter2D(Collider2D p_col)
    {
        if (p_col.CompareTag("Player"))
        {
            GameObject.Find("Cam_follow").SetActive(false);
            m_endCam.SetActive(true);
        }
    }
}
