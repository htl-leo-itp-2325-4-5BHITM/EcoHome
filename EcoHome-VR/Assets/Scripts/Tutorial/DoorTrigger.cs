using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private PlayerLevel_State State;

    void Start()
    {
        this.State = PlayerLevel_State.FirstLevel;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collider Entered: " + other.tag);
        if (other.CompareTag("Player_Collider") && this.gameObject.CompareTag("FirstLevel_Door_Sensor") && this.State == PlayerLevel_State.FirstLevel)
        {
            Debug.Log("Spieler ist durch die Tür Sec Level Door durchgegangen!");
            UpdatePlayerLevelState(PlayerLevel_State.SecLevel);
            TutoManager.Instance.UpdateTutorialState(TutorialState.SecLevel_Start);
        }
        else if (other.CompareTag("Player_Collider") && this.gameObject.CompareTag("SecLevel_Door_Sensor") && this.State == PlayerLevel_State.SecLevel)
        {
            Debug.Log("Spieler ist durch die Tür Third Level Door durchgegangen!");
            UpdatePlayerLevelState(PlayerLevel_State.ThirdLevel);
            TutoManager.Instance.UpdateTutorialState(TutorialState.Third_Level_Start);
        }
        else if (other.CompareTag("Player_Collider") && this.gameObject.CompareTag("ThirdLevel_Door_Sensor") && this.State == PlayerLevel_State.ThirdLevel)
        {
            Debug.Log("Spieler ist durch die Tür Fourth Level Door durchgegangen!");
            UpdatePlayerLevelState(PlayerLevel_State.FourhtLevel);
            TutoManager.Instance.UpdateTutorialState(TutorialState.Fourth_Level_Start);
        }
        else if (other.CompareTag("Player_Collider") && this.gameObject.CompareTag("FourthLevel_Door_Sensor") && this.State == PlayerLevel_State.FourhtLevel)
        {
            Debug.Log("Spieler ist durch die Tür Fifth Level Door durchgegangen!");
            UpdatePlayerLevelState(PlayerLevel_State.FifthLevel);
            TutoManager.Instance.UpdateTutorialState(TutorialState.Fifth_Level_Start);
        }    
        else if (other.CompareTag("Player_Collider") && this.gameObject.CompareTag("FifthLevel_Door_Sensor") && this.State == PlayerLevel_State.FifthLevel)
        {
            Debug.Log("Spieler ist durch die Tür Sixth Level Door durchgegangen!");
            UpdatePlayerLevelState(PlayerLevel_State.SixthLevel);
            TutoManager.Instance.UpdateTutorialState(TutorialState.Sixth_Level_Start);
        }     
        else if (other.CompareTag("Player_Collider") && this.gameObject.CompareTag("SixthLevel_Door_Sensor") && this.State == PlayerLevel_State.SixthLevel)
        {
            Debug.Log("Spieler ist durch die Tür Zero Level Door durchgegangen!");
            UpdatePlayerLevelState(PlayerLevel_State.ZeroLevel);
            TutoManager.Instance.UpdateTutorialState(TutorialState.End_Of_Tutorial);
        }  
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Collider Exited: " + other.tag);
        if (other.CompareTag("Player_Collider") && this.gameObject.CompareTag("FirstLevel_Door_Sensor"))
        {
            Debug.Log("Spieler hat den First Level Room verlassen!");
        }
        else if (other.CompareTag("Player_Collider") && this.gameObject.CompareTag("SecLevel_Door_Sensor"))
        {
            Debug.Log("Spieler hat den Sec Level Room verlassen!");
        }
        else if (other.CompareTag("Player_Collider") && this.gameObject.CompareTag("ThirdLevel_Door_Sensor"))
        {
            Debug.Log("Spieler hat den Third Level Room verlassen!");
        }
        else if (other.CompareTag("Player_Collider") && this.gameObject.CompareTag("FourthLevel_Door_Sensor"))
        {
            Debug.Log("Spieler hat den Fourth Level Room verlassen!");
        }
    }

    public void UpdatePlayerLevelState(PlayerLevel_State newState)
    {
        switch (newState) {
            case PlayerLevel_State.FirstLevel:
                this.State = PlayerLevel_State.FirstLevel;
                break;
            case PlayerLevel_State.SecLevel:
                this.State = PlayerLevel_State.SecLevel;
                break;
            case PlayerLevel_State.ThirdLevel:
                this.State = PlayerLevel_State.ThirdLevel;
                break;
            case PlayerLevel_State.FourhtLevel:
                this.State = PlayerLevel_State.FourhtLevel;
                break;
            case PlayerLevel_State.FifthLevel:
                this.State = PlayerLevel_State.FifthLevel;
                break;
            case PlayerLevel_State.SixthLevel:
                this.State = PlayerLevel_State.SixthLevel;
                break;
            case PlayerLevel_State.ZeroLevel:
                this.State = PlayerLevel_State.ZeroLevel;
                break;
        }
    }
}

public enum PlayerLevel_State {
    ZeroLevel,
    FirstLevel,
    SecLevel,
    ThirdLevel,
    FourhtLevel,
    FifthLevel,
    SixthLevel
}
