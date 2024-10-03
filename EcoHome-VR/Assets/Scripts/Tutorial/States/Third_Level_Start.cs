using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third_Level_Start : MonoBehaviour
{
// Script References
    [SerializeField] private Audio audioScript;
    [SerializeField] private Player playerScript;

    // Audio Clips
    public AudioClip clip_1;

    bool tutorialActive = false;
    public static int localScoreCounter = 0;

    void OnEnable()
    {
        TutoManager.OnTutorialStateChanged += TutoManager_OnTutorialStateChanged;
    }

    void OnDisable()
    {
        TutoManager.OnTutorialStateChanged -= TutoManager_OnTutorialStateChanged;
    }
    

    private void TutoManager_OnTutorialStateChanged(TutorialState state)
    {
        if (state == TutorialState.Third_Level_Start)
        {
            tutorialActive = true;
            StartCoroutine(ManageThirdLevelStart());
        }
        else {
            tutorialActive = false;
        }
    }

    IEnumerator ManageThirdLevelStart()
    {
        audioScript.PlayAudioAfterDelay(clip_1, 1);
        Debug.Log("State: Third Level LightOff");
        TutoManager.Instance.UpdateTutorialState(TutorialState.Third_Level_LightOff);
        yield return new WaitForSeconds(7);
        /*
        while(tutorialActive) {
            if (localScoreCounter <= 4) {
                audioScript.PlayAudioAfterDelay(clip_1, 1);
                yield return new WaitForSeconds(30); 
            }
            else {      
                Debug.Log("State: SecLevel_End");
                TutoManager.Instance.UpdateTutorialState(TutorialState.SecLevel_End);
                break;          
            }
        } 
        */
    }
}
