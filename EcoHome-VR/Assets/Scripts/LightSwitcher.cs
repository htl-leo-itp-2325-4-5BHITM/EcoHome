using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitcher : MonoBehaviour
{

    private string pressedPair;
    private GameObject pairedLight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressLightswitch()
    {
        pressedPair = this.gameObject.name.Split('_')[1];
        pairedLight = GameObject.Find("ceilingLight_" + pressedPair + "/Point Light");

        if(pairedLight.activeSelf == true) 
        {
            pairedLight.SetActive(false);
        }
    }
}
