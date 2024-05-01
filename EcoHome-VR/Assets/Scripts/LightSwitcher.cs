using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitcher : MonoBehaviour
{
    private string pressedPair;
    private GameObject[] ceilingLights;


    // Start is called before the first frame update
    void Start()
    {
        ceilingLights = new GameObject[GameObject.FindGameObjectsWithTag("cLightSource").Length];
        System.Array.Copy(GameObject.FindGameObjectsWithTag("cLightSource"), 0, ceilingLights, 0, GameObject.FindGameObjectsWithTag("cLightSource").Length);
        System.Array.Sort(ceilingLights, (a,b) => { return a.name.CompareTo( b.name); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressLightswitch(GameObject pressedSwitch)
    {
        pressedSwitch.transform.Find("Lichtschalter").transform.Rotate(0,0,180);
        pressedPair = pressedSwitch.name.Split('_')[1];

        foreach (GameObject obj in ceilingLights)
        {
            if (obj.name == "cLightSource_" + pressedPair)
            {
                if(obj.activeSelf == true) 
                {
                    obj.SetActive(false);
                }
                else
                {
                    obj.SetActive(true);
                }
                break;
            }
        }

    }
}
