using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Third_Level_LightOff : MonoBehaviour
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
        if (state == TutorialState.Third_Level_LightOff)
        {
            tutorialActive = true;
            StartCoroutine(ManageThirdLevelLightOff());
        }
        else {
            tutorialActive = false;
        }
    }

    IEnumerator ManageThirdLevelLightOff()
    {
        while (tutorialActive) {
            audioScript.PlayAudioAfterDelay(clip_1, 1);

            

            yield return new WaitForSeconds(10); 
        }
        /*
        audioScript.PlayAudioAfterDelay(clip_1, 1);
        TutoManager.Instance.UpdateTutorialState(TutorialState.Third_Level_End);
        yield return new WaitForSeconds(15);
        
        while(tutorialActive) {
            if (Player.globalScoreCounter < 18) {
                Debug.Log("entered");       // ENTERS BUT DOESNT WORK!!!
                audioScript.PlayAudioAfterDelay(clip_1, 1);
                yield return new WaitForSeconds(10); 
            }
            else {      
                Debug.Log("State: Third_Level_End");
                TutoManager.Instance.UpdateTutorialState(TutorialState.Third_Level_End);
                break;          
            }
        } 
        */
        
    }
}
