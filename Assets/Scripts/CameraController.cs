using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private GameObject aimTarget;
    private Vector3 offset;

    void Start()
    {
        offset = this.transform.position - player.transform.position;
    }

    void Update()
    {
        Vector3 target = player.transform.position + offset;
        
        this.transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * duration);
        transform.LookAt(aimTarget.transform);
    }
}
