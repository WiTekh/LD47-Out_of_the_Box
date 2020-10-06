using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballBehaviour : MonoBehaviour
{
    private ParticleSystem m_pS;
    public float Speed;
    public int Direction;

    void Awake()
    {
        m_pS = transform.GetChild(0).GetComponent<ParticleSystem>();
        m_pS.Pause();
    }

    void Update()
    {
        transform.position += (Direction == -2 ? Vector3.down * Speed : Direction == 2 ? Vector3.up * Speed : Vector3.right * Direction * Speed) * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D p_col)
    {
        Debug.Log(p_col.collider.tag);
        StartCoroutine(DelayedDes());
        m_pS.Play();
        GetComponent<AudioSource>().Play();

        if (p_col.collider.CompareTag("Player"))
        {
            p_col.gameObject.GetComponent<PlayerManager>().Death();
        }
    }

    IEnumerator DelayedDes()
    {
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<Collider>());
        yield return new WaitForSecondsRealtime(m_pS.main.duration);
        Destroy(gameObject);
    }
}
