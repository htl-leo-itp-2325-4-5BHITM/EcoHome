using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sixth_Level_Start : MonoBehaviour
{
// Script References
    [SerializeField] private Audio audioScript;
    [SerializeField] private Player playerScript;

    // Audio Clips
    public AudioClip clip_1;

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
        if (state == TutorialState.Sixth_Level_Start)
        {
            StartCoroutine(ManageFourthLevelStart());
        }
    }

    IEnumerator ManageFourthLevelStart()
    {

        audioScript.PlayAudioAfterDelay(clip_1, 1);     
        TutoManager.Instance.UpdateTutorialState(TutorialState.Sixth_Level_End);
        yield return new WaitForSeconds(2);
    }
}
