using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    // Script References
    public Audio audioScript;
    public Cntrl_Listener listenerScript;

    // Audio Clips
    public AudioClip clip_1;
    public AudioClip clip_2;


    private void Awake()
    {
        TutoManager.OnTutorialStateChanged += TutoManager_OnTutorialStateChanged;
    }

    private void TutoManager_OnTutorialStateChanged(TutorialState state)
    {
        if (state == TutorialState.ThrowObject)
        {
            // Play the learn movement related audio clips here, for example:
            StartCoroutine(WaitForAudioAndChangeState());
        }
    }


    IEnumerator WaitForAudioAndChangeState()
    {
        audioScript.PlayAudioAfterDelay(clip_1, 2.0f);
        yield return new WaitForSeconds(clip_1.length + 3.0f);

        // Warte, bis der Grip-Button gedrückt wird
        yield return new WaitUntil(() => listenerScript.leftGripButtonUsed);
        audioScript.PlayAudioAfterDelay(clip_2, 2.0f);

        // Warte, bis der Grip-Button losgelassen wird
        yield return new WaitUntil(() => !listenerScript.leftGripButtonUsed);
        audioScript.PlayAudioAfterDelay(clip_1, 2.0f);

        TutoManager.Instance.UpdateTutorialState(TutorialState.EndOfGame);
    }
}
