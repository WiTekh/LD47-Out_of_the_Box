using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public float m_maxHealth;
    public float m_currentHealth;

    private Slider m_slider;

    void Start()
    {
        m_slider = GameObject.Find("EnemyHealthBar").GetComponent<Slider>();

        m_maxHealth = 100f;
        m_currentHealth = m_maxHealth;
        
        m_slider.maxValue = m_maxHealth;
    }

    void Update()
    {
        m_slider.value = m_currentHealth;
        
        if (m_currentHealth <= 0)
        {
            StartCoroutine(DelayedNextLevel());
        }
    }

    IEnumerator DelayedNextLevel()
    {
        Destroy(gameObject.GetComponent<SpriteRenderer>());
        for (int l_i = 0; l_i < transform.childCount; l_i++)
        {
            transform.GetChild(l_i).gameObject.SetActive(false);
        }
        m_slider.gameObject.SetActive(false);
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene(5);
    }
}
