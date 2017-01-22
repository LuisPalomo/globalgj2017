using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

   
    private NavMeshAgent agent;

    [SerializeField]
    private Transform patrolPlace1;

    [SerializeField]
    private Transform patrolPlace2;

    private Transform playerTrans;
    
    [SerializeField]
    private enum statesAI
    {
        lookOut,
        patrol,
        alert
    }

    private string normalState;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    [HideInInspector]
    public bool sawPlayer=false;

    [HideInInspector]
    public bool patrol=false;
    // Use this for initialization
    void Start () {

        agent = this.GetComponent<NavMeshAgent>();

        StartCoroutine("FindTargetsWithDelay", .2f);
    }
	



    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
            if (sawPlayer)
            {
                FollowPlayer();
            }

            if (patrol && !sawPlayer)
            {
                agent.SetDestination(patrolPlace1.position);

            }else if(!patrol && !sawPlayer)
            {
                agent.SetDestination(patrolPlace2.position);
            }
        }
    }


    void FollowPlayer()
    {
        agent.SetDestination(playerTrans.position);
    }

    void FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            playerTrans = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, obstacleMask))
                {
                    this.sawPlayer = true;
                    visibleTargets.Add(target);
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

}
