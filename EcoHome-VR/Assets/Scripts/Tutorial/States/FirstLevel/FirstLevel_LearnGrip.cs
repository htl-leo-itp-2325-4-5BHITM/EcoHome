using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevel_LearnGrip : MonoBehaviour
{
    [SerializeField] private Audio audioScript;

    public AudioClip clip_1; // "Use the grip button"
    public AudioClip clip_2; // "Throw that shit"

    bool tutorialActive = false;
    bool holdingFirstRoomPaper = false;
    bool destroyedFirstRoomPaper = false;

    void OnEnable()
    {
        TutoManager.OnTutorialStateChanged += TutoManager_OnTutorialStateChanged;
        Object_Listener.OnFirstRoomPaperIsBeingHeld_Changed += HandleFirstRoomPaperBeingHeld;
        Object_Listener.OnFirstRoomPaperIsDestroyed += HandleFirstRoomPaperIsDestroyed;
    }

    void OnDisable()
    {
        TutoManager.OnTutorialStateChanged -= TutoManager_OnTutorialStateChanged;
        Object_Listener.OnFirstRoomPaperIsBeingHeld_Changed -= HandleFirstRoomPaperBeingHeld;
        Object_Listener.OnFirstRoomPaperIsDestroyed -= HandleFirstRoomPaperIsDestroyed;
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

    private void HandleFirstRoomPaperBeingHeld(bool isHolding)
    {
        if (isHolding) {
            this.holdingFirstRoomPaper = true;
        }
        else {
            this.holdingFirstRoomPaper = false;
        }
    }

    private void HandleFirstRoomPaperIsDestroyed(bool isDestroyed) 
    {
        if (isDestroyed) {
            this.destroyedFirstRoomPaper = true;
        }
        else {
            this.destroyedFirstRoomPaper = false;
        }
    }

    //TODO: Combine FirstLevel_ThrowObject.cs and FirstLevel_LearnGrip.cs in on file
    //the reason is that the player basically uses the grip/trigger btn for both of the states/scripts

    //info: code below needs testing
    IEnumerator ManageGripTutorial()
    {
        while(tutorialActive) {
            Debug.Log("v_holdingFirstRoomPaper: " + this.holdingFirstRoomPaper);
            Debug.Log("v_destroyedFirstRoomPaper: " + this.destroyedFirstRoomPaper);
            if (!this.holdingFirstRoomPaper && !this.destroyedFirstRoomPaper) {
                audioScript.PlayAudioAfterDelay(clip_1, 1);
                yield return new WaitForSeconds(10);
            }
            else {
                //check if the trash paper is destroyed
                if (!this.destroyedFirstRoomPaper) {
                    audioScript.PlayAudioAfterDelay(clip_2, 2);
                    yield return new WaitForSeconds(12);
                }
                else {
                    TutoManager.Instance.UpdateTutorialState(TutorialState.EndOfGame);
                    break;
                }
            }
        }
        
    }
}
