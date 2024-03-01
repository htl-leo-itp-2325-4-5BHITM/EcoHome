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

    // Start is called before the first frame update
    void Start()
    {
        _inputData = GetComponent<InputData>();
        UpdateGameState(TutorialState.StartOfGame);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (_inputData._leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.deviceVelocity, out Vector3 leftVelocity))
        {
            Debug.Log("getting velocity data from Controller");
            Debug.Log("Velocity Value: " + leftVelocity);
        }*/
        
        if (_inputData._leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out Vector2 leftThumbStick))
        {
            Debug.Log("getting thumbStick movement: " + leftThumbStick);
        }
    }

    public void UpdateGameState(TutorialState newState)
    {
        State = newState;

        switch (newState) {
            case TutorialState.StartOfGame:
                playStart();
                break;
            case TutorialState.LearnMovement:
                this.isLearnMovement = false;
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
        audioPlayer.PlayOneShot(_clip1);
        UpdateGameState(TutorialState.LearnMovement);
    }

    private void playLearnMovement(bool isLearnMovement) {
        audioPlayer.PlayOneShot(_clip3);
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