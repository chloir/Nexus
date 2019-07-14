using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private float velocityMulti = 1;
    [SerializeField] private float boostVelocity = 20;
    [SerializeField] private GameObject aimTarget;
    
    [SerializeField] private float sensitivity = 0.1f;
    [SerializeField] private float clampAngle = 60;
    
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovementSystem();
        AimingSystem();
        transform.LookAt(aimTarget.transform);
    }

    void AimingSystem()
    {
        //マウス移動量
        var mouseX = Input.GetAxis("Mouse X") * sensitivity;
        //mouseX *= reverseX ? -1 : 1; //X回転方向逆転
        var mouseY = Input.GetAxis("Mouse Y") * sensitivity * -1;
        //mouseY *= reverseY ? -1 : 1; //Y回転方向逆転
        //メイン照準回転
        var nowRot = this.transform.localEulerAngles;
        var newX = this.transform.localEulerAngles.x + mouseY;
        newX -= newX > 180 ? 360 : 0;
        newX = Mathf.Abs(newX) > clampAngle ? clampAngle * Mathf.Sign(newX) : newX;
        this.transform.localEulerAngles = new Vector3(newX, nowRot.y + mouseX, 0);
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
