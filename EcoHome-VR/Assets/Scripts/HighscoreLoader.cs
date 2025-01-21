using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HighscoreLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighscoreChallenge"))
        {
            int score = PlayerPrefs.GetInt("HighscoreChallenge");
            if (SceneManager.GetActiveScene().name.StartsWith("[EN]")) GameObject.Find("Highscore").GetComponent<TextMeshProUGUI>().text = "Highscore: " + score;
            else GameObject.Find("Highscore").GetComponent<TextMeshProUGUI>().text = "Höchstpunktzahl: " + score;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
