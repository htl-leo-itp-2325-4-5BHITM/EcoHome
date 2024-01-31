using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ItemSpawn : MonoBehaviour{

 

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









    //TODO: implement identifier for given spanwer --> spawn at random or will ( location s)
    


    public void spawnPaperTrash(GameObject paperTrash)
    {
        Instantiate(paperTrashprefab, paperSpawner.position, Quaternion.identity);
    }
    public void spawnPlasticTrash(GameObject plasticTrash)
    {
        Instantiate(plasticTrashprefab, plasticSpawner.position, Quaternion.identity);
    }
    public void spawnGlassTrash(GameObject glassTrash)
    {
        Instantiate(glassTrashprefab, glassSpawner.position, Quaternion.identity);
    }
    public void spawnBioTrash(GameObject BioTrash)
    {
        Instantiate(bioTrashprefab, bioSpawner.position, Quaternion.identity);
    }
    public void spawnTinTrash(GameObject TinTrash)
    {
        Instantiate(tinTrashprefab, tinSpawner.position, Quaternion.identity);
    }

    public void identifyItem(GameObject givenObject)
    {
        if(givenObject.tag == paperTrashTag)
        {
            spawnPaperTrash(givenObject);
        }


        if (givenObject.tag == plasticTrashTag)
        {
            spawnPlasticTrash(givenObject);
        }

        if (givenObject.tag == glassTrashTag)
        {
            spawnGlassTrash(givenObject);
        }

        if (givenObject.tag == tinTrashTag)
        {
            spawnTinTrash(givenObject);
        }

        if (givenObject.tag == bioTrashTag)
        {
            spawnBioTrash(givenObject);
        }
    }
} 
