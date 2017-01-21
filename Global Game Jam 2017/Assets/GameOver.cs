using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    private ShowPanels showPanels;                      //Reference to the ShowPanels script used to hide and show UI panels

    //Awake is called before Start()
    void Awake()
    {
        //Get a component reference to ShowPanels attached to this object, store in showPanels variable
        showPanels = (ShowPanels)FindObjectOfType(typeof(ShowPanels));
    }

    private void OnCollisionEnter(Collision collision)
    {
       if(collision.gameObject.tag == "Enemy")
        {
            ShowGameOverPanel();
        }
    }

    public void ShowGameOverPanel()
    {
        //Set time.timescale to 0, this will cause animations and physics to stop updating
        Time.timeScale = 0;
        //call the ShowGameOverPanel function of the ShowPanels script
        showPanels.ShowGameOverPanel();
    }

}
