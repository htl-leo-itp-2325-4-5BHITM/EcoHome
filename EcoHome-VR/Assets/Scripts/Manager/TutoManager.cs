using System;
using UnityEngine;


[RequireComponent(typeof(InputData))]
public class TutoManager : MonoBehaviour
{
    private static TutoManager _instance;

    /*
     *  This improves the Singleton by ensuring only one instance exists across scenes, preventing multiple instances from being created.
     */
    public static TutoManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<TutoManager>();
            }
            return _instance;
        }
    }

    public TutorialState State;

    public static event Action<TutorialState> OnTutorialStateChanged;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
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