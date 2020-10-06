using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private GameObject m_bullet;
    public float m_speed;

    private float m_fireRate;
    private float m_currentRate;

    void Start()
    {
        m_bullet = Resources.Load(Path.Combine("GameObjects", "bullet")) as GameObject;
        m_fireRate = 0.5f;
        m_currentRate = m_fireRate;
    }

    void Update()
    {
        if (m_currentRate >= m_fireRate)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                float l_xDirection = Input.GetKey(KeyCode.LeftArrow) ? -1 : Input.GetKey(KeyCode.RightArrow) ? 1 : 0 ;
                float l_yDirection = Input.GetKey(KeyCode.DownArrow) ? -1 : Input.GetKey(KeyCode.UpArrow) ? 1 : 0 ;

                GameObject l_bullet = Instantiate(m_bullet);

                l_bullet.transform.position = transform.position + new Vector3(0.6f * l_xDirection, 0);
                l_bullet.transform.Rotate(new Vector3(0, 0, BulletDir(l_xDirection, l_yDirection)), Space.World);
                l_bullet.GetComponent<Rigidbody2D>().AddForce(Vector2.right * l_xDirection * m_speed + Vector2.up * l_yDirection * m_speed, ForceMode2D.Force);
            }

            m_currentRate = 0f;
        }
        else
        {
            m_currentRate += Time.deltaTime;
        }
    }

    float BulletDir(float p_xAxis, float p_yAxis)
    {
        if (p_xAxis > 0)
            return p_yAxis > 0f ? -45f : p_yAxis < 0f ? -135f : -90f;

        if (p_xAxis < 0)
            return p_yAxis > 0f ? 45f: p_yAxis < 0f ? 135 : 90;
        
        return p_yAxis > 0f ? 0 : p_yAxis < 0f ? 180 : 0;
    }
}
