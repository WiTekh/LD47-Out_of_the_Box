using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class lvl7SharpCameraClamp : MonoBehaviour
{
    public GameObject Target;
    
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(Target.transform.position.x, 0, 42.4f), Mathf.Clamp(Target.transform.position.y, 0 , 16.8f), -10);
    }
}
