using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lvl3Trigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D p_col)
    {
        SceneManager.LoadScene(4);
    }
}
