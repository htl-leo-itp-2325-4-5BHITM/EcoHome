using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnGrip : MonoBehaviour
{
    [SerializeField] private Audio audioScript;
    [SerializeField] private Cntrl_Listener listenerScript;

    public AudioClip clip_1; // "Use the grip button"

    bool tutorialActive = false;

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
        if (state == TutorialState.TableState)
        {
            tutorialActive = true;
            StartCoroutine(ManageGripTutorial());
        }
        else {
            tutorialActive = false;
        }
    }

    IEnumerator ManageGripTutorial()
    {
        while(tutorialActive) {
            
            if (!listenerScript._usedGripButton)
            {
                audioScript.PlayAudioAfterDelay(clip_1, 1);
                yield return new WaitForSeconds(10); 
            }
            else 
            {
                Debug.Log("State: ThrowObject");
                break;
            }
        }
        TutoManager.Instance.UpdateTutorialState(TutorialState.ThrowObject); // Proceed to the next State 
    }
}
