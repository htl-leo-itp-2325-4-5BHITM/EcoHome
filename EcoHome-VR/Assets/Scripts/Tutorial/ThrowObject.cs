using System.Collections;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    [SerializeField] private Audio audioScript;
    [SerializeField] private Cntrl_Listener listenerScript;

    public AudioClip clip_1; 

    bool instructionGiven = false;

    bool doneThrowing = false;

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
        if (state == TutorialState.ThrowObject)
        {
            StartCoroutine(ManageThrowTutorial());
        }
    }

    IEnumerator ManageThrowTutorial()
    {

        while (!doneThrowing) 
        {
            if (!listenerScript.leftGripButtonUsed && !instructionGiven || !listenerScript.rightGripButtonUsed && !instructionGiven)
            {
                // Play throw instruction immediately for the first time, then repeat every 10 seconds
                audioScript.PlayAudioAfterDelay(clip_1, 2);
                instructionGiven = true;
                yield return new WaitForSeconds(10); // Wait for 10 seconds before checking again
            }

            // Check if the throwing action has been performed
            
            if (listenerScript.leftGripButtonUsed || listenerScript.rightGripButtonUsed)
            {
                break; // Exit loop if throwing action is detected
            }

            // Allow repeating the instruction if the action hasn't been performed within 10 seconds
            instructionGiven = false;
        }

        if (listenerScript.rightGripButtonUsed || listenerScript.leftGripButtonUsed) {
            TutoManager.Instance.UpdateTutorialState(TutorialState.EndOfGame); // Proceed to the next phase
        }

    }
}
