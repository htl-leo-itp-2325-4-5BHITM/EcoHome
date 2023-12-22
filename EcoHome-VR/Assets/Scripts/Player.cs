using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int localScoreCounter = 0;
    public static int globalScoreCounter = 0;
    public static int[] maxScorePerRoom = {0, 1};

    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        switch (globalScoreCounter) 
        {
            case maxScorePerRoom[1]:
                if (GameObject.Find("door_01") != null) 
                {
                    Destroy(GameObject.Find("door_01"));
                    localScoreCounter = 0;
                }
                break;
        }
    }
}
