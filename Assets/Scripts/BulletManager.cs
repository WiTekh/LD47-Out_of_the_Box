using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DelayedDestroy());
    }
    
    void OnCollisionEnter2D(Collision2D p_col)
    {
        if (!p_col.collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }   
    }

    IEnumerator DelayedDestroy()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Destroy(gameObject);
    }
}
