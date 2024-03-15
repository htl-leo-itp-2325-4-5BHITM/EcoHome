using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuInteractor : MonoBehaviour
{
    private AsyncOperation _asyncOperation;

    private IEnumerator LoadSceneAsyncProcess(string sceneName)
    {
        this._asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        this._asyncOperation.allowSceneActivation = false;

        while (!this._asyncOperation.isDone)
        {
            yield return null;
        }
    }

    private void Update()
    {
        if (this._asyncOperation != null)
        {
            this._asyncOperation.allowSceneActivation = true;
        }
    }

    public void StartChallengeMode() 
    {
        if (this._asyncOperation == null)
        {
            this.StartCoroutine(this.LoadSceneAsyncProcess(sceneName: "Challenge - Main Scene"));
        }
    }

    public void StartTutorialMode() 
    {
        if (this._asyncOperation == null)
        {
            this.StartCoroutine(this.LoadSceneAsyncProcess(sceneName: "Linear - Main Scene"));
        }
    }
}
