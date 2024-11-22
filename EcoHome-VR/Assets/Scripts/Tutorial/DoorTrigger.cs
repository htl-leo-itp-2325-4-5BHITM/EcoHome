using System;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    private String currentRoom;
    private TutorialState _entered;

    private bool _leftFirstRoom = false;
    private bool _leftSecRoom = false;
    private bool _leftThirdRoom = false;
    private bool _leftForthRoom = false;
    private bool _leftFifthRoom = false;
    private bool _leftSixthRoom = false;

    void Awake() {
        TutoManager.OnTutorialStateChanged += TutoManager_OnTutorialStateChanged;
    }

    void OnDestroy()
    {
        TutoManager.OnTutorialStateChanged -= TutoManager_OnTutorialStateChanged;
    }

    private void TutoManager_OnTutorialStateChanged(TutorialState state)
    {
        this._entered = state;
        Debug.Log("_entered = " + this._entered);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Überprüfe, ob der Player das richtige Tag hat und die Tutorial-Bedingungen erfüllt sind


        if (other.CompareTag("Player_Collider"))
        {
            if (this.gameObject.CompareTag("FirstLevel_Door_Sensor") && !_leftFirstRoom)
            {
                Debug.Log("Spieler ist durch die Tür Sec Level Door durchgegangen!");
                this._leftFirstRoom = true;
                TutoManager.Instance.UpdateTutorialState(TutorialState.SecLevel_Start);
            }
            else if (this.gameObject.CompareTag("SecLevel_Door_Sensor") && !_leftSecRoom)
            {
                Debug.Log("Spieler ist durch die Tür Third Level Door durchgegangen!");
                this._leftSecRoom = true;
                TutoManager.Instance.UpdateTutorialState(TutorialState.Third_Level_Start);
            }
            else if (this.gameObject.CompareTag("ThirdLevel_Door_Sensor") && !_leftThirdRoom)
            {
                Debug.Log("Spieler ist durch die Tür Fourth Level Door durchgegangen!");
                this._leftThirdRoom = true;
                TutoManager.Instance.UpdateTutorialState(TutorialState.Fourth_Level_Start);
            }
            else if (this.gameObject.CompareTag("FourthLevel_Door_Sensor") && !_leftForthRoom)
            {
                Debug.Log("Spieler ist durch die Tür Fifth Level Door durchgegangen!");
                this._leftForthRoom = true;
                TutoManager.Instance.UpdateTutorialState(TutorialState.Fifth_Level_Start);
            }
            else if (this.gameObject.CompareTag("FifthLevel_Door_Sensor") && !_leftFifthRoom)
            {
                Debug.Log("Spieler ist durch die Tür Sixth Level Door durchgegangen!");
                TutoManager.Instance.UpdateTutorialState(TutorialState.Sixth_Level_Start);
            }
            else if (this.gameObject.CompareTag("SixthLevel_Door_Sensor") && !_leftSixthRoom)
            {
                Debug.Log("Spieler ist durch die Tür Zero Level Door durchgegangen!");
                TutoManager.Instance.UpdateTutorialState(TutorialState.End_Of_Tutorial);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player_Collider"))
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
        }

        Debug.Log("Room number: " + this.currentRoom);
    }
/*
    public void UpdatePlayerLevelState(PlayerLevel_State newState)
    {
        this.State = newState; // Direkte Zuweisung, da keine weiteren Aktionen erforderlich sind
        Debug.Log("Level gewechselt zu: " + newState);
    }
    */
}

