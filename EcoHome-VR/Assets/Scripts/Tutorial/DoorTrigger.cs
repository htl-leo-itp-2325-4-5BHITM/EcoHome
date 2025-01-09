using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    private String currentRoom = "Room 1";

    private bool _leftFirstRoom = false;
    private bool _leftSecRoom = false;
    private bool _leftThirdRoom = false;
    private bool _leftForthRoom = false;
    private bool _leftFifthRoom = false;
    private bool _leftSixthRoom = false;

    void OnEnable() {
        TutoManager.OnTutorialStateChanged += TutoManager_OnTutorialStateChanged;
    }

    void OnDisable()
    {
        TutoManager.OnTutorialStateChanged -= TutoManager_OnTutorialStateChanged;
    }

    private void TutoManager_OnTutorialStateChanged(TutorialState state)
    {
        Debug.Log("_entered = " + state);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Überprüfe, ob der Player das richtige Tag hat und die Tutorial-Bedingungen erfüllt sind

        Debug.Log("OnTriggerEnter checks Door Sensor");
        if (this.gameObject.CompareTag("FirstLevel_Door_Sensor") && !_leftFirstRoom)
        {
            Debug.Log("Spieler ist durch die Tür Sec Level Door durchgegangen!");
            this._leftFirstRoom = true;
            currentRoom = "Room 2";
            TutoManager.Instance.UpdateTutorialState(TutorialState.SecLevel_Start);
        }
        else if (this.gameObject.CompareTag("SecLevel_Door_Sensor") && !_leftSecRoom)
        {
            Debug.Log("Spieler ist durch die Tür Third Level Door durchgegangen!");
            this._leftSecRoom = true;
            currentRoom = "Room 3";
            TutoManager.Instance.UpdateTutorialState(TutorialState.Third_Level_Start);
        }
        else if (this.gameObject.CompareTag("ThirdLevel_Door_Sensor") && !_leftThirdRoom)
        {
            Debug.Log("Spieler ist durch die Tür Fourth Level Door durchgegangen!");
            this._leftThirdRoom = true;
            currentRoom = "Room 4";
            TutoManager.Instance.UpdateTutorialState(TutorialState.Fourth_Level_Start);
        }
        else if (this.gameObject.CompareTag("FourthLevel_Door_Sensor") && !_leftForthRoom)
        {
            Debug.Log("Spieler ist durch die Tür Fifth Level Door durchgegangen!");
            this._leftForthRoom = true;
            currentRoom = "Room 5";
            TutoManager.Instance.UpdateTutorialState(TutorialState.Fifth_Level_Start);
        }
        else if (this.gameObject.CompareTag("FifthLevel_Door_Sensor") && !_leftFifthRoom)
        {
            Debug.Log("Spieler ist durch die Tür Sixth Level Door durchgegangen!");
            currentRoom = "Room 6";
            TutoManager.Instance.UpdateTutorialState(TutorialState.Sixth_Level_Start);
        }
        else if (this.gameObject.CompareTag("SixthLevel_Door_Sensor") && !_leftSixthRoom)
        {
            Debug.Log("Spieler ist durch die Tür Zero Level Door durchgegangen!");
            currentRoom = "Room 7";
            TutoManager.Instance.UpdateTutorialState(TutorialState.End_Of_Tutorial);
        }
    
         Debug.Log("On Trigger Enter Room number: " + this.currentRoom);
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.gameObject.CompareTag("FirstLevel_Door_Sensor"))
        {
            Debug.Log("Spieler hat den First Level Room verlassen!");
            currentRoom = "Room 2";
        }
        else if (this.gameObject.CompareTag("SecLevel_Door_Sensor"))
        {
            Debug.Log("Spieler hat den Sec Level Room verlassen!");
            currentRoom = "Room 3";
        }
        else if (this.gameObject.CompareTag("ThirdLevel_Door_Sensor"))
        {
            Debug.Log("Spieler hat den Third Level Room verlassen!");
            currentRoom = "Room 4";
        }
        else if (this.gameObject.CompareTag("FourthLevel_Door_Sensor"))
        {
            Debug.Log("Spieler hat den Fourth Level Room verlassen!");
            currentRoom = "Room 5";
        }
        else if (this.gameObject.CompareTag("FifthLevel_Door_Sensor"))
        {
            Debug.Log("Spieler hat den Fifth Level Room verlassen!");
            currentRoom = "Room 6";
        }
        else if (this.gameObject.CompareTag("SixthLevel_Door_Sensor"))
        {
            Debug.Log("Spieler hat den Sixth Level Room verlassen!");
            currentRoom = "Rooom 7";
        }

        Debug.Log("On Trigger Exit Room number: " + this.currentRoom);
    }
}

