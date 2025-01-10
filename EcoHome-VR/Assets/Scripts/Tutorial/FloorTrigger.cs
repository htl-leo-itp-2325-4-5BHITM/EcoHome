using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTrigger : MonoBehaviour
{

    public GameObject paperObject;
    public Vector3 resetPosition;


    private void OnTriggerEnter (Collider other)
    {
        Debug.Log("FloorTrigger: OnTriggerEnter");
        if (other.gameObject == paperObject)
        {
            paperObject.transform.position = resetPosition;
        }
    }

    private void OnTriggerExit (Collider other)
    {
        Debug.Log("FloorTrigger: OnTriggerExit");
    }
}