using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ItemSpawner : MonoBehaviour{

    public const string paperTrashTag = "PaperTrash";
    public const string plasticTrashTag = "PlasticTrash";
    public const string tinTrashTag = "TinTrash";
    public const string bioTrashTag = "BioTrash";
    public const string glassTrashTag = "GlassTrash";

    public Transform paperSpawner;    
    public Transform plasticSpawner;    
    public Transform bioSpawner;    
    public Transform glassSpawner;
    public Transform tinSpawner;

    [SerializeField] private GameObject paperTrashprefab;
    [SerializeField] private GameObject plasticTrashprefab;
    [SerializeField] private GameObject glassTrashprefab;
    [SerializeField] private GameObject bioTrashprefab;
    [SerializeField] private GameObject tinTrashprefab;

    public void spawnTrash(string tag) {
        /* switch (tag) 
        {
            case paperTrashTag:
                Instantiate(paperTrashprefab, new Vector3(-0.052f, 0.649f, 1.767f), Quaternion.identity);
                break;
            case plasticTrashTag:
                Instantiate(plasticTrashprefab, new Vector3(-3.253f, 0.525f, -4.472f), Quaternion.identity);
                break;
            case glassTrashTag:
                Instantiate(glassTrashprefab, new Vector3(-3.138f, 1.007f, -4.879f), Quaternion.identity);
                break;
            case bioTrashTag:
                Instantiate(bioTrashprefab, new Vector3(-3.253f, 0.521f, -4.541f), Quaternion.identity);
                break;
            case tinTrashTag:
                Instantiate(tinTrashprefab, new Vector3(-3.162f, 0.689f, -4.726f), Quaternion.identity);
                break;
            default:
                Debug.Log("failed instantiate");
                break;
        }*/
    }

    public void identifyItem(GameObject givenObject)
    {
        spawnTrash(givenObject.tag);
    }
} 
