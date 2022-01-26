using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float force = 10;    
    [SerializeField] private float maxVelocity = 10;
    [SerializeField] private float upTorqueForce =3;
    [SerializeField] private float downTorqueForce =3;
    [SerializeField] private float rotationLimit =45;
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
        if(!IsJumping)
        {           
            ApplyRotation(Vector3.right, downTorqueForce);
            return;
        }
        ApplyRotation(Vector3.left, upTorqueForce);
        ApplyForce();
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
    private void ApplyForce()
    {
        rb.AddForce(Vector3.up * force,ForceMode.Impulse);        
        rb.velocity = new Vector3(0, Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity), 0);
        IsJumping=false;
    }

    private void ApplyRotation(Vector3 vector, float torqueForce)
    {     
        transform.forward = new Vector3(-1,0,0);   
        //transform.Rotate(vector* Time.deltaTime * torqueForce, Space.World);
        //float clampedX = Mathf.Clamp(transform.localEulerAngles.x,-rotationLimit,rotationLimit);

        //transform.rotation = Quaternion.LookRotation(Vector3.forward * clampedX,Vector3.zero);      
    }

}
