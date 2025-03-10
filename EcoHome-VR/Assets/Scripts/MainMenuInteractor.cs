using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using RandomNameGen;

public class MainMenuInteractor : MonoBehaviour
{
    private AsyncOperation _asyncOperation;
    public GameObject player;
    public Player PlayerScript;
    public GameObject LoadingScreen;
    public Slider LoadingBarFill;

    private RandomName randomName = new RandomName(new System.Random());
    private System.Random rand = new System.Random();

    private void Start() 
    {
        player = GameObject.Find("Player");
        /* LoadingScreen = GameObject.Find("LoadingScreen");
        LoadingBarFill = GameObject.Find("Slider").GetComponent<Slider>(); */
        CheckLanguageSettings();
        CheckPlayerName();
    }

    private void CheckLanguageSettings() {
        switch (PlayerPrefs.GetString("Language"))
        {
            case "[EN]":
                if(!SceneManager.GetActiveScene().name.StartsWith("[EN]")) LoadMenuEN();
                break;
            case "[DE]":
                if(SceneManager.GetActiveScene().name.StartsWith("[EN]")) LoadMenuDE();
                break;
            default:
                PlayerPrefs.SetString("Language", "[EN]");
                break;
        }
    }

    private void CheckPlayerName() {
        if(!PlayerPrefs.HasKey("PlayerName")) {
            int decider = rand.Next(0, 1);
            PlayerPrefs.SetString("PlayerName", randomName.Generate(decider == 0 ? RandomNameGen.Sex.Male : RandomNameGen.Sex.Female, 0, false));
        }
        Debug.Log("Welcome, " + PlayerPrefs.GetString("PlayerName") + "!");
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
            if (SceneManager.GetActiveScene().name.StartsWith("[EN]")) this.StartCoroutine(this.LoadSceneAsyncProcess(sceneName: "[EN] Challenge - Main Scene"));
            else this.StartCoroutine(this.LoadSceneAsyncProcess(sceneName: "Challenge - Main Scene"));
        }
    }

    public void StartTutorialMode() 
    {
        if (this._asyncOperation == null)
        {
            Destroy(player);
            if (SceneManager.GetActiveScene().name.StartsWith("[EN]")) this.StartCoroutine(this.LoadSceneAsyncProcess(sceneName: "[EN] Linear - Main Scene"));
            else this.StartCoroutine(this.LoadSceneAsyncProcess(sceneName: "Linear - Main Scene"));
        }
    }

    public void LoadMenuDE() 
    {
        if (this._asyncOperation == null && SceneManager.GetActiveScene().name.StartsWith("[EN]"))
        {
            Destroy(player);
            PlayerPrefs.SetString("Language", "[DE]");
            this.StartCoroutine(this.LoadSceneAsyncProcess(sceneName: "Main Menu - Main Scene"));
        }
    }

    public void LoadMenuEN() 
    {
        if (this._asyncOperation == null && !SceneManager.GetActiveScene().name.StartsWith("[EN]"))
        {
            Destroy(player);
            PlayerPrefs.SetString("Language", "[EN]");
            this.StartCoroutine(this.LoadSceneAsyncProcess(sceneName: "[EN] Main Menu - Main Scene"));
        }
    }

    public void LoadLeaderboards()
    {
        Destroy(player);
        if (SceneManager.GetActiveScene().name.StartsWith("[EN]")) this.StartCoroutine(this.LoadSceneAsyncProcess(sceneName: "[EN] HoF - Main Scene"));
        else this.StartCoroutine(this.LoadSceneAsyncProcess(sceneName: "HoF - Main Scene"));
    }

    public void BackToMenu()
    {
        Destroy(player);
        if (SceneManager.GetActiveScene().name.StartsWith("[EN]")) SceneManager.LoadScene("[EN] Main Menu - Main Scene");
        else SceneManager.LoadScene("Main Menu - Main Scene");
    }
}
