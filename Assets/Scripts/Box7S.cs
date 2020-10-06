using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box7S : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D p_col)
    {
        if (p_col.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                GetComponent<AudioSource>().Play();
                SceneManager.LoadScene(10);
            }
        }
    }}
