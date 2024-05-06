using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LightSwitcher : MonoBehaviour
{
    private Player player;
    private Playerchall playerchall;

    private string pressedPair;
    private GameObject[] ceilingLights;
    private GameObject[] deskLights;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.Find("Player").GetComponent<Player>()) 
        {
            player = GameObject.Find("Player").GetComponent<Player>();
        }
        else if(GameObject.Find("Player").GetComponent<Playerchall>()) 
        {
            playerchall = GameObject.Find("Player").GetComponent<Playerchall>();
        }

        ceilingLights = new GameObject[GameObject.FindGameObjectsWithTag("cLightSource").Length];
        System.Array.Copy(GameObject.FindGameObjectsWithTag("cLightSource"), 0, ceilingLights, 0, GameObject.FindGameObjectsWithTag("cLightSource").Length);
        System.Array.Sort(ceilingLights, (a,b) => { return a.name.CompareTo(b.name); });

        deskLights = new GameObject[GameObject.FindGameObjectsWithTag("dLightSource").Length];
        System.Array.Copy(GameObject.FindGameObjectsWithTag("dLightSource"), 0, deskLights, 0, GameObject.FindGameObjectsWithTag("dLightSource").Length);
        System.Array.Sort(deskLights, (a,b) => { return a.name.CompareTo(b.name); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressLightswitch(GameObject pressedSwitch)
    {
        pressedSwitch.transform.Find("Lichtschalter").transform.Rotate(0,0,180);
        pressedPair = pressedSwitch.name.Split('_')[1];
        Scene scene = SceneManager.GetActiveScene();

        foreach (GameObject obj in ceilingLights)
        {
            if (obj.name == "cLightSource_" + pressedPair)
            {
                // add sfx here

                if(obj.activeSelf == true) 
                {
                    obj.SetActive(false);

                    if(scene.name == "Challenge - Main Scene")
                    {
                        Playerchall.localScoreCounter += 1;
                        Playerchall.globalScoreCounter += 1;
                        Playerchall.displayScoreCounter += 1;
                    }
                    else
                    {
                        Player.localScoreCounter += 1;
                        Player.globalScoreCounter += 1;
                        Player.displayScoreCounter += 1;
                    }
                }
                else
                {
                    obj.SetActive(true);

                    if(scene.name == "Challenge - Main Scene")
                    {
                        Playerchall.localScoreCounter -= 1;
                        Playerchall.globalScoreCounter -= 1;
                        Playerchall.displayScoreCounter -= 1;
                    }
                    else
                    {
                        Player.localScoreCounter -= 1;
                        Player.globalScoreCounter -= 1;
                        Player.displayScoreCounter -= 1;
                    }
                }
                break;
            }
        }
    }

    public void PressDeskLight(GameObject pressedSwitch)
    {
        pressedPair = pressedSwitch.name.Split('_')[2];
        Scene scene = SceneManager.GetActiveScene();

        foreach (GameObject obj in deskLights)
        {
            if (obj.name == "dLightSource_" + pressedPair)
            {
                // add sfx here

                if(obj.activeSelf == true) 
                {
                    obj.SetActive(false);
                    
                    if(scene.name == "Challenge - Main Scene")
                    {
                        Playerchall.localScoreCounter += 1;
                        Playerchall.globalScoreCounter += 1;
                        Playerchall.displayScoreCounter += 1;
                    }
                    else
                    {
                        Player.localScoreCounter += 1;
                        Player.globalScoreCounter += 1;
                        Player.displayScoreCounter += 1;
                    }
                }
                else
                {
                    obj.SetActive(true);

                    if(scene.name == "Challenge - Main Scene")
                    {
                        Playerchall.localScoreCounter -= 1;
                        Playerchall.globalScoreCounter -= 1;
                        Playerchall.displayScoreCounter -= 1;
                    }
                    else
                    {
                        Player.localScoreCounter -= 1;
                        Player.globalScoreCounter -= 1;
                        Player.displayScoreCounter -= 1;
                    }
                }
                break;
            }
        }

    }

    public void TurnOnRandomLight()
    {
        Scene scene = SceneManager.GetActiveScene();
        System.Random random = new System.Random();

        if(scene.name == "Challenge - Main Scene") 
        {
            // generates random integer, values 0 or 1
            var deskOrCeilingLight = random.Next(0, 2);

            if (deskOrCeilingLight == 0) 
            {
                ceilingLights[random.Next(0, ceilingLights.Length)].SetActive(true);
            }
            else if (deskOrCeilingLight == 1)
            {
                deskLights[random.Next(0, deskLights.Length)].SetActive(true);
            }
        }
    }

}
