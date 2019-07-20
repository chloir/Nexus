using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject target;

    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        this.UpdateAsObservable()
            .Where(_ => agent.pathStatus != NavMeshPathStatus.PathInvalid)
            .Subscribe(_ => agent.SetDestination(target.transform.position));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
