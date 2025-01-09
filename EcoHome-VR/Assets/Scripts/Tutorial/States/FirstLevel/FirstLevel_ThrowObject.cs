using System.Collections;
using UnityEngine;

public class FirstLevel_ThrowObject : MonoBehaviour
{
    [SerializeField] private Audio audioScript;
    //[SerializeField] private Cntrl_Listener listenerScript;

    public AudioClip clip_1;

    //bool tutorialActive = false;
    //bool _grabPaper = false;

    void OnEnable()
    {
        TutoManager.OnTutorialStateChanged += TutoManager_OnTutorialStateChanged;
       // Cntrl_Listener.OnGrabPaperChanged += HandleGrabPaperChange;
        //Cntrl_Listener.OnCorrectObjectHeldStateChanged += HandleCorrectObjectHeldStateChange;
    }

    void OnDisable()
    {
        TutoManager.OnTutorialStateChanged -= TutoManager_OnTutorialStateChanged;
      //  Cntrl_Listener.OnGrabPaperChanged  -= HandleGrabPaperChange;
        //Cntrl_Listener.OnCorrectObjectHeldStateChanged -= HandleCorrectObjectHeldStateChange;
    }

    private void TutoManager_OnTutorialStateChanged(TutorialState state)
    {
        if (state == TutorialState.ThrowObject)
        {
            //tutorialActive = true;
            StartCoroutine(ManageThrowTutorial());
        }
        else {
            //tutorialActive = false;
        }
    }

    private void HandleGrabPaperChange(bool isGrabbed) {
    //code
    }

    IEnumerator ManageThrowTutorial()
    {
        Debug.Log("Do Nothing in ManageThrowTutorial");
        yield return new WaitForSeconds(60);
        /*
         * - check which object the player is currenty holding
            => none object: FloorState
            => holds object and throws into the bin: EndState 
         */
        /*
        while (tutorialActive) {
          
            if (!_grabPaper && Player.globalScoreCounter == 0) {
                yield return new WaitForSeconds(10); 
                TutoManager.Instance.UpdateTutorialState(TutorialState.TableState);
            }
            else {
                if (Player.globalScoreCounter > 0) 
                {
                    TutoManager.Instance.UpdateTutorialState(TutorialState.EndOfGame);
                    break;
                }
                else {
                    audioScript.PlayAudioAfterDelay(clip_1, 1);
                    yield return new WaitForSeconds(10);
                }
            }
        }
        */
    }
    
}
