using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ItemSpawn : MonoBehaviour{

    public Transform spawner;
    
 //TODO: implement identifier for given spanwer --> spawn at random or will ( location s)
    public void spawnGivenItem(GameOject object){

        Instantiate(object, spawner.identity, Quaternion.identity);
    }

}
