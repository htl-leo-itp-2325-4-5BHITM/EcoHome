using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using TMPro;


[RequireComponent(typeof(InputData))]
public class TutoManager : MonoBehaviour
{
    public static TutoManager Instance;

    public TutorialState State;

    public static event Action<TutorialState> OnTutorialStateChanged;

    // Play State
    bool isLearnMovement;

    void Awake()
    {
        Instance = this;
    }

    // Tutorial Dialog Clips
    public AudioSource audioPlayer;

    public AudioClip _clip1;
    public AudioClip _clip2;
    public AudioClip _clip3;
    public AudioClip _clip4;
    public AudioClip _clip5;
    public AudioClip _clip6;
    public AudioClip _clip7;
    public AudioClip _clip8;

    // Input Data from right/left Controller
    private InputData _inputData;

    bool playTutorial = true;
    bool endTutorial = false;

    bool usedRightController = false;
    bool usedLeftController = false;
    bool usedHead = true;

    // Start is called before the first frame update
    void Start()
    {
        _inputData = GetComponent<InputData>();
        UpdateGameState(TutorialState.StartOfGame);
    }

    // Update is called once per frame
    void Update()
    {
        // If-Anweisung muss zu einem "OnLoad" Abfrage umgeschrieben werden
        if (playTutorial) {
            UpdateGameState(TutorialState.StartOfGame);
            this.playTutorial = false;
        }

        if (_inputData._leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out Vector2 leftThumbStick))
        {
            Debug.Log("getting left_thumbStick movement: " + leftThumbStick);
            //check the distance of the movement and set the variable to true
            this.usedLeftController = true;
        }

        if (_inputData._rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out Vector2 rightThumbStick))
        {
            Debug.Log("getting right_thumbStick movement: " + rightThumbStick);
            //check the distance of the movement and set the variable to true
            this.usedRightController = true;
        }
    }

    public void UpdateGameState(TutorialState newState)
    {
        switch (newState) {
            case TutorialState.StartOfGame:
                playStart();
                break;
            case TutorialState.LearnMovement:
                playLearnMovement(this.usedLeftController, this.usedRightController, this.usedHead);
                break;
            case TutorialState.LearnPickUp:
                break;
            case TutorialState.ThrowObject:
                break;
            case TutorialState.EndOfGame:
                break;
            default:
                throw new System.Exception();
        }

        OnTutorialStateChanged?.Invoke(newState);
    }

    private void playStart() {
        StartCoroutine(playClipWithDelay(_clip1, 7));
        UpdateGameState(TutorialState.LearnMovement);
    }

    private void playLearnMovement(bool isLeftUsed, bool isRightUsed, bool isHeadUsed) {
        if (isLeftUsed && isRightUsed && isHeadUsed)
        {
            UpdateGameState(TutorialState.LearnPickUp);
        }
        else {
            StartCoroutine(playClipWithDelay(_clip2, 2));

            if (isHeadUsed)
            {
                if (isLeftUsed)
                {
                    StartCoroutine(playClipWithDelay(_clip3, 2));

                    if (isRightUsed)
                    {
                        StartCoroutine(playClipWithDelay(_clip4, 2));
                        UpdateGameState(TutorialState.LearnPickUp);
                    }
                }
            }
        }     
    }

    private void playLearnPickUp() {

    }

    IEnumerator playClipWithDelay(AudioClip clip, float delay)
    {
        yield return new WaitForSeconds(delay);
        if (!endTutorial || clip == _clip8)
        {
            audioPlayer.Stop();
            audioPlayer.PlayOneShot(clip);
        }
    }
}

public enum TutorialState {
    StartOfGame,
    LearnMovement,
    LearnPickUp,
    ThrowObject,
    EndOfGame
}