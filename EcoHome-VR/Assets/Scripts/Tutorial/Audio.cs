using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System;

public class Audio : MonoBehaviour
{
    public AudioSource audioPlayer;
    private Queue<AudioClip> audioQueue = new Queue<AudioClip>();
    protected Timer repeatTimer;

    // Function to add an audio clip to the queue and start playback if not already playing
    public void PlayAudioAfterDelay(AudioClip clip, float delay)
    {
        StartCoroutine(EnqueueClipAndPlay(clip, delay));
    }

    // Coroutine to delay the enqueuing of the clip, then check and play audio if needed
    private IEnumerator EnqueueClipAndPlay(AudioClip clip, float delay)
    {
        yield return new WaitForSeconds(delay);
        audioQueue.Enqueue(clip);
        if (!audioPlayer.isPlaying)
        {
            PlayNextClip();
        }
    }

    // Function to play the next clip in the queue
    private void PlayNextClip()
    {
        if (audioQueue.Count > 0 && !audioPlayer.isPlaying)
        {
            AudioClip clipToPlay = audioQueue.Dequeue();
            audioPlayer.PlayOneShot(clipToPlay);
        }
    }

    public void StartRepeatAction(Action action, int interval)
    {
        repeatTimer?.Stop();    //stopping timer if already runs

        repeatTimer = new Timer(interval);
        repeatTimer.Elapsed += (sender, e) => action();
        repeatTimer.AutoReset = true;
        repeatTimer.Start();
    }

    public void StopRepeatAction()
    {
        repeatTimer?.Stop();
    }



    // Update method to check and play the next clip if the audio player is not currently playing
    void Update()
    {
        if (!audioPlayer.isPlaying && audioQueue.Count > 0)
        {
            PlayNextClip();
        }
    }
}
