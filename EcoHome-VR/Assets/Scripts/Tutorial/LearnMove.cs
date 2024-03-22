using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnMove : MonoBehaviour
{
    // Script References
    public Audio audioScript;
    public Cntrl_Listener listenerScript;

    // Audio Clips
    public AudioClip clip_1;
    public AudioClip clip_2;

    // clips length
    public float clips_length;

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
            // Play the learn movement related audio clips here, for example:
            StartCoroutine(WaitForAudioAndChangeState());
        }
    }

    IEnumerator WaitForAudioAndChangeState()
    {
        audioScript.PlayAudioAfterDelay(clip_1, 2.0f);

        yield return new WaitForSeconds(clip_1.length);

        while (!listenerScript.leftStickUsed) {
            yield return null;
        }

        audioScript.PlayAudioAfterDelay(clip_2, 3.0f);

        while (!listenerScript.righStickUsed) {
            yield return null;
        }

        TutoManager.Instance.UpdateTutorialState(TutorialState.ThrowObject);
    }
}