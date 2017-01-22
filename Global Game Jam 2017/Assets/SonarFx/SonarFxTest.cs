using UnityEngine;
using System.Collections;

public class SonarFxTest : MonoBehaviour
{
    public int sonarCharges;
    public GUIStyle style;
    bool sonarActive = false;
    GameObject enemy;


    private void Awake()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (!sonarActive && sonarCharges > 0)
            {
                sonarCharges--;
                toggleSonar();
                Invoke("toggleSonar", 5);
            }
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(25, 0, 400, 100), "Sonar Charges: " + sonarCharges.ToString(), style);
    }

    void toggleSonar()
    {
        sonarActive = !sonarActive;
        enemy.GetComponent<MeshRenderer>().enabled = sonarActive; 
        GetComponent<SonarFxSwitcher>().Toggle();
    }
}
