using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuInteractor : MonoBehaviour
{
    private AsyncOperation _asyncOperation;
    public GameObject player;
    public Player PlayerScript;
    public GameObject LoadingScreen;
    public Slider LoadingBarFill;

    private void Start() 
    {
        player = GameObject.Find("Player");
        /* LoadingScreen = GameObject.Find("LoadingScreen");
        LoadingBarFill = GameObject.Find("Slider").GetComponent<Slider>(); */
    }

    private IEnumerator LoadSceneAsyncProcess(string sceneName)
    {
        this._asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        this._asyncOperation.allowSceneActivation = false;

        // LoadingScreen.SetActive(true);

        while (!this._asyncOperation.isDone)
        {
            /* float progress = Mathf.Clamp01(_asyncOperation.progress / 0.9f);
            LoadingBarFill.value = progress; */

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
            Destroy(player);
            this.StartCoroutine(this.LoadSceneAsyncProcess(sceneName: "Challenge - Main Scene"));
        }
    }

    public void StartTutorialMode() 
    {
        if (this._asyncOperation == null)
        {
            Destroy(player);
            this.StartCoroutine(this.LoadSceneAsyncProcess(sceneName: "Linear - Main Scene"));
        }
    }
}
