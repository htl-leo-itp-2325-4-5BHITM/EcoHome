using System;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    private String currentRoom;
    private TutorialState _entered;

    void Awake() {
        TutoManager.OnTutorialStateChanged += TutoManager_OnTutorialStateChanged;
    }

    void OnDestroy()
    {
        TutoManager.OnTutorialStateChanged -= TutoManager_OnTutorialStateChanged;
    }

    private void TutoManager_OnTutorialStateChanged(TutorialState state)
    {
        if (state == TutorialState.StartOfGame) {
            this._entered = state;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Überprüfe, ob der Player das richtige Tag hat und die Tutorial-Bedingungen erfüllt sind


        if (other.CompareTag("Player_Collider"))
        {
            if (this.gameObject.CompareTag("FirstLevel_Door_Sensor") && this._entered == TutorialState.EndOfGame)
            {
                Debug.Log("Spieler ist durch die Tür Sec Level Door durchgegangen!");
                TutoManager.Instance.UpdateTutorialState(TutorialState.SecLevel_Start);
            }
            else if (this.gameObject.CompareTag("SecLevel_Door_Sensor") && this._entered == TutorialState.SecLevel_End)
            {
                Debug.Log("Spieler ist durch die Tür Third Level Door durchgegangen!");
                TutoManager.Instance.UpdateTutorialState(TutorialState.Third_Level_Start);
            }
            else if (this.gameObject.CompareTag("ThirdLevel_Door_Sensor") && this._entered == TutorialState.Third_Level_End)
            {
                Debug.Log("Spieler ist durch die Tür Fourth Level Door durchgegangen!");
                TutoManager.Instance.UpdateTutorialState(TutorialState.Fourth_Level_Start);
            }
            else if (this.gameObject.CompareTag("FourthLevel_Door_Sensor") && this._entered == TutorialState.Fourth_Level_End)
            {
                Debug.Log("Spieler ist durch die Tür Fifth Level Door durchgegangen!");
                TutoManager.Instance.UpdateTutorialState(TutorialState.Fifth_Level_Start);
            }
            else if (this.gameObject.CompareTag("FifthLevel_Door_Sensor") && this._entered == TutorialState.Fifth_Level_End)
            {
                Debug.Log("Spieler ist durch die Tür Sixth Level Door durchgegangen!");
                TutoManager.Instance.UpdateTutorialState(TutorialState.Sixth_Level_Start);
            }
            else if (this.gameObject.CompareTag("SixthLevel_Door_Sensor") && this._entered == TutorialState.Sixth_Level_Start)
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

