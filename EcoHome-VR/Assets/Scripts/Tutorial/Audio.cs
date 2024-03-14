using System.Collections;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource audioPlayer;

    public void PlayAudioAfterDelay(AudioClip clip, float delay)
    {
        StartCoroutine(PlayClipWithDelay(clip, delay));
    }

    private IEnumerator PlayClipWithDelay(AudioClip clip, float delay)
    {
        yield return new WaitForSeconds(delay);
        audioPlayer.PlayOneShot(clip);
    }
}
