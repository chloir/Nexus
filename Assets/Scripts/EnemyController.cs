using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var dir = player.transform.position - transform.position;
        var dist = Vector3.Distance(transform.position, player.transform.position);

        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, dir.normalized, out hit, dist))
        {
        }
    }
}
