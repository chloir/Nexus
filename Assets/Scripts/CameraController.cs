using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float duration = 0.5f;
    [SerializeField] private GameObject aimTarget;
    [SerializeField] private GameObject cameraPosTarget;
    private float time;
    private Vector3 targetPos;
    private Vector3 playerPos;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        aimTarget = GameObject.FindWithTag("AimTarget");
        cameraPosTarget = GameObject.FindWithTag("CameraTarget");
    }

    void Update()
    {
        targetPos = cameraPosTarget.transform.position;
        playerPos = player.transform.position;

        RaycastHit hit;
        var direction = targetPos - playerPos;
        var dist = Vector3.Distance(playerPos, targetPos);
        if (Physics.Raycast(playerPos, direction, out hit, dist))
        {
            targetPos = hit.point - direction.normalized * 0.1f;
        }
        
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * duration);
        transform.LookAt(aimTarget.transform);
    }
}
