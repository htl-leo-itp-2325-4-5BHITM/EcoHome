using System.Collections;
using UnityEngine;

public class FirstLevel_LearnMove : MonoBehaviour
{
    [SerializeField] private Audio audioScript;
    [SerializeField] private Cntrl_Listener listenerScript;

    public AudioClip clip_1; // "Use the left stick"

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
        if (state == TutorialState.LearnMovement)
        {
            tutorialActive = true;
            StartCoroutine(ManageMovementTutorial());
        }
        else
        {
            tutorialActive = false;
        }
    }

    IEnumerator ManageMovementTutorial()
    {
        while (tutorialActive)
        {
            if (!listenerScript._leftStickUsed)
            {
                audioScript.PlayAudioAfterDelay(clip_1, 1); // Play audio
                yield return new WaitForSeconds(10); // Adjust this timing as needed
            }
            else
            {
                Debug.Log("State: LearnRotation");
                break; // Exit loop if the correct action is performed     
            }
        }
        TutoManager.Instance.UpdateTutorialState(TutorialState.LearnRotation);
    }
}