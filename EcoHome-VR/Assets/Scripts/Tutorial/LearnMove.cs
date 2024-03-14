using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnMove : MonoBehaviour
{
    public Audio audioScript;

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
        audioScript.PlayAudioAfterDelay(clip_1, 3.0f);
        audioScript.PlayAudioAfterDelay(clip_2, 3.0f);

        clips_length += clip_1.length + clip_2.length;
        // Wait for the audio clip to finish: delay + audio clip length
        yield return new WaitForSeconds(3.0f + clips_length);
        TutoManager.Instance.UpdateTutorialState(TutorialState.ThrowObject);
    }
}