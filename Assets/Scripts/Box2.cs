using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box2 : MonoBehaviour
{
    private GameObject m_platform;
    
    void Start()
    {
        m_platform = GameObject.Find("Hidden");
        m_platform.SetActive(false);
    }

    void OnTriggerStay2D(Collider2D p_col)
    {
        if (p_col.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                GetComponent<AudioSource>().Play();
                m_platform.SetActive(true);
            }
        }
    }
}
