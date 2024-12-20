using System.Collections;
using UnityEngine;

public class FirstLevel_ThrowObject : MonoBehaviour
{
    [SerializeField] private Audio audioScript;
    //[SerializeField] private Cntrl_Listener listenerScript;

    public AudioClip clip_1;

    bool tutorialActive = false;
    bool _grabPaper = false;

    void OnEnable()
    {
        TutoManager.OnTutorialStateChanged += TutoManager_OnTutorialStateChanged;
        Cntrl_Listener.OnGrabPaperChanged += HandleGrabPaperChange;
        //Cntrl_Listener.OnCorrectObjectHeldStateChanged += HandleCorrectObjectHeldStateChange;
    }

    void OnDisable()
    {
        TutoManager.OnTutorialStateChanged -= TutoManager_OnTutorialStateChanged;
        Cntrl_Listener.OnGrabPaperChanged  -= HandleGrabPaperChange;
        //Cntrl_Listener.OnCorrectObjectHeldStateChanged -= HandleCorrectObjectHeldStateChange;
    }

    private void TutoManager_OnTutorialStateChanged(TutorialState state)
    {
        if (state == TutorialState.ThrowObject)
        {
            tutorialActive = true;
            StartCoroutine(ManageThrowTutorial());
        }
        else {
            tutorialActive = false;
        }
    }

    private void HandleGrabPaperChange(bool isGrabbed) {
        if (isGrabbed) {
            this._grabPaper = true;
            Debug.Log("Paper grabbed!");
        }
        else {
            this._grabPaper = false;
            Debug.Log("Paper released!");
        }
    }

    IEnumerator ManageThrowTutorial()
    {
        /*
         * - check which object the player is currenty holding
            => none object: FloorState
            => holds object and throws into the bin: EndState 
         */

        while (tutorialActive) {
            Debug.Log("_grapPaper: " + this._grabPaper);
            Debug.Log("_globalScoreCounter: " + Player.globalScoreCounter);
            if (!_grabPaper && Player.globalScoreCounter == 0) {
                Debug.Log("ThrowObject: not holding");
                yield return new WaitForSeconds(10); 
                TutoManager.Instance.UpdateTutorialState(TutorialState.TableState);
            }
            else {
                if (Player.globalScoreCounter > 0) 
                {
                    Debug.Log("State: EndOfGame: Player scored");
                    TutoManager.Instance.UpdateTutorialState(TutorialState.EndOfGame);
                    break;
                }
                else {
                    Debug.Log("ThrowObject: holding the paper");
                    audioScript.PlayAudioAfterDelay(clip_1, 1);
                    yield return new WaitForSeconds(10);
                }
            }
        }
    }
}
