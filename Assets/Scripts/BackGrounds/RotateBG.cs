using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBG : MonoBehaviour
{
   
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 10f) * Time.deltaTime);
    }
}
