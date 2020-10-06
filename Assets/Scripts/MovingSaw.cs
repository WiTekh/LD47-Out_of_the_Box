using System.Collections;
using System.Collections.Generic;
using System.IO;
using DG.Tweening;
using UnityEngine;

public class MovingSaw : MonoBehaviour
{
    private GameObject m_saw;
    
    public Vector3 StartVect;
    public Vector3 EndVect;

    public float StandbyTime;
    public float TravelTime;

    void Start()
    {
        DOTween.SetTweensCapacity(500, 100);
        m_saw = Resources.Load(Path.Combine("GameObjects", "Saw")) as GameObject;

        m_saw = Instantiate(m_saw);
        m_saw.transform.parent = transform;
        m_saw.transform.position = transform.position;
    }
    
    void Update()
    {
        if (m_saw.transform.position == StartVect+transform.position)
        {
            StartCoroutine(Standby(EndVect));
        }

        if (m_saw.transform.position == EndVect+transform.position)
        {
            StartCoroutine(Standby(StartVect));
        }
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position + StartVect, transform.position + EndVect);
    }

    IEnumerator Standby(Vector3 p_vect)
    {
        yield return new WaitForSecondsRealtime(StandbyTime);
        Travel(p_vect);
    }

    void Travel(Vector3 p_vect)
    {
        m_saw.transform.DOMove(p_vect+transform.position, TravelTime);
    }
}
