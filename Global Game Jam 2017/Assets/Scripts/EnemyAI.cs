using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private List<Transform> lPatrolPlaces;

    [SerializeField]
    private Transform viewPoint;
    
    [SerializeField]
    private enum statesAI
    {
        lookOut,
        patrol,
        alert
    }

    private GameObject player1;

    private string normalState;

    // Use this for initialization
    void Start () {
        player1 = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {
		
	}



}
