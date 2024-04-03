using System.Collections;
using UnityEngine;

public class LearnMove : MonoBehaviour
{
    [SerializeField] private Audio audioScript;
    [SerializeField] private Cntrl_Listener listenerScript;

    public AudioClip clip_1; // "Use the left stick"
    public AudioClip clip_2; // "Use the right stick"

    bool leftStickInstructionGiven = false;
    bool rightStickInstructionGiven = false;
    bool doneMovement = false;

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
        if (state == TutorialState.LearnMovement)
        {
            StartCoroutine(ManageMovementTutorial());
        }
    }

    IEnumerator ManageMovementTutorial()
    {
        while (!doneMovement)
        {
            if (!listenerScript.leftStickUsed && !leftStickInstructionGiven)
            {
                audioScript.PlayAudioAfterDelay(clip_1, 1); // Play immediately for the first time
                leftStickInstructionGiven = true;
                yield return new WaitForSeconds(10); // Wait for 10 seconds before checking again or moving on to the right stick instruction
            }
            else if (listenerScript.leftStickUsed && !listenerScript.righStickUsed && !rightStickInstructionGiven)
            {
                audioScript.PlayAudioAfterDelay(clip_2, 1); // Play immediately for the first time
                rightStickInstructionGiven = true;
                yield return new WaitForSeconds(10); // Wait for 10 seconds before rechecking right stick usage
            }
            else if (listenerScript.leftStickUsed && listenerScript.righStickUsed)
            {
                break; // Both actions performed, exit the loop
            }

            // Repeating instructions if actions not detected within 10 seconds
            if (!listenerScript.leftStickUsed)
            {
                leftStickInstructionGiven = false; // Allow repeating the left stick instruction
            }
            if (listenerScript.leftStickUsed && !listenerScript.righStickUsed)
            {
                rightStickInstructionGiven = false; // Allow repeating the right stick instruction
            }
        }


        if (listenerScript.leftStickUsed && listenerScript.righStickUsed)
        {
            Debug.Log("changed state to throwobj");
            TutoManager.Instance.UpdateTutorialState(TutorialState.ThrowObject); // Proceed to the next phase
        }
        
    }
}
