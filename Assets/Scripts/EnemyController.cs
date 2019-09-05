using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    #region SerializeFieldVariables
    
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject destination;
    [SerializeField] private float bulletOffset = 4;
    [SerializeField] private float bulletVelocity = 200;

    #endregion

    private int AP = 10000;
    private Vector3 dir;
    private NavMeshAgent agent;
    private bool find = false;

    void Start()
    {
        var reactiveAP = new ReactiveProperty<int>();
        reactiveAP.Value = AP;
        
        player = GameObject.FindWithTag("Player");
        
        agent = GetComponent<NavMeshAgent>();
       
        // プレイヤーに射線が通れば撃つ
        this.UpdateAsObservable()
            .Where(_ => find)
            .Subscribe(_ => Shot());

        // レイキャストで射線判定＆移動
        this.UpdateAsObservable()
            .Subscribe(_ =>
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
            });

        // 被弾時のダメージ判定
        this.OnTriggerEnterAsObservable()
            .Where(x => x.CompareTag("bullet"))
            .Subscribe(_ => reactiveAP.Value -= 1000);

        // 撃破判定
        reactiveAP.AsObservable()
            .Where(_ => reactiveAP.Value < 0)
            .Subscribe(_ => Destroy(gameObject));
    }

    void EnemyMove()
    {
        Vector3 offset = new Vector3(Random.Range(0f,10f), Random.Range(0f,10f), Random.Range(0f,10f));
        destination.transform.position = player.transform.position - offset;
        agent.SetDestination(destination.transform.position);
    }

    void Shot()
    {
/*
        Instantiate(bullet, transform.position + transform.forward * 4, Quaternion.identity)
            .GetComponent<Rigidbody>()
            .AddForce(transform.forward * bulletVelocity, ForceMode.Impulse);
*/

        Debug.Log("Shot() Called");
    }
}
