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

            yield return new WaitForSeconds(60); 
        } 
    }
}
