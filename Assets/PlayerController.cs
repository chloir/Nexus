using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float velocityMulti = 1;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovementSystem();
    }

    void MovementSystem()
    {
        if (Input.GetAxis("Horizontal") < 0) { _rigidbody.AddForce(Vector3.left * velocityMulti, ForceMode.VelocityChange); }
        if (Input.GetAxis("Horizontal") > 0) { _rigidbody.AddForce(Vector3.right * velocityMulti, ForceMode.VelocityChange); }
        if (Input.GetAxis("Vertical") < 0) { _rigidbody.AddForce(Vector3.back * velocityMulti, ForceMode.VelocityChange); }
        if (Input.GetAxis("Vertical") > 0) { _rigidbody.AddForce(Vector3.forward * velocityMulti, ForceMode.VelocityChange); }
    }
}
