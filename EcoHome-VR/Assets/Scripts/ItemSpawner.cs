using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ItemSpawn : MonoBehaviour{

    public Transform spawner;

    public string paperTrashTag = "PaperTrash";
    public string plasticTrashTag = "PlasticTrash";
    public string tinTrashTag = "TinTrash";
    public string bioTrashTag = "BioTrash";
    public string glassTrashTag = "GlassTrash";


    public GameObject paperSpawner;
    public GameObject plasticSpwaner;
    public GameObject bioSpawner;
    public GameObject glassSpawner;
    public GameObject tinSpawner;


    public GameObject paperTrashprefab;
    public GameObject plasticTrashprefab;
    public GameObject glassTrashprefab;
    public GameObject bioTrashprefab;
    public GameObject tinTrashprefab;









    //TODO: implement identifier for given spanwer --> spawn at random or will ( location s)
    public void spawnGivenItem(GameObject objectToSpawn){
        Instantiate(objectToSpawn, spawner.position, Quaternion.identity);
    }


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
        switch (givenObject) {
            case givenObject.tag == paperTrashTag:
                spawnPaperTrash(givenObject);
            case givenObject.tag == glassTrashTag:
                spawnGlassTrash(givenObject);
            case givenObject.tag == plasticTrashTag:
                spawnPlasticTrash(givenObject);
            case givenObject.tag == tinTrashTag:
                spawnTinTrash(givenObject);
            case givenObject.tag == bioTrashTag:
                spawnBioTrash(givenObject);
        }
    }
} 
