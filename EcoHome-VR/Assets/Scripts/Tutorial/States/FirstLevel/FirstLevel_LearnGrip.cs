using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevel_LearnGrip : MonoBehaviour
{
    [SerializeField] private Audio audioScript;
    //[SerializeField] private Cntrl_Listener listenerScript;

    public AudioClip clip_1; // "Use the grip button"

    bool tutorialActive = false;
    bool _grabPaper = false;
    bool usedRightGrip = false;
    bool usedLeftGrip = false;

    void OnEnable()
    {
        TutoManager.OnTutorialStateChanged += TutoManager_OnTutorialStateChanged;
        Cntrl_Listener.OnGrabPaperChanged += HandleGrabPaperChange;
        //listenerScript.OnUsedRightGrip += HandleUsedRightGrip;
        //listenerScript.OnUsedLeftGrip += HandleUsedLeftGrip;
    }

    void OnDisable()
    {
        TutoManager.OnTutorialStateChanged -= TutoManager_OnTutorialStateChanged;
        Cntrl_Listener.OnGrabPaperChanged -= HandleGrabPaperChange;
        //listenerScript.OnUsedRightGrip -= HandleUsedRightGrip;
        //listenerScript.OnUsedLeftGrip -= HandleUsedLeftGrip;
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

    private void HandleGrabPaperChange(bool isGrabbed) {
        if (isGrabbed) {
            this._grabPaper = true;
            Debug.Log("Paper grabbed!");
        }
        else {
            this._grabPaper = false;
            Debug.Log("Paper released!");
        }
    } 

    private void HandleUsedRightGrip(bool isUsed) {
        if(isUsed) {
            usedRightGrip = isUsed;
        }
        else {
            usedRightGrip = false;
        }
        Debug.Log("Subscribe usedRightGrip = " + usedRightGrip);
    }

    private void HandleUsedLeftGrip(bool isUsed) {
        if (isUsed) {
            usedLeftGrip = isUsed;
        }
        else {
            usedLeftGrip = false;
        }
        Debug.Log("Subscribe usedLeftGrip = " + usedLeftGrip);
    }

    IEnumerator ManageGripTutorial()
    {
        while(tutorialActive) {
            
            if (!_grabPaper)
            {
                audioScript.PlayAudioAfterDelay(clip_1, 1);
                yield return new WaitForSeconds(10); 
            }
            else 
            {
                Debug.Log("State: ThrowObject");
                TutoManager.Instance.UpdateTutorialState(TutorialState.ThrowObject); // Proceed to the next State 
            }
        }
        
    }
}
