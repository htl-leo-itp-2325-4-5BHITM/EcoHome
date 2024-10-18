using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider Entered: " + other.tag);
        if (other.CompareTag("Player_Collider") && this.gameObject.CompareTag("DoorSensor"))
        {
            Debug.Log("Spieler ist durch die Tür gegangen!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Collider Exited: " + other.tag);
        if (other.CompareTag("Player_Collider") && this.gameObject.CompareTag("DoorSensor"))
        {
            Debug.Log("Spieler hat den Türbereich verlassen!");
        }
    }
}
