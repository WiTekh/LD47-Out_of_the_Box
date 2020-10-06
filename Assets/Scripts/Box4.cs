using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Box4 : MonoBehaviour
{
    public GameObject Shooters;
    public float Timer;
    public TMP_Text TimerText;
    private bool m_havePressed = false;

    void Start()
    {
        Shooters.SetActive(false);
    }

    void Update()
    {
        if (m_havePressed)
        {
            if (Timer <= 0)
            {
                SceneManager.LoadScene(5);
            }
            else
            {
                Timer = Mathf.Clamp(Timer - Time.deltaTime, 0, Timer);
                TimerText.text = TimeFormat(Timer.ToString());
            }
        }
    }
    
    void OnTriggerStay2D(Collider2D p_col)
    {
        if (p_col.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                GetComponent<AudioSource>().Play();

                Destroy(transform.parent.GetComponent<SpriteRenderer>());
                Destroy(transform.parent.GetComponent<BoxCollider2D>());
                Destroy(GetComponent<BoxCollider2D>());

                Shooters.SetActive(true);
                m_havePressed = true;
            }
        }
    }

    string TimeFormat(string p_inTime)
    {
        string l_str = p_inTime.Substring(0, 5);
        string[] l_spl = l_str.Split('.');

        l_str = (l_spl[0].Length < 2 ? "0" + l_spl[0] : l_spl[0]) + ":" + l_spl[1].Substring(0,2);
        return l_str;
    }
}
