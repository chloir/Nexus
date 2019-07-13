using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float velocityMulti = 1;
    [SerializeField] private float boostVelocity = 20;
    [SerializeField] private GameObject aimTarget;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovementSystem();
        transform.LookAt(aimTarget.transform);
    }

    void MovementSystem()
    {
        var direction = new Vector3();
        
        if (Input.GetAxis("Horizontal") < 0)
        {
            _rigidbody.AddForce(Vector3.left * velocityMulti, ForceMode.VelocityChange);
            direction = Vector3.left;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            _rigidbody.AddForce(Vector3.right * velocityMulti, ForceMode.VelocityChange);
            direction = Vector3.right;
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            _rigidbody.AddForce(Vector3.back * velocityMulti, ForceMode.VelocityChange);
            direction = Vector3.back;
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            _rigidbody.AddForce(Vector3.forward * velocityMulti, ForceMode.VelocityChange);
            direction = Vector3.forward;
        }
        
        if (Input.GetKeyDown(KeyCode.Space)) { _rigidbody.AddForce(direction * boostVelocity, ForceMode.Impulse); }
    }
}
