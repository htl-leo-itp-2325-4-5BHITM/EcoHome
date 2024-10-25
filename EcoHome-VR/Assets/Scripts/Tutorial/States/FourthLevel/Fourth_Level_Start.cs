using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fourth_Level_Start : MonoBehaviour
{
// Script References
    [SerializeField] private Audio audioScript;
    [SerializeField] private Player playerScript;

    // Audio Clips
    public AudioClip clip_1;

    bool tutorialActive = false;
    bool toBePlayed = true;
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
        if (state == TutorialState.Fourth_Level_Start)
        {
            tutorialActive = true;
            StartCoroutine(ManageFourthLevelStart());
        }
        else {
            tutorialActive = false;
        }
    }

    IEnumerator ManageFourthLevelStart()
    {
    while(tutorialActive) {
            if (Player.globalScoreCounter < 18) {
                if (toBePlayed)
                {
                    audioScript.PlayAudioAfterDelay(clip_1, 1);
                    toBePlayed = false;
                }
                
                yield return new WaitForSeconds(5); 
            }
            else {      
                Debug.Log("State: End Of Tutorial");
                TutoManager.Instance.UpdateTutorialState(TutorialState.End_Of_Tutorial);
                break;          
            }
        } 
    }
}
