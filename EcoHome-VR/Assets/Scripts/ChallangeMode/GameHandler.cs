using UnityEngine;
using System;
using System.Timers;
using UnityEngine.SceneManagement;
using TMPro;
class GameHandler : MonoBehaviour{
    public const string paperTrashTag = "PaperTrash";
    public const string plasticTrashTag = "PlasticTrash";
    public const string tinTrashTag = "TinTrash";
    public const string bioTrashTag = "BioTrash";
    public const string glassTrashTag = "GlassTrash";


    [SerializeField] private GameObject paperTrashprefab;
    [SerializeField] private GameObject plasticTrashprefab;
    [SerializeField] private GameObject glassTrashprefab;
    [SerializeField] private GameObject bioTrashprefab;
    [SerializeField] private GameObject tinTrashprefab;

    [SerializeField] Transform spawnerLocation0; 
    [SerializeField] Transform spawnerLocation1; 
    [SerializeField] Transform spawnerLocation2;
    [SerializeField] Transform spawnerLocation3; 
    [SerializeField] Transform spawnerLocation4; 
    [SerializeField] Transform spawnerLocation5; 
    [SerializeField] Transform spawnerLocation6;
    [SerializeField] Transform spawnerLocation7;
    [SerializeField] Transform spawnerLocation8;   

    private Transform []  spawnerField;

  
    private Timer tim;
    TextMeshProUGUI displayTime;
    
    TextMeshProUGUI displayScore;
    private MainMenuInteractor interactor;

    private int timeleft = 0;
    private int leftToWin = 3;

    void Start(){
        spawnerField = new Transform[9];
        spawnerField[0] = spawnerLocation0;
        spawnerField[1] = spawnerLocation1;
        spawnerField[2] = spawnerLocation2;
        spawnerField[3] = spawnerLocation3;
        spawnerField[4] = spawnerLocation4;
        spawnerField[5] = spawnerLocation5;
        spawnerField[6] = spawnerLocation6;
        spawnerField[7] = spawnerLocation7;
        spawnerField[8] = spawnerLocation8;
       startNewTimer();
       
        displayTime = GameObject.Find("Display Time").GetComponent<TextMeshProUGUI>();
        
        displayScore = GameObject.Find("Display Score").GetComponent<TextMeshProUGUI>();
        
    }
    void Update(){
        if(!challangeFailedYet()){     
         //    timeleft += tim.Elapsed;
        displayTime.text = "Trash Left: " + leftToWin; //+ timeleft
        }else{ 
            SceneManager.LoadScene("Main Menu - Main Scene");

        }

    }

    
    public void spawnTrash(string tag) {
        System.Random rand = new System.Random();
        int fieldToSpawn = rand.Next(0, 9);
    

        switch (tag) 
        {
            case paperTrashTag:               
                    Instantiate(plasticTrashprefab, spawnerField[fieldToSpawn]);
                    Debug.Log("Paper Trash Spawned");
                    leftToWin--;
                break;
            case plasticTrashTag: 
                    Instantiate(plasticTrashprefab, spawnerField[fieldToSpawn]);
                    Debug.Log("Plastic Trash Spawned");
                    leftToWin--;
                break;
            case glassTrashTag:
                    Instantiate(glassTrashprefab, spawnerField[fieldToSpawn]);
                    Debug.Log("Glass Trash Spawned");
                    leftToWin--;
                break;
            case bioTrashTag: 
                    Instantiate(bioTrashprefab, spawnerField[fieldToSpawn]);
                    Debug.Log("Bio Trash Spawned");
                    leftToWin--;
                break;
            case tinTrashTag: 
                    Instantiate(tinTrashprefab, spawnerField[fieldToSpawn]);
                    Debug.Log("Tin Trash Spawned");
                    leftToWin--;
                break;
            default:
                Debug.Log("failed instantiate");
                break;
        }
    }
    public void startNewTimer(){
        tim = new Timer();
        tim.Start();       
    }

    public Boolean challangeFailedYet(){
        if(leftToWin == 0){
            return true;   
        }else{          
            return false;
        } 
      /*  if(tim.Elapsed > 600000){
            tim.Stop();
            return true;
        }else{
            displayTime.text = "Challange Ended!" ;
            return false;
        }*/
    }



}