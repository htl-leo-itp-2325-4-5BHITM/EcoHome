using System.Collections;
using UnityEngine;

public class LearnRotation : MonoBehaviour
{
    [SerializeField] private Audio audioScript;
    [SerializeField] private Cntrl_Listener listenerScript;

    public AudioClip clip_1; // "Use the right stick"
    public AudioClip clip_2; // "Use the right stick" - short version


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
        if (!listenerScript.righStickUsed)
        {
            audioScript.PlayAudioAfterDelay(clip_1, 1);
            yield return new WaitForSeconds(5); 
            audioScript.StartRepeatAction(() => audioScript.PlayAudioAfterDelay(clip_1, 1), 10000);
        }
        else if (listenerScript.righStickUsed)
        {
            Debug.Log("change the state");
            TutoManager.Instance.UpdateTutorialState(TutorialState.TableState); // Proceed to the next State
        }
    }
}
