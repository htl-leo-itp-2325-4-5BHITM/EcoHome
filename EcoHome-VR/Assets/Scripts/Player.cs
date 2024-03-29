using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(InputData))]
public class Player : MonoBehaviour
{
    public static int localScoreCounter = 0;
    public static int globalScoreCounter = 0;
    
    public static int displayScoreCounter = 0;
    public static readonly int[] maxScorePerRoom = {0, 1, 5};

    bool rotating = false;

    private InputData _inputData;

    TextMeshProUGUI displayScore;

    // Start is called before the first frame update
    void Start()
    {
        displayScore = GameObject.Find("Display Score").GetComponent<TextMeshProUGUI>();
        _inputData = GetComponent<InputData>();
    }

    // Update is called once per frame
    void Update()
    {
        displayScore.text = "Score: " + displayScoreCounter;

        if (_inputData._leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.menuButton, out bool buttonPressed) && buttonPressed)
        {
            SceneManager.LoadScene("Main Menu - Main Scene");
        }

        // switch cannot check for values in maxScorePerRoom
        switch (globalScoreCounter) 
        {
            case 1:
                if (localScoreCounter > 0) 
                {
                    StartCoroutine(RotateDoor(GameObject.Find("door_01"), new Vector3(-1.193f, -1.099973f, -2.151f)));
                    localScoreCounter = 0;
                }
                break;
            case 5:
                if (localScoreCounter > 0) 
                {
                    StartCoroutine(RotateDoor(GameObject.Find("door_02"), new Vector3(-1.193f, -1.099973f, -10.566f)));
                    localScoreCounter = 0;
                }
                break;
            
            // case for restarting after completing level
            /* case 5:
                globalScoreCounter = 0;
                SceneManager.LoadScene("Sebastian_Scene");
                break; */
        }
    }

    IEnumerator RotateDoor(GameObject door, Vector3 pivot) 
    {
        if (rotating)
        {
            yield break;
        }
        rotating = true;

        Quaternion currentRot = door.transform.rotation;
        Quaternion newRot = Quaternion.Euler(new Vector3(0, 110, 0));
        float duration = 3f;

        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            door.transform.RotateAround(pivot, new Vector3(0, 110, 0), counter / duration);
            yield return null;
        }
        rotating = false;
    }
}
