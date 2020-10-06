using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawManager : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D p_col)
    {
        if (p_col.collider.CompareTag("Player"))
        {
            p_col.gameObject.GetComponent<PlayerManager>().Death();
        }
    }
}
