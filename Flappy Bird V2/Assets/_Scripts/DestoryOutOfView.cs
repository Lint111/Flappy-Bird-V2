using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryOutOfView : MonoBehaviour
{    
    const int ZLimit =-20;
    void Update()
    {
        if(transform.position.z<ZLimit)
        Destroy(this.gameObject);
    }
}
