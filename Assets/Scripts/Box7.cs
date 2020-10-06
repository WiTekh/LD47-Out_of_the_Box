using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box7 : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D p_col)
    {
        if (p_col.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                GetComponent<AudioSource>().Play();

                SceneManager.LoadScene(1);
                int l_r = PlayerPrefs.GetInt("Rewinds");
                
                if (l_r < 4)
                    PlayerPrefs.SetInt("Rewinds", l_r+1);
            }
        }
    }
}
