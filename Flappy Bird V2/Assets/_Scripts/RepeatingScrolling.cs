using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingScrolling : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    private Bounds bounds;
    private float zBound;
    private Vector3 originalTransom;


    private void Start() {
        bounds = GetComponent<BoxCollider>().bounds;
        zBound = bounds.extents.z;
        originalTransom = transform.position;
    }

    private void Update() {
        if(transform.position.z < originalTransom.z - zBound)
        {
            transform.position = originalTransom ;
        }
        transform.position += Vector3.back * scrollSpeed * Time.deltaTime;
    }
    
}
