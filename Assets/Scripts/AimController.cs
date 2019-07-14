using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimController : MonoBehaviour
{
    [SerializeField] private Image reticle;
    [SerializeField] private Camera mainCamera;
    void Start()
    {
        //offset = transform.position - player.transform.position;
    }

    void Update()
    {
        reticle.transform.position = RectTransformUtility.WorldToScreenPoint(mainCamera, transform.position);

//        var inputAxis = new Vector3(Input.GetAxis("Mouse Y") * sensitivity, Input.GetAxis("Mouse X") * sensitivity, 0);
//
//        var playerPos = player.transform.position;
//
//        transform.position = playerPos + offset;
//        
//        transform.RotateAround(playerPos, inputAxis, rotationangle);
    }
}
