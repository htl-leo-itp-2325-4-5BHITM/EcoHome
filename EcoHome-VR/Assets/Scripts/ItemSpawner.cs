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

    
    [SerializeField]
    public GameObject paperTrashprefab;
    [SerializeField]
    private GameObject plasticTrashprefab;
    [SerializeField]
    private GameObject glassTrashprefab;
    [SerializeField]
    private GameObject bioTrashprefab;
    [SerializeField]
    private GameObject tinTrashprefab;

    public void spawnPaperTrash()
    {
        Debug.Log(paperTrashprefab);
        Instantiate(paperTrashprefab, new Vector3(-1.27f, -0.16f, 0), Quaternion.identity);
        Debug.Log("spawned Paper");
        
    }
    public void spawnPlasticTrash()
    {
        Instantiate(plasticTrashprefab, new Vector3(-0.38f, -0.43f, -4.14f), Quaternion.identity);
        Debug.Log("spawned plastic");
    }
    public void spawnGlassTrash()
    {
        Instantiate(glassTrashprefab, new Vector3(-0.38f, -0.43f, -6.14f), Quaternion.identity);
        Debug.Log("spawned glass");
    }
    public void spawnBioTrash()
    {
        Instantiate(bioTrashprefab, new Vector3(-0.38f, -0.43f, -5.4f), Quaternion.identity);
        Debug.Log("spawned Bio");
    }
    public void spawnTinTrash()
    {
        Instantiate(tinTrashprefab, new Vector3(-0.38f, -0.43f, -6.14f), Quaternion.identity);
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
