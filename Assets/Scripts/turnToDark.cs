using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class turnToDark : MonoBehaviour
{
    public bool IsDed = false;
    public GameObject DedText;
    
    void Update()
    {
        if (IsDed)
        {
            DedText.SetActive(true);
            RemoveAllUI();
            Color l_oo = GetComponent<RawImage>().color;
            l_oo = new Color(l_oo.r, l_oo.g, l_oo.b, l_oo.a+Time.deltaTime/2);
            GetComponent<RawImage>().color = l_oo;
        }
    }

    void RemoveAllUI()
    {
        Transform l_oo = GameObject.Find("Canvas").transform;
        if (l_oo != null)
        {
            for (int l_i = 0; l_i < l_oo.childCount; l_i++)
            {
                if (l_i != transform.GetSiblingIndex() && l_i != DedText.transform.GetSiblingIndex())
                    l_oo.GetChild(l_i).gameObject.SetActive(false);
            }
        }
    }
}
