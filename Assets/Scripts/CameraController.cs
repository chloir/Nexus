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
    private Vector3 offset;
    private float time;

    void Start()
    {
        offset = this.transform.position - player.transform.position;
    }

    void Update()
    {
        var target = cameraPosTarget.transform.position;
        var playerpos = player.transform.position;

        RaycastHit hit;
        var direction = target - playerpos;
        var dist = Vector3.Distance(playerpos, target);
        if (Physics.Raycast(playerpos, direction, out hit, dist))
        {
            target = hit.point - direction.normalized * 0.1f;
        }
        
        transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * duration);
        transform.LookAt(aimTarget.transform);
    }
}
