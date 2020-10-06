using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow6Sharps : MonoBehaviour
{
    public GameObject Target;
    
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(Target.transform.position.x, 0, 92.2f), 0, -10);
    }
}
