using System.Collections;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    [SerializeField] private Audio audioScript;
    [SerializeField] private Cntrl_Listener listenerScript;

    public AudioClip clip_1;

    bool isBeingHeld = false;

    void OnEnable()
    {
        Cntrl_Listener.OnCorrectObjectHeldStateChanged += HandleCorrectObjectHeldStateChange;
    }

    void OnDisable()
    {
        Cntrl_Listener.OnCorrectObjectHeldStateChanged -= HandleCorrectObjectHeldStateChange;
    }

    private void HandleCorrectObjectHeldStateChange(bool isHeld)
    {
        if (isHeld)
        {
            Debug.Log("Correct object is currently being held.");
            isBeingHeld = true;
        }
        else
        {
            Debug.Log("Correct object is not being held.");
            isBeingHeld = false;
        }
    }

    void Awake()
    {
        TutoManager.OnTutorialStateChanged += TutoManager_OnTutorialStateChanged;
    }

    void OnDestroy()
    {
        TutoManager.OnTutorialStateChanged -= TutoManager_OnTutorialStateChanged;
    }

    private void TutoManager_OnTutorialStateChanged(TutorialState state)
    {
        if (state == TutorialState.ThrowObject)
        {
            StartCoroutine(ManageThrowTutorial());
        }
    }

    IEnumerator ManageThrowTutorial()
    {
        /*
         * - check which object the player is currenty holding
            => none object: FloorState
            => holds object and throws into the bin: EndState 
         */


        while(true)
        {
           if (!isBeingHeld)
           {
                TutoManager.Instance.UpdateTutorialState(TutorialState.FloorState);
           }
           else
           {
                audioScript.PlayAudioAfterDelay(clip_1, 1);
                audioScript.StartRepeatAction(() => audioScript.PlayAudioAfterDelay(clip_1, 1), 10000);
                yield return new WaitUntil(() => Player.globalScoreCounter > 0);
                TutoManager.Instance.UpdateTutorialState(TutorialState.EndOfGame);
                break;
            }
        }
    }
}
