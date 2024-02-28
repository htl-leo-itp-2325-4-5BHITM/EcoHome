using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


[RequireComponent(typeof(InputData))]
public class TutorScript : MonoBehaviour
{
    public AudioClip _clip1;
    public AudioClip _clip2;
    public AudioClip _clip3;
    public AudioClip _clip4;
    public AudioClip _clip5;
    public AudioClip _clip6;
    public AudioClip _clip7;
    public AudioClip _clip8;

    public AudioSource audioPlayer; 
    
    bool playTutorial = true; 
    bool endTutorial = false;

    private InputData _inputData;

    // Start is called before the first frame update
    void Start()
    {
       //audioPlayer.PlayOneShot(_clip1);

       /* 
        _inputData = GetComponent<InputData>();
        GetComponent<AudioSource>().PlayOneShot(_clip1);
        GetComponent<AudioSource>().PlayOneShot(_clip2);
        */
    }

    // Update is called once per frame
    void Update()
    {
        
        if (playTutorial) {
            this.playTutorial = false;
            StartCoroutine(playClipWithDelay(_clip1, 7));
            StartCoroutine(playClipWithDelay(_clip2, 15));
            StartCoroutine(playClipWithDelay(_clip3, 19));
            StartCoroutine(playClipWithDelay(_clip4, 23));
            StartCoroutine(playClipWithDelay(_clip5, 27));
            StartCoroutine(playClipWithDelay(_clip6, 31));
            StartCoroutine(playClipWithDelay(_clip7, 42));
        }

        if (Player.globalScoreCounter == 1 && !endTutorial) {
            endTutorial = true;
            StartCoroutine(playClipWithDelay(_clip8, 1));
        }

        
        //if (_inputData._leftController.TryGetFeatureValue(CommonUsages.XR))
        /*
        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPressed))
        {
            GetComponent<AudioSource>().PlayOneShot(_clip1);
        }
        */
    }

    IEnumerator playClipWithDelay(AudioClip clip, float delay) {
        yield return new WaitForSeconds(delay);
        if(!endTutorial || clip == _clip8) {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clip);
        }
    }
}