using System.Collections;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    [SerializeField] private Audio audioScript;
    [SerializeField] private Cntrl_Listener listenerScript;

    public AudioClip throwInstructionClip; // Instruction to throw an object

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
        bool instructionGiven = false;
        float startTime = Time.time;

        while (Time.time - startTime < 30) // 30-second timeout for the throw tutorial phase
        {
            if (!listenerScript.leftGripButtonUsed && !instructionGiven)
            {
                // Play throw instruction immediately for the first time, then repeat every 15 seconds
                audioScript.PlayAudioAfterDelay(throwInstructionClip, 0);
                instructionGiven = true;
                yield return new WaitForSeconds(15); // Wait for 15 seconds before checking again
            }

            // Check if the throwing action has been performed
            if (listenerScript.leftGripButtonUsed)
            {
                break; // Exit loop if throwing action is detected
            }

            // Allow repeating the instruction if the action hasn't been performed within 15 seconds
            instructionGiven = false;
        }

        // Log if the throw action was not detected within the timeout
        if (!listenerScript.leftGripButtonUsed)
        {
            Debug.LogWarning("Throw action not detected within timeout. Proceeding to next tutorial phase.");
        }

        // Proceed to the next phase regardless of throw action to prevent stalling
        TutoManager.Instance.UpdateTutorialState(TutorialState.EndOfGame); // Assuming EndOfGame is the next state
    }
}
