using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(InputData))]
public class PlayerMuseum : MonoBehaviour
{
    public static int localScoreCounter = 0;
    public static int globalScoreCounter = 0;
    
    public static int displayScoreCounter = 0;


    private InputData _inputData;

    TextMeshProUGUI displayScore;

    // Start is called before the first frame update
    void Start()
    {
        localScoreCounter = 0;
        globalScoreCounter = 0;
        displayScoreCounter = 0;

        displayScore = GameObject.Find("Display Score").GetComponent<TextMeshProUGUI>();
        _inputData = GetComponent<InputData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputData._leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out bool buttonPressed) && buttonPressed)
        {
            SceneManager.LoadScene("Main Menu - Main Scene");
        }
    }

   
}
