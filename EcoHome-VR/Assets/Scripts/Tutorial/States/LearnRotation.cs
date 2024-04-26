using System.Collections;
using UnityEngine;

public class LearnRotation : MonoBehaviour
{
    [SerializeField] private Audio audioScript;
    [SerializeField] private Cntrl_Listener listenerScript;

    public AudioClip clip_1; // "Use the right stick"
    public AudioClip clip_2; // "Use the right stick" - short version

    bool rightStickInstructionGiven = false;

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
        if (state == TutorialState.LearnRotation)
        {
            StartCoroutine(ManageRotationTutorial());
        }
    }

    IEnumerator ManageRotationTutorial()
    {
        if (!listenerScript.righStickUsed && !rightStickInstructionGiven)
        {
            audioScript.PlayAudioAfterDelay(clip_1, 1); // Play for the first time
            rightStickInstructionGiven = true;
            yield return new WaitForSeconds(5); // Wait for 5 seconds before checking again to repeat the instruction clip
        }
        else if (listenerScript.righStickUsed)
        {
            Debug.Log("change the state");
            TutoManager.Instance.UpdateTutorialState(TutorialState.TableState); // Proceed to the next State
        }
        else if (rightStickInstructionGiven)
        {
            //audioScript.PlayAudioAfterDelay(clip_1, 1);
            audioScript.StartRepeatAction(() => audioScript.PlayAudioAfterDelay(clip_1, 1), 10000);
        }
    }
}
