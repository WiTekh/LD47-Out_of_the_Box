using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv7CameraTrigger : MonoBehaviour
{
    private GameObject m_firstCam;
    private GameObject m_bigCam;

    private GameObject m_door;

    void Awake()
    {
        m_firstCam = GameObject.Find("Cam_first");
        m_bigCam = GameObject.Find("Cam_fixed");
        m_door = GameObject.Find("Door");
        
        m_firstCam.SetActive(true);
        m_bigCam.SetActive(false);
        m_door.SetActive(false);
    }
    
    void OnTriggerEnter2D(Collider2D p_col)
    {
        if (p_col.CompareTag("Player"))
        {
            m_firstCam.SetActive(false);
            m_bigCam.SetActive(true);
            m_door.SetActive(true);
        }
    }
}
