using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Shoot_Fireballs : MonoBehaviour
{
    public float FireRate;
    private float m_currentfRate;

    private GameObject m_fireBall;
    

    [Tooltip("-1 : left & 1 : right\n-2 : down & 2 : up")]
    public int Direction;

    public int Speed;

    void Awake()
    {
        m_currentfRate = FireRate;
        
        m_fireBall = Resources.Load(Path.Combine("GameObjects", "fireBall")) as GameObject;
    }

    void Update()
    {
        if (m_currentfRate >= FireRate)
        {
            Shoot();
            m_currentfRate = 0;
        }
        else
        {
            m_currentfRate += Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject l_fireBalInstance = Instantiate(m_fireBall, transform);

        l_fireBalInstance.GetComponent<fireballBehaviour>().Direction = Direction;
        l_fireBalInstance.GetComponent<fireballBehaviour>().Speed = Speed;
        
        switch (Direction)
        {
            case -1:
                l_fireBalInstance.transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            case -2:
                l_fireBalInstance.transform.rotation = Quaternion.Euler(0, 0, -90);
                break;
            case 1:
                l_fireBalInstance.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            default:
                l_fireBalInstance.transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
        }
    }
}
