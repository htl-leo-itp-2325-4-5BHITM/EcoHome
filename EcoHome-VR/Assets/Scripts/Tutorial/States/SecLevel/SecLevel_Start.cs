using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecLevel_Start : MonoBehaviour
{

    // Script References
    [SerializeField] private Audio audioScript;
    [SerializeField] private Player playerScript;

    // Audio Clips
    public AudioClip clip_1;

    bool tutorialActive = false;
    bool toBePlayed = true;
    public static int localScoreCounter = 0;

    void Awake() 
    {
        TutoManager.OnTutorialStateChanged += TutoManager_OnTutorialStateChanged;
    }

    void OnDestroy()
    {
        TutoManager.OnTutorialStateChanged -= TutoManager_OnTutorialStateChanged;
    }


    private void TutoManager_OnTutorialStateChanged(TutorialState state)
    {
        if (state == TutorialState.SecLevel_Start)
        {
            tutorialActive = true;
            StartCoroutine(ManageSecLevelStart());
        }
        else {
            tutorialActive = false;
        }
    }

    IEnumerator ManageSecLevelStart()
    {
        while(tutorialActive) {
            audioScript.PlayAudioAfterDelay(clip_1, 1);          

            if (Player.globalScoreCounter > 4) {
                TutoManager.Instance.UpdateTutorialState(TutorialState.SecLevel_End);
                break;   
            }

            yield return new WaitForSeconds(5); 
            /*
            if (Player.globalScoreCounter <= 4) {
                if (toBePlayed)
                {
                    audioScript.PlayAudioAfterDelay(clip_1, 1);
                    toBePlayed = false;
                }
                yield return new WaitForSeconds(5); 
            }
            else {      
                Debug.Log("State: SecLevel_End");
                TutoManager.Instance.UpdateTutorialState(TutorialState.SecLevel_End);
                break;          
            }
            */
        } 
    }
}
