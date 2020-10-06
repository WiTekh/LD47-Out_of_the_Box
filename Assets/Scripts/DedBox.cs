using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DedBox : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D p_col)
    {
        if (p_col.CompareTag("Player"))
        {
            p_col.GetComponent<PlayerManager>().Death();
        }
    }
}
