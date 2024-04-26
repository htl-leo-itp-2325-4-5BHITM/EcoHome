using System.Collections;
using UnityEngine;

public class LearnMove : MonoBehaviour
{
    [SerializeField] private Audio audioScript;
    [SerializeField] private Cntrl_Listener listenerScript;

    public AudioClip clip_1; // "Use the left stick"
    public AudioClip clip_2; // "Use the left stick" - short version

    bool leftStickInstructionGiven = false;

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
        if (!listenerScript.leftStickUsed && !leftStickInstructionGiven)
        {
            audioScript.PlayAudioAfterDelay(clip_1, 1); // Play for the first time
            leftStickInstructionGiven = true;
            yield return new WaitForSeconds(5); // Wait for 5 seconds before checking again to repeat the instruction clip
        }
        else if (listenerScript.leftStickUsed)
        {
            Debug.Log("change the state");
            TutoManager.Instance.UpdateTutorialState(TutorialState.LearnRotation); // Proceed to the next State
        }
        else if (leftStickInstructionGiven)
        {
            //audioScript.PlayAudioAfterDelay(clip_1, 1);
            audioScript.StartRepeatAction(() => audioScript.PlayAudioAfterDelay(clip_1, 1), 10000);
        }
    }
}
