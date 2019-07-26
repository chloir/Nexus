using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject destination;
    [SerializeField] private float bulletOffset = 4;
    [SerializeField] private float bulletVelocity = 200;
    private Vector3 dir;
    private NavMeshAgent agent;
    private bool find = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
       
        this.UpdateAsObservable()
            .Where(_ => find)
            .Subscribe(_ => Shot());
    }

    // Update is called once per frame
    void Update()
    {
        var dist = Vector3.Distance(transform.position, player.transform.position);
        dir = player.transform.position - transform.position;
        
        RaycastHit hit;
        if (Physics.Raycast(this.transform.position, dir.normalized, out hit, dist))
        {
            find = false;
        }
        else
        {
            find = true;
        }
        
        EnemyMove();
        
        transform.LookAt(player.transform.position);
        
        Debug.Log(find);
    }

    void EnemyMove()
    {
        Vector3 offset = new Vector3(Random.Range(0f,10f), Random.Range(0f,10f), Random.Range(0f,10f));
        destination.transform.position = player.transform.position - offset;
        agent.SetDestination(destination.transform.position);
    }

    void Shot()
    {
        var obj = Instantiate(bullet, dir.normalized * bulletOffset, Quaternion.identity);
        var rigid = obj.GetComponent<Rigidbody>();
        rigid.AddForce(transform.forward * bulletVelocity, ForceMode.Impulse);

        Debug.Log("Shot() Called");
    }
}
