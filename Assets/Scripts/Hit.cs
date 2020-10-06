using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    private StatsManager m_parent;

    public bool m_dmgReduced;

    void Start()
    {
        m_parent = transform.parent.GetComponent<StatsManager>();
    }

    void OnCollisionEnter2D(Collision2D p_col)
    {
        Debug.Log(p_col.collider.tag);
        if (p_col.collider.CompareTag("Bullet"))
        {
            m_parent.m_currentHealth -= m_dmgReduced ? 2 : 34;
        }
    }
}
