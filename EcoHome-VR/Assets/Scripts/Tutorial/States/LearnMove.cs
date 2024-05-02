using System.Collections;
using UnityEngine;

public class LearnMove : MonoBehaviour
{
    [SerializeField] private Audio audioScript;
    [SerializeField] private Cntrl_Listener listenerScript;

    public AudioClip clip_1; // "Use the left stick"
    public AudioClip clip_2; // "Use the left stick" - short version

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
        if (!listenerScript.leftStickUsed)
        {
            audioScript.PlayAudioAfterDelay(clip_1, 1); // Play for the first time
            yield return new WaitForSeconds(5); 
            audioScript.StartRepeatAction(() => audioScript.PlayAudioAfterDelay(clip_1, 1), 10000);
        }
        else if (listenerScript.leftStickUsed)
        {
            Debug.Log("change the state");
            TutoManager.Instance.UpdateTutorialState(TutorialState.LearnRotation); // Proceed to the next State
        }
    }
}
