using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End_Of_Tutorial : MonoBehaviour
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
        if (state == TutorialState.End_Of_Tutorial)
        {
            // Play the learn movement related audio clips here, for example:
            audioScript.PlayAudioAfterDelay(clip_1, 1.0f);
        }
    }

}
