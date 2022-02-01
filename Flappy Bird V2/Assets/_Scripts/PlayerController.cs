using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float force = 10;    
    [SerializeField] private float maxVelocity = 10;
    [SerializeField] private float rotationLimit =45;
    [SerializeField] private float rotationScale=10;
    [SerializeField] private Vector3 gravity = Physics.gravity;
    private Rigidbody rb;
    private bool IsJumping=false;
    private Vector3 torque;
    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        UpdateGravity();       
    }

    void Update()
    {        
        GetInput();        
    }
    private void FixedUpdate() 
    {        
        HandlePhysics();        
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            //GameLost
            print("Hit!!!");
        }
    }

    private void GetInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            IsJumping = true;
        }
    }
    private void UpdateGravity()
    {
        if(gravity != Physics.gravity)
        {
            Physics.gravity=gravity;
        }
    }

    private void HandlePhysics()
    {
        if(IsJumping)
        {           
            ApplyForce();
            return;
        }        
        ApplyRotation();
    }
    private void ApplyForce()
    {
        rb.AddForce(Vector3.up * force,ForceMode.Impulse);        
        rb.velocity = new Vector3(0, Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity), 0);
        IsJumping=false;
    }

    private void ApplyRotation()
    {     
        float yDirection = Mathf.Clamp(-rb.velocity.y * rotationScale,-rotationLimit,rotationLimit);        
        transform.eulerAngles = new Vector3(yDirection,0,0);
    }    

}
