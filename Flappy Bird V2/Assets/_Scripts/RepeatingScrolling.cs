using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingScrolling : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    private Bounds bounds;
    private float zBound;


    private void Start() {
        bounds = GetComponent<BoxCollider>().bounds;
        zBound = bounds.extents.z;
    }

    private void Update() {
        if(transform.position.z < transform.position.z - zBound)
        {
            transform.position += Vector3.forward * zBound ;
        }
        transform.position += Vector3.back * scrollSpeed * Time.deltaTime;
    }
    
}
