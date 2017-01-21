using Extensions.System.Colections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralManager : MonoBehaviour {

    List <GameObject> lRoom;

    public GameObject lrt;

    private float offSetP;

	// Use this for initialization
	void Start () {
       Renderer rend = GetComponent<Renderer>();
       Vector3 v3Rend=Vector3.forward*rend.bounds.size.z;
        
       Vector3 tMid = (rend.bounds.max+rend.bounds.min)*0.5f;
        
        tMid = tMid + v3Rend;
      
        Instantiate(lrt,tMid,Quaternion.identity);
        //Vector3  = rend.bounds.SqrDistance(tMid*v3Rend);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void generationLevel(int nLevel){

        int i = 0;



        while ( i<nLevel)
        {
            GameObject tempRoom = lRoom.RandomItem();

            //if(tempRoom.GetComponent<ProceduralRoom>().name)
           
        }

       


        }
}
