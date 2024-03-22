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
        audioScript.audioPlayer.clip = clip_1;
        audioScript.audioPlayer.Play();
        yield return new WaitForSeconds(audioScript.audioPlayer.clip.length);

        // Hier können Sie Logik hinzufügen, um auf eine bestimmte Aktion oder ein Ereignis zu warten
        // Beispiel: Warten, bis der Spieler eine Aktion durchführt
        yield return new WaitUntil(() => listenerScript.leftGripButtonUsed);

        // Spielt den zweiten Clip und wartet, bis er beendet ist
        // Stellen Sie sicher, dass Clip 2 nur abgespielt wird, wenn Clip 1 nicht läuft.
        if (!audioScript.audioPlayer.isPlaying)
        {
            audioScript.audioPlayer.clip = clip_2;
            audioScript.audioPlayer.Play();
            yield return new WaitForSeconds(audioScript.audioPlayer.clip.length);
        }

        if (Player.globalScoreCounter > 0) {
            TutoManager.Instance.UpdateTutorialState(TutorialState.EndOfGame);
        }

        /*
        audioScript.PlayAudioAfterDelay(clip_1, 2.0f);
        yield return new WaitForSeconds(clip_1.length + 3.0f);

        // Warte, bis der Grip-Button gedrückt wird
        yield return new WaitUntil(() => listenerScript.leftGripButtonUsed);
        audioScript.PlayAudioAfterDelay(clip_2, 2.0f);

        // Warte, bis der Grip-Button losgelassen wird
        yield return new WaitUntil(() => !listenerScript.leftGripButtonUsed);
        audioScript.PlayAudioAfterDelay(clip_1, 2.0f);

        */
    }
}
