using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ItemSpawner : MonoBehaviour{

    public string paperTrashTag = "PaperTrash";
    public string plasticTrashTag = "PlasticTrash";
    public string tinTrashTag = "TinTrash";
    public string bioTrashTag = "BioTrash";
    public string glassTrashTag = "GlassTrash";

    
    public Transform paperSpawner;    
    public Transform plasticSpawner;    
    public Transform bioSpawner;    
    public Transform glassSpawner;
    public Transform tinSpawner;


  
    public GameObject paperTrashprefab;
    public GameObject plasticTrashprefab;
    public GameObject glassTrashprefab;
    public GameObject bioTrashprefab;
    public GameObject tinTrashprefab;

    public void spawnPaperTrash()
    {
        Instantiate(paperTrashprefab, paperSpawner.position, Quaternion.identity);
        Debug.Log("spawned Paper");
        
    }
    public void spawnPlasticTrash()
    {
        Instantiate(plasticTrashprefab, plasticSpawner.position, Quaternion.identity);
        Debug.Log("spawned plastic");
    }
    public void spawnGlassTrash()
    {
        Instantiate(glassTrashprefab, glassSpawner.position, Quaternion.identity);
        Debug.Log("spawned glass");
    }
    public void spawnBioTrash()
    {
        Instantiate(bioTrashprefab, bioSpawner.position, Quaternion.identity);
        Debug.Log("spawned Bio");
    }
    public void spawnTinTrash()
    {
        Instantiate(tinTrashprefab, tinSpawner.position, Quaternion.identity);
        Debug.Log("spawned Tin");
    }

    public void identifyItem(GameObject givenObject)
    {
        Debug.Log("hallo");
        if(givenObject.tag == paperTrashTag)
        {
            Debug.Log("go to Paper");
            spawnPaperTrash();
        }


        if (givenObject.tag == plasticTrashTag)
        {
            Debug.Log("go to Plastic");
            spawnPlasticTrash();
        }

        if (givenObject.tag == glassTrashTag)
        {
            Debug.Log("go to glass");
            spawnGlassTrash();
        }

        if (givenObject.tag == tinTrashTag)
        {
            Debug.Log("go to Tin");
            spawnTinTrash();
        }

        if (givenObject.tag == bioTrashTag)
        
        {
            Debug.Log("go to Bio");
            spawnBioTrash();
        }
    }
} 
