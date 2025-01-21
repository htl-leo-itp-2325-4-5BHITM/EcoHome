using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine.SceneManagement;
using TMPro;
using static LightSwitcher;

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

  
    private Timer displayTimer;
    private Timer repeatTimer;

    TextMeshProUGUI displayTime;
    
    TextMeshProUGUI displayScore;
    private MainMenuInteractor interactor;
    LightSwitcher lightSwitcher ;

    private Networker networker;

    System.Random rand = new System.Random();
    private int timeleft = 60;
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
        
        StartRepeatAction(() => newRandomEvent(), 5000);
        StartRepeatActionDisplay(() => UpdateDisplay(), 1000);
        //Debug.Log("started Actions");
        StartCoroutine( "helpMeDaddy");

        networker =  GameObject.Find("networkerObject").GetComponent<Networker>();

        displayTime = GameObject.Find("Display Time").GetComponent<TextMeshProUGUI>();
        lightSwitcher = GameObject.Find("Lightswitcher").GetComponent<LightSwitcher>();
        displayScore = GameObject.Find("Display Score").GetComponent<TextMeshProUGUI>();

        //Debug.Log("Finished Init");
    }

    async void Update(){
        if(!challangeFailedYet())
        {     
            if (SceneManager.GetActiveScene().name.StartsWith("[EN]")) displayTime.text = "Time Left: " + timeleft;
            else displayTime.text = "Übrige Zeit: " + timeleft;
        }
        else{ 
            CheckAndSaveHighscore();

            // Destroy player here
            if (SceneManager.GetActiveScene().name.StartsWith("[EN]")) SceneManager.LoadScene("[EN] Main Menu - Main Scene");
            else SceneManager.LoadScene("Main Menu - Main Scene");
        }

    }

    public void CheckAndSaveHighscore() {
        HighscorePlayerPrefs();
        HighscoreServer();
    }
    public void HighscorePlayerPrefs() {
        int finalScore = Playerchall.displayScoreCounter;

        if(PlayerPrefs.HasKey("HighscoreChallenge")) 
        {
            if(PlayerPrefs.GetInt("HighscoreChallenge") < finalScore) 
            {
                PlayerPrefs.SetInt("HighscoreChallenge", finalScore);
            }
        } 
        else PlayerPrefs.SetInt("HighscoreChallenge", finalScore);

        
        PlayerPrefs.Save();
    }
    public void HighscoreServer() {
        Debug.Log("initalize sending");
        Debug.Log(networker);
        if (networker == null) {
            Debug.LogError("Networker instance not found in the scene.");
        }else{
            Debug.Log("sending");
            networker.saveData(Playerchall.displayScoreCounter);
        }

    }

    public void UpdateDisplay() {
        timeleft =  timeleft-1;

        displayTime = GameObject.Find("Display Time").GetComponent<TextMeshProUGUI>();
        //Debug.Log("updated Time");

        
        
    }
    IEnumerator helpMeDaddy() {

        yield return new WaitForSeconds(1.0f); 
        UpdateDisplay();
        
    }
     public virtual void StartRepeatAction(Action action, int interval)
        {
            repeatTimer?.Stop();    //stopping timer if already runs
            //Debug.Log("Repeat Action Started");
            repeatTimer = new Timer(interval);
            repeatTimer.Elapsed += (sender, e) => action();
            repeatTimer.AutoReset = true;
            repeatTimer.Start();
        }
    public virtual void StartRepeatActionDisplay(Action action, int interval)
        {
            displayTimer?.Stop();    //stopping timer if already runs
            //Debug.Log("Display Action Started");
            displayTimer = new Timer(interval);
            displayTimer.Elapsed += (sender, e) => action();
            displayTimer.AutoReset = true;
            displayTimer.Start();
        }

    public Boolean challangeFailedYet(){
        if(timeleft == 0){
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

    
    public void spawnTrash(string tag) {
        //Debug.Log("entered Spawn Trash");
        //Debug.Log(tag);
        //System.Random rand = new System.Random();
        int fieldToSpawn = rand.Next(0, 9);
        //Debug.Log(fieldToSpawn);

        switch (tag) 
        {
            case paperTrashTag:     
                    //Debug.Log("Spawn please");          
                    Instantiate(paperTrashprefab, spawnerField[fieldToSpawn]);
                    //Debug.Log("Paper Trash Spawned");
                    leftToWin--;
                break;
            case plasticTrashTag: 
                    Instantiate(plasticTrashprefab, spawnerField[fieldToSpawn]);
                    //Debug.Log("Plastic Trash Spawned");
                    leftToWin--;
                break;
            case glassTrashTag:
                    Instantiate(glassTrashprefab, spawnerField[fieldToSpawn]);
                    //Debug.Log("Glass Trash Spawned");
                    leftToWin--;
                break;
            case bioTrashTag: 
                    Instantiate(bioTrashprefab, spawnerField[fieldToSpawn]);
                    //Debug.Log("Bio Trash Spawned");
                    leftToWin--;
                break;
            case tinTrashTag: 
                    Instantiate(tinTrashprefab, spawnerField[fieldToSpawn]);
                    //Debug.Log("Tin Trash Spawned");
                    leftToWin--;
                break;
            default:
                //Debug.Log("failed instantiate");
                break;
        }
    }
     
    public void newRandomEvent(){
        //Debug.Log("Random new Started");

        int eventToTrigger = rand.Next(0, 7);
        //Debug.Log(eventToTrigger);

        if(eventToTrigger == 4){
                spawnTrash(plasticTrashTag);
                //Debug.Log("paperTrash");
       }

        switch (eventToTrigger)
        {
            case 0:
                spawnTrash(paperTrashTag);
                //Debug.Log("paperTrash");
                break;
            case 1:
                spawnTrash(plasticTrashTag);
                //Debug.Log("plasticTrash");
                break;
            case 2:
                spawnTrash(glassTrashTag);
                //Debug.Log("glassTrash");
                break;
            case 3:
                spawnTrash(bioTrashTag);
                //Debug.Log("bioTrash");
                break;
            case 4:
                spawnTrash(tinTrashTag);
                //Debug.Log("tinTrash");
                break;
            case 5:
                lightSwitcher.TurnOnRandomLight();
                //Debug.Log("Random Light");
                break;
            case 6: 
                lightSwitcher.TurnOnRandomLight();
                //Debug.Log("Random Light");
                break;
            case 7:
                lightSwitcher.TurnOnRandomLight();
                //Debug.Log("Random Light");
                break;
            default:
                //Debug.Log("failed instantiate");
                break;
        }
    }



}