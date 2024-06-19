using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WaterSwitcher : MonoBehaviour
{
    private Player player;
    private Playerchall playerchall;

    private string pressedPair;
    private GameObject[] basinWaterSources;
    private GameObject[] sinkWaterSources;

    // audio system
    public AudioSource audioPlayer; 
    public AudioClip clip_1;

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

        basinWaterSources = new GameObject[GameObject.FindGameObjectsWithTag("bWaterSource").Length];
        System.Array.Copy(GameObject.FindGameObjectsWithTag("bWaterSource"), 0, basinWaterSources, 0, GameObject.FindGameObjectsWithTag("bWaterSource").Length);
        System.Array.Sort(basinWaterSources, (a,b) => { return a.name.CompareTo(b.name); });

        sinkWaterSources = new GameObject[GameObject.FindGameObjectsWithTag("sWaterSource").Length];
        System.Array.Copy(GameObject.FindGameObjectsWithTag("sWaterSource"), 0, sinkWaterSources, 0, GameObject.FindGameObjectsWithTag("sWaterSource").Length);
        System.Array.Sort(sinkWaterSources, (a,b) => { return a.name.CompareTo(b.name); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseBasinSwitcher(GameObject pressedSwitch)
    {
        pressedPair = pressedSwitch.name.Split('_')[1];
        Scene scene = SceneManager.GetActiveScene();

        foreach (GameObject obj in basinWaterSources)
        {
            if (obj.name == "bWaterSource_" + pressedPair)
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
                        audioPlayer.loop = false
                        audioPlayer.Stop();
                    }
                    else
                    {
                        Player.localScoreCounter += 1;
                        Player.globalScoreCounter += 1;
                        Player.displayScoreCounter += 1;
                        audioPlayer.loop = false
                        audioPlayer.Stop();
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
                        audioPlayer.loop = true
                        audioPlayer.PlayOneShot(clip_1);
                    }
                    else
                    {
                        Player.localScoreCounter -= 1;
                        Player.globalScoreCounter -= 1;
                        Player.displayScoreCounter -= 1;
                        audioPlayer.loop = true 
                        audioPlayer.PlayOneShot(clip_1);
                    }
                }
                break;
            }
        }
    }

    public void UseSinkSwitcher(GameObject pressedSwitch)
    {
        pressedPair = pressedSwitch.name.Split('_')[1];
        Scene scene = SceneManager.GetActiveScene();

        foreach (GameObject obj in sinkWaterSources)
        {
            if (obj.name == "sWaterSource_" + pressedPair)
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
                        audioPlayer.Stop();
                    }
                    else
                    {
                        Player.localScoreCounter += 1;
                        Player.globalScoreCounter += 1;
                        Player.displayScoreCounter += 1;
                        audioPlayer.Stop();
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
                        audioPlayer.PlayOneShot(clip_1);
                    }
                    else
                    {
                        Player.localScoreCounter -= 1;
                        Player.globalScoreCounter -= 1;
                        Player.displayScoreCounter -= 1;
                        audioPlayer.PlayOneShot(clip_1);
                    }
                }
                break;
            }
        }
    }

    // adapted from LightSwitcher.cs
    public void TurnOnRandomWaterSource()
    {
        Scene scene = SceneManager.GetActiveScene();
        System.Random random = new System.Random();

        if(scene.name == "Challenge - Main Scene") 
        {
            basinWaterSources[random.Next(0, basinWaterSources.Length)].SetActive(true);
        }
    }

}
