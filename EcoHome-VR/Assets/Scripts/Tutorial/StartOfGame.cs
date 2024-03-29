using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOfGame : MonoBehaviour
{

    [SerializeField] private Audio audioScript;

    //Audio Clips
    public AudioClip clip_1;
    public AudioClip clip_2;

    // clips length
    public float clips_length;

    void Awake() {
        TutoManager.OnTutorialStateChanged += TutoManager_OnTutorialStateChanged;
    }

    void OnDestroy()
    {
        TutoManager.OnTutorialStateChanged -= TutoManager_OnTutorialStateChanged;
    }

    private void TutoManager_OnTutorialStateChanged(TutorialState state)
    {
        if (state == TutorialState.StartOfGame) {
            StartCoroutine(WaitForAudioAndChangeState());
        }
    }

    IEnumerator WaitForAudioAndChangeState()
    {
        audioScript.PlayAudioAfterDelay(clip_1, 3.0f);
        Debug.Log("Playing StartOfGame AudioClip");

        //clips_length += clip_1.length + clip_2.length;
        // Wait for the audio clip to finish: delay + audio clip length
        yield return new WaitForSeconds(clip_1.length);
        TutoManager.Instance.UpdateTutorialState(TutorialState.LearnMovement);
    }
}
