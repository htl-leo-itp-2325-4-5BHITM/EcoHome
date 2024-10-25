using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLevel_StartOfGame : MonoBehaviour
{

    [SerializeField] private Audio audioScript;

    //Audio Clips
    public AudioClip clip_1;
    public AudioClip clip_2;


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

        yield return new WaitForSeconds(1.0f); 
        audioScript.PlayAudioAfterDelay(clip_1, 0); 
        yield return new WaitForSeconds(clip_1.length);

        yield return new WaitForSeconds(1.0f); 
        audioScript.PlayAudioAfterDelay(clip_2, 0); 
        yield return new WaitForSeconds(clip_2.length);

        Debug.Log("State: LearnMovement");
        TutoManager.Instance.UpdateTutorialState(TutorialState.LearnMovement);
    }
}
