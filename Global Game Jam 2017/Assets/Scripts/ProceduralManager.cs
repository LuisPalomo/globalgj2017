using Extensions.System.Colections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralManager : MonoBehaviour {

    [SerializeField]
    private float offSetZ;

    public int nLevels=3;

    [SerializeField]
    private GameObject startPlace;
    [SerializeField]
    private GameObject endPlace;
    [SerializeField]
    private List <GameObject> lRoom;

    

    

	// Use this for initialization
	void Start () {

        generationLevel(nLevels);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void generationLevel(int nLevel){

        int i = 0;

        bool checkLastRoom = false;

        string tempNameRoom="Nop";

        Vector3 rendTotal = Vector3.zero;

        Vector3 posPreview = Vector3.zero;

        GameObject tempRoomCurrent = null;

        GameObject tempRoomPreview = null;

        while (!checkLastRoom)
        {
            if (tempNameRoom.Equals("Nop"))
            {
                tempRoomCurrent = startPlace;
            }else if (i==nLevel)
            {
                tempRoomCurrent = endPlace;
                checkLastRoom = true;
            }
            else
            {
                tempRoomCurrent = lRoom.RandomItem();
            }
           
            if (!tempRoomCurrent.GetComponent<ProceduralRoom>().name.Equals(tempNameRoom))
            {
                tempNameRoom = tempRoomCurrent.GetComponent<ProceduralRoom>().name;

                Renderer tempRendFloor = tempRoomCurrent.transform.FindChild("floor").GetComponent<Renderer>();

                Vector3 rendBoundZ = Vector3.forward * (tempRendFloor.bounds.size.z);

                Vector3 rendMid = rendBoundZ*0.5f;

                rendTotal += rendMid +(Vector3.forward*offSetZ);

                if (tempRoomPreview!=null)
                {
                    Renderer tempRendFpreview = tempRoomPreview.transform.FindChild("floor").GetComponent<Renderer>();

                    Vector3 rendBoundZP = Vector3.forward * (tempRendFpreview.bounds.size.z);

                    rendTotal += rendBoundZP * 0.5f;
                }

                Instantiate(tempRoomCurrent, rendTotal, Quaternion.identity);

                tempRoomPreview = tempRoomCurrent;


                if (!tempNameRoom.Equals("first"))
                {
                    i++;
                }
            }
           
        }
     }

    public void createRoom(GameObject roomCurrent,GameObject roomPreview)
    {




    }
}
