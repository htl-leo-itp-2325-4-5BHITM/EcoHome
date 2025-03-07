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

    public void UpdateTutorialState(TutorialState newState)
    {
        switch (newState) {
            case TutorialState.StartOfGame:
                this.State = TutorialState.StartOfGame;
                break;
            case TutorialState.LearnMovement:
                this.State= TutorialState.LearnMovement;
                break;
            case TutorialState.LearnRotation:
                this.State = TutorialState.LearnRotation;
                break;
            case TutorialState.TableState:
                this.State = TutorialState.TableState;
                break;
            case TutorialState.EndOfGame:
                this.State = TutorialState.EndOfGame;
                break;
            case TutorialState.SecLevel_Start:
                this.State = TutorialState.SecLevel_Start;
                break;
            case TutorialState.SecLevel_End:
                this.State = TutorialState.SecLevel_End;
                break;
            case TutorialState.Third_Level_Start:
                this.State = TutorialState.Third_Level_Start;
                break;
            case TutorialState.Third_Level_LightOff:
                this.State = TutorialState.Third_Level_LightOff;
                break;
            case TutorialState.Third_Level_End:
                this.State = TutorialState.Third_Level_End;
                break;
            case TutorialState.Fourth_Level_Start:
                this.State = TutorialState.Fourth_Level_Start;
                break;
            case TutorialState.Fourth_Level_End:
                this.State = TutorialState.Fourth_Level_End;
                break;
            case TutorialState.Fifth_Level_Start:
                this.State = TutorialState.Fifth_Level_Start;
                break;
            case TutorialState.Fifth_Level_End:
                this.State = TutorialState.Fifth_Level_End;
                break;
            case TutorialState.Sixth_Level_Start:
                this.State = TutorialState.Sixth_Level_Start;
                break;
            case TutorialState.Sixth_Level_End:
                this.State = TutorialState.Sixth_Level_End;
                break;
            case TutorialState.End_Of_Tutorial:
                this.State = TutorialState.End_Of_Tutorial;
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
    LearnRotation,
    TableState,
    EndOfGame,
    SecLevel_Start,
    SecLevel_End,
    Third_Level_Start,
    Third_Level_LightOff,
    Third_Level_End,
    Fourth_Level_Start,
    Fourth_Level_End,
    Fifth_Level_Start,
    Fifth_Level_End,
    Sixth_Level_Start,
    Sixth_Level_End,
    End_Of_Tutorial
}