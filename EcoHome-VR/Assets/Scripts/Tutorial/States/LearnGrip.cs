using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnGrip : MonoBehaviour
{
    [SerializeField] private Audio audioScript;
    [SerializeField] private Cntrl_Listener listenerScript;

    public AudioClip clip_1; // "Use the grip button"
    public AudioClip clip_2; // "Use the grip button" - short version

    bool gripInstructionGiven = false;

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
        if (state == TutorialState.TableState)
        {
            StartCoroutine(ManageGripTutorial());
        }
    }

    IEnumerator ManageGripTutorial()
    {
        if (!listenerScript.rightGripButtonUsed ||  !listenerScript.leftGripButtonUsed && !gripInstructionGiven)
        {
            audioScript.PlayAudioAfterDelay(clip_1, 1); // Play for the first time
            gripInstructionGiven = true;
            yield return new WaitForSeconds(5); // Wait for 5 seconds before checking again to repeat the instruction clip
        }
        else if (listenerScript.leftGripButtonUsed || listenerScript.rightGripButtonUsed)
        {
            Debug.Log("change the state");
            TutoManager.Instance.UpdateTutorialState(TutorialState.ThrowObject); // Proceed to the next State
        }
        else if (gripInstructionGiven)
        {
            //audioScript.PlayAudioAfterDelay(clip_1, 1);
            audioScript.StartRepeatAction(() => audioScript.PlayAudioAfterDelay(clip_1, 1), 10000);
        }
    }
}
