using System.Collections;
using UnityEngine;

public class FirstLevel_LearnRotation : MonoBehaviour
{
    [SerializeField] private Audio audioScript;
    [SerializeField] private Cntrl_Listener listenerScript;

    public AudioClip clip_1; // "Use the right stick"
    public AudioClip clip_congrats;

    bool tutorialActive = false;

    void OnEnable()
    {
        TutoManager.OnTutorialStateChanged += TutoManager_OnTutorialStateChanged;
    }

    void OnDisable()
    {
        TutoManager.OnTutorialStateChanged -= TutoManager_OnTutorialStateChanged;
    }


    private void TutoManager_OnTutorialStateChanged(TutorialState state)
    {
        if (state == TutorialState.LearnRotation)
        {
            tutorialActive = true;
            StartCoroutine(ManageRotationTutorial());
        }
        else {
            tutorialActive = false;
        }
    }

    IEnumerator ManageRotationTutorial()
    {
        while (tutorialActive) {
            if (!listenerScript._rightStickUsed)
            {
                audioScript.PlayAudioAfterDelay(clip_1, 1);
                yield return new WaitForSeconds(10); 
            }
            else
            {
                break;
            }
        }
        audioScript.PlayAudioAfterDelay(clip_congrats, 1); // Play audio
        TutoManager.Instance.UpdateTutorialState(TutorialState.TableState); // Proceed to the next State
    }
}
