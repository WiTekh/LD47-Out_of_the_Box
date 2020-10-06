using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D p_col)
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 2:
                float l_animTime = 0.1f;
                transform.DOMove(transform.position + Vector3.down * 0.1f, l_animTime);
                StartCoroutine(DelayedLoad(l_animTime));
                break;
        }
    }

    IEnumerator DelayedLoad(float p_time)
    {
        yield return new WaitForSecondsRealtime(p_time);
        SceneManager.LoadScene(3);
    }
}
