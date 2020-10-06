using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box6 : MonoBehaviour
{
    public GameObject Platforms;
    public GameObject rWall;

    private GameObject m_fixedCam;
    private GameObject m_followCam;

    void Start()
    {
        Platforms = Platforms == null ? GameObject.Find("Platforms") : Platforms;
        
        m_fixedCam = GameObject.Find("Cam_first");
        m_followCam = GameObject.Find("Cam_follow");
        
        m_fixedCam.SetActive(true);
        m_followCam.SetActive(false);

        rWall.SetActive(true);
        Platforms.SetActive(false);
    }
    
    void OnTriggerStay2D(Collider2D p_col)
    {
        if (p_col.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                GetComponent<AudioSource>().Play();

                Platforms.SetActive(true);
                m_fixedCam.SetActive(false);
                m_followCam.SetActive(true);
                
                rWall.SetActive(false);
                
                p_col.GetComponent<PlayerManager>().Speed = 6f;
                p_col.GetComponent<PlayerManager>().JumpForce = 7f;
            }
        }
    }
}
