using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box3 : MonoBehaviour
{
    private GameObject[] m_plats;
    private GameObject m_mainPlat;
    
    void Start()
    {
        m_mainPlat = GameObject.Find("oo");
        m_plats = new[]
        {
            GameObject.Find("Plat1"),
            GameObject.Find("Plat2")
        };
    }
    
    void OnTriggerStay2D(Collider2D p_col)
    {
        bool l_havePressed = false;
        
        if (p_col.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E) && !l_havePressed)
            {
                GetComponent<AudioSource>().Play();

                m_mainPlat.SetActive(false);
                
                foreach (GameObject l_gameObject in m_plats)
                {
                    l_gameObject.SetActive(true);
                }
                
                l_havePressed = true;
            }
        }
    }
}
