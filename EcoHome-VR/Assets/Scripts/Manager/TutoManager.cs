using System;
using UnityEngine;


[RequireComponent(typeof(InputData))]
public class TutoManager : MonoBehaviour
{
    public static TutoManager Instance;

    public TutorialState State;

    public static event Action<TutorialState> OnTutorialStateChanged;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateTutorialState(TutorialState.StartOfGame);
    }

    // Update is called once per frame
    void Update(){}

    /*-----------------------------------------------------------------------------------------------*/

    public void UpdateTutorialState(TutorialState newState)
    {
        switch (newState) {
            case TutorialState.StartOfGame:
                this.State = TutorialState.StartOfGame;
                break;
            case TutorialState.LearnMovement:
                this.State= TutorialState.LearnMovement;
                break;
            case TutorialState.ThrowObject:
                this.State = TutorialState.ThrowObject;
                break;
            case TutorialState.EndOfGame:
                this.State = TutorialState.EndOfGame;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnTutorialStateChanged?.Invoke(newState);
    }
}

public enum TutorialState {
    StartOfGame,
    LearnMovement,
    ThrowObject,
    EndOfGame
}