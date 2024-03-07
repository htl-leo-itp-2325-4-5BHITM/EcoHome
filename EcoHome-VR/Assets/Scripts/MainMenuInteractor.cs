using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuInteractor : MonoBehaviour
{
    public void StartChallengeMode() 
    {
        SceneManager.LoadScene("Challenge - Main Scene");
    }

    public void StartTutorialMode() {
        SceneManager.LoadScene("Linear - Main Scene");
    }
}
