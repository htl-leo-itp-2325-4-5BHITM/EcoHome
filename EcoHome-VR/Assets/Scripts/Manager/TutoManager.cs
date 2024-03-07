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

    bool endTutorial = false;

    private bool usedRightStickController = false;
    private bool usedLeftStickController = false;

    //bool playRight = false;

    TutorialState official_State;


    // Start is called before the first frame update
    void Start()
    {
        _inputData = GetComponent<InputData>();
        UpdateGameState(TutorialState.StartOfGame);
    }

    // Update is called once per frame
    void Update()
    {
        if (official_State == TutorialState.LearnMovement) {
            if (_inputData._leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out Vector2 leftThumbStick))
            {
                if (leftThumbStick.y >= 0.80 || leftThumbStick.y <= -0.80) {
                    this.usedLeftStickController = true;
                    leftUsed(this.usedLeftStickController);
                }
            }

            if (_inputData._rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out Vector2 rightThumbStick))
            {
                if (rightThumbStick.x >= 0.80 || rightThumbStick.x <= -0.80) {
                    this.usedRightStickController = true;
                    rightUsed(this.usedRightStickController);
                }
                    
            }
        }

        if (Player.globalScoreCounter == 1) {
            UpdateGameState(TutorialState.EndOfGame);
        } 
    }

    public void UpdateGameState(TutorialState newState)
    {
        switch (newState) {
            case TutorialState.StartOfGame:
                this.official_State = TutorialState.StartOfGame;
                break;
            case TutorialState.LearnMovement:
                this.official_State = TutorialState.LearnMovement;
                break;
            case TutorialState.LearnPickUp:
                this.official_State = TutorialState.LearnPickUp;
                break;
            case TutorialState.ThrowObject:
                this.official_State = TutorialState.ThrowObject;
                break;
            case TutorialState.EndOfGame:
                this.official_State = TutorialState.EndOfGame;
                break;
            default:
                throw new System.Exception();
        }

        OnTutorialStateChanged?.Invoke(newState);
    }

    private void playStart() {
        StartCoroutine(playClipWithDelayAndThenUpdateGameState(new AudioClip[]{_clip1, _clip2, _clip3}, new float[]{5, 7, 5}));
    }

    private void playLearnMovement() {   
        Debug.Log("playLearnMovement");
    }
    private void leftUsed(bool isLeftUsed) {
        Debug.Log("left Stick: " + isLeftUsed);
    }
    private void rightUsed(bool isRightUsed) {
        Debug.Log("right Stick: " + isRightUsed);
    }

    private void playLearnPickUp() {
        Debug.Log("playLearnPickUp Func");
    }

    private void playEndOfGame() {
        Debug.Log("playEndOfGame Func");
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
    private IEnumerator playClipWithDelayAndThenUpdateGameState(AudioClip[] clips, float[] delays) {
        for (int i = 0; i < clips.Length; i++) {
            yield return StartCoroutine(playClipWithDelay(clips[i], delays[i]));
        }

        Invoke("DelayedGameStateUpdate_LearnMovement", 3.0f);
    }

    void DelayedGameStateUpdate_LearnMovement() {
        UpdateGameState(TutorialState.LearnMovement);
    }
}

public enum TutorialState {
    StartOfGame,
    LearnMovement,
    LearnPickUp,
    ThrowObject,
    EndOfGame
}