﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 bulletOffset;
    
    [SerializeField] private float velocityMulti = 1;
    [SerializeField] private float boostVelocity = 20;
    [SerializeField] private float jumpVelocity = 60;
    [SerializeField] private float quickJumpVelocity = 30;
    [SerializeField] private GameObject aimTarget;

    [SerializeField] private GameObject bullet = null;
    
    [SerializeField] private float sensitivity = 0.1f;
    [SerializeField] private float clampAngle = 60;
    [SerializeField] private float bulletVelocity = 300;

    [SerializeField] private GameObject camerapos;
    private Vector3 defaultCameraPos;
    
    void Start()
    {
        defaultCameraPos = camerapos.transform.localPosition;
        var mouseInput = new ReactiveProperty<float>();
        mouseInput.Value = Input.GetAxis("Mouse X");
        
        var targetTransform = new ReactiveProperty<Vector3>();
        targetTransform.Value = aimTarget.transform.position;

        _rigidbody = GetComponent<Rigidbody>();
        
        // カーソル固定
        Cursor.lockState = CursorLockMode.Locked;
        
        // 弾の発射
        this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(_ => ThrowBullet());

        // 視点移動
        this.UpdateAsObservable()
            .Where(_ => Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            .Subscribe(_ => AimingSystem());
        
        // 移動
        this.UpdateAsObservable()
            .Where(_ => Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            .Subscribe(_ => MovementSystem());

        targetTransform.AsObservable()
            .Subscribe(_ => transform.LookAt(aimTarget.transform));

//        mouseInput.AsObservable()
//            .Subscribe(_ => AimingSystem());
    }

    void ThrowBullet()
    {
        bulletOffset = transform.forward * 4;
        Instantiate(bullet, transform.position + bulletOffset, Quaternion.identity).GetComponent<Rigidbody>().AddForce(this.transform.forward * bulletVelocity, ForceMode.Impulse);
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
        var boostDirection = new Vector3();
        var left = transform.right * -1;
        var back = transform.forward * -1;
        
        if (Input.GetAxis("Horizontal") < 0)
        {
            _rigidbody.AddForce(left * velocityMulti, ForceMode.VelocityChange);
            boostDirection = left;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            _rigidbody.AddForce(transform.right * velocityMulti, ForceMode.VelocityChange);
            boostDirection = transform.right;
        }

        if (Input.GetAxis("Vertical") < 0)
        {
            _rigidbody.AddForce(back * velocityMulti, ForceMode.VelocityChange);
            boostDirection = back;
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            _rigidbody.AddForce(transform.forward * velocityMulti, ForceMode.VelocityChange);
            boostDirection = transform.forward;
        }
        
        if (Input.GetKeyDown(KeyCode.Space)) { _rigidbody.AddForce(boostDirection * boostVelocity, ForceMode.Impulse); }
        
        if (Input.GetKeyDown(KeyCode.LeftShift)) { _rigidbody.AddForce(Vector3.up * quickJumpVelocity, ForceMode.Impulse); }
        if (Input.GetKey(KeyCode.LeftShift)) { _rigidbody.AddForce(Vector3.up * jumpVelocity, ForceMode.Acceleration); }
    }
}
