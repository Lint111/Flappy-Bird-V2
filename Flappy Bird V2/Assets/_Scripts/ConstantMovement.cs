using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMovement : MonoBehaviour
{    
    [SerializeField] private Vector3 movementDirection;
    [SerializeField] private float movementSpeed;
    void Update()
    {
        transform.position += movementDirection.normalized * movementSpeed * Time.deltaTime;
    }
}
