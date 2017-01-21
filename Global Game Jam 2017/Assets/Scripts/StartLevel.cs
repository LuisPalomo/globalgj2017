using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour {

    public GameObject player1;
    [SerializeField]
    private Transform begin;

	// Use this for initialization
	void Start () {
        Instantiate(player1,begin.position,Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
