using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Box5 : MonoBehaviour
{
    public GameObject Platforms;
    public GameObject Superbox;

    private GameObject m_fixedCam;
    private GameObject m_followCam;
    private GameObject m_removWall;

    void Start()
    {
        Platforms = Platforms == null ? GameObject.Find("Platforms") : Platforms;
        Superbox = Superbox == null ? GameObject.Find("Secretbox") : Superbox;

        m_fixedCam = GameObject.Find("Cam_first");
        m_followCam = GameObject.Find("Cam_follow");
        m_removWall = GameObject.Find("RemovableWall");
        
        m_fixedCam.SetActive(true);
        m_followCam.SetActive(false);
        GameObject.Find("Cam_end").SetActive(false);
        
        Platforms.SetActive(false);
        Superbox.SetActive(false);
    }
    
    void OnTriggerStay2D(Collider2D p_col)
    {
        if (p_col.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                GetComponent<AudioSource>().Play();

                Platforms.SetActive(true);
                Superbox.SetActive(true);

                m_fixedCam.SetActive(false);
                m_followCam.SetActive(true);
                
                m_removWall.SetActive(false);

                p_col.GetComponent<PlayerManager>().Speed = 6f;
                p_col.GetComponent<PlayerManager>().JumpForce = 7f;
            }
        }
    }
}
