using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float force = 10;    
    [SerializeField] private float maxVelocity = 10;
    [SerializeField] private Vector3 gravity = Physics.gravity;
    private Rigidbody rb;
    private bool IsJumping=false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();        
    }

    void Update()
    {        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            IsJumping = true;
        }
        if(gravity != Physics.gravity)
        {
            Physics.gravity=gravity;
        }
    }
    private void FixedUpdate() {
        if(!IsJumping){return;}

        rb.AddForce(Vector3.up * force,ForceMode.Impulse);
        rb.velocity = new Vector3(0, Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity), 0);
        IsJumping=false;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            print("Hit!!!");
        }
    }
}
