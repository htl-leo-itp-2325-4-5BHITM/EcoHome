using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("HighscoreChallenge"))
        {
            int score = PlayerPrefs.GetInt("HighscoreChallenge");
            GameObject.Find("Highscore").GetComponent<TextMeshProUGUI>().text = "Highscore: " + score;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
