using UnityEngine;
using System;
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
        

   

    }
    void Update(){


    }

    
    public void spawnTrash(string tag) {
        System.Random rand = new System.Random();
        int fieldToSpawn = rand.Next(0, 9);
    

        switch (tag) 
        {
            case paperTrashTag:
            
                
                    Instantiate(plasticTrashprefab, spawnerField[fieldToSpawn]);
               
                break;
            case plasticTrashTag: 
            
                
                    Instantiate(plasticTrashprefab, spawnerField[fieldToSpawn]);
               
                break;
            case glassTrashTag:
                    Instantiate(glassTrashprefab, spawnerField[fieldToSpawn]);
               
                break;
            case bioTrashTag: 
                    Instantiate(bioTrashprefab, spawnerField[fieldToSpawn]);
               
                break;
            case tinTrashTag: 
                    Instantiate(tinTrashprefab, spawnerField[fieldToSpawn]);
               
                break;
            default:
                Debug.Log("failed instantiate");
                break;
        }
    }



}