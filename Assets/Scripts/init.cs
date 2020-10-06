using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class init : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("Rewinds", 0);
    }
}
