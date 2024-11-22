using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecLevel_End : MonoBehaviour
{
    // Script References
    [SerializeField] private Audio audioScript;
    [SerializeField] private Player playerScript;

    // Audio Clips
    public AudioClip clip_1;

    void OnEnable()
    {
        TutoManager.OnTutorialStateChanged += TutoManager_OnTutorialStateChanged;
    }

    void OnDisable()
    {
        TutoManager.OnTutorialStateChanged -= TutoManager_OnTutorialStateChanged;
    }

    private void TutoManager_OnTutorialStateChanged(TutorialState state)
    {
        if (state == TutorialState.SecLevel_End)
        {
            // Play the learn movement related audio clips here, for example:
            StartCoroutine(WaitForAudioAndChangeState());
        }
    }

    IEnumerator WaitForAudioAndChangeState()
    {
        audioScript.PlayAudioAfterDelay(clip_1, 1.0f);
        yield return new WaitForSeconds(2);
    }
}
