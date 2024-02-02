using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static int localScoreCounter = 0;
    public static int globalScoreCounter = 0;
    public static readonly int[] maxScorePerRoom = {0, 1, 5};

    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        // switch cannot check for values in maxScorePerRoom
        switch (globalScoreCounter) 
        {
            case 1:
                if (GameObject.Find("door_01") != null) 
                {
                    Destroy(GameObject.Find("door_01"));
                    localScoreCounter = 0;
                }
                break;
            case 5:
                if (GameObject.Find("door_02") != null) 
                {
                    Destroy(GameObject.Find("door_02"));
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
}
