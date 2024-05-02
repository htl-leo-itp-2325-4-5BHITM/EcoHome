using System.Collections;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    [SerializeField] private Audio audioScript;
    [SerializeField] private Cntrl_Listener listenerScript;

    public AudioClip clip_1;

    bool tutorialActive = false;

    bool isBeingHeld = false;

    void OnEnable()
    {
        TutoManager.OnTutorialStateChanged += TutoManager_OnTutorialStateChanged;
        //Cntrl_Listener.OnCorrectObjectHeldStateChanged += HandleCorrectObjectHeldStateChange;
    }

    void OnDisable()
    {
        TutoManager.OnTutorialStateChanged -= TutoManager_OnTutorialStateChanged;
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

    IEnumerator ManageThrowTutorial()
    {
        /*
         * - check which object the player is currenty holding
            => none object: FloorState
            => holds object and throws into the bin: EndState 
         */

        while (tutorialActive) {
            if (!listenerScript._grabPaper && Player.globalScoreCounter == 0) {
                Debug.Log("State: TableState");
                yield return new WaitForSeconds(3); 
                TutoManager.Instance.UpdateTutorialState(TutorialState.TableState);
            }
            else {
                if (Player.globalScoreCounter > 0) 
                {
                    Debug.Log("State: EndOfGame");
                    TutoManager.Instance.UpdateTutorialState(TutorialState.EndOfGame);
                    break;
                }
                else {
                    audioScript.PlayAudioAfterDelay(clip_1, 1);
                    yield return new WaitForSeconds(10);
                }
            }
        }
    }
}
