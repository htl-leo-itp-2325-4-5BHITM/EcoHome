using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfGame : MonoBehaviour
{
    // Script References
    [SerializeField] private Audio audioScript;
    [SerializeField] private Player playerScript;

    // Audio Clips
    public AudioClip clip_1;

    private void Awake()
    {
        TutoManager.OnTutorialStateChanged += TutoManager_OnTutorialStateChanged;
    }

    private void TutoManager_OnTutorialStateChanged(TutorialState state)
    {
        if (state == TutorialState.EndOfGame)
        {
            // Play the learn movement related audio clips here, for example:
            StartCoroutine(WaitForAudioAndChangeState());
        }
    }

    IEnumerator WaitForAudioAndChangeState()
    {
        yield return new WaitUntil(() => Player.globalScoreCounter > 0);

        audioScript.PlayAudioAfterDelay(clip_1, 2.0f);
    }
}
