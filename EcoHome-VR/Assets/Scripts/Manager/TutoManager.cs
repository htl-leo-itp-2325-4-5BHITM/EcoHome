using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


[RequireComponent(typeof(InputData))]
public class TutoManager : MonoBehaviour
{
    /*
    public static TutoManager Instance;

    public TutorialState State;

    public static event Action<TutorialState> OnTutorialStateChanged;

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


    private InputData _inputData;
    // Start is called before the first frame update
    void Start()
    {
        UpdateGameState(TutorialState.StartOfGame);
        _inputData = GetComponent<InputData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPressed))
        {
            audioPlayer.PlayOneShot(_clip3);
        }
    }

    public void UpdateGameState(TutorialState newState)
    {
        State = newState;

        switch (newState) {
            case TutorialState.StartOfGame:
                break;
            case TutorialState.LearnMovement:
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
    }
    */

}

public enum TutorialState {
    StartOfGame,
    LearnMovement,
    LearnPickUp,
    ThrowObject,
    EndOfGame
}