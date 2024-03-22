using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cntrl_Listener : MonoBehaviour
{

    private InputData _inputData;
    public Audio audioScript;

    public bool leftStickUsed = false;
    public bool righStickUsed = false;
    public bool leftGripButtonUsed = false;
    public bool rightGripButtonUsed = false;

    public bool testUsed = false;

    // Start is called before the first frame update
    void Start()
    {
        _inputData = GetComponent<InputData>();
    }

    // Update is called once per frame
    void Update()
    {
        //Observed Variables

        if (_inputData._leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out Vector2 leftThumbStick))
        {
            if (leftThumbStick.y >= 0.80 || leftThumbStick.y <= -0.80)
            {
                leftStickUsed = true;
                Debug.Log("used right stick");
            }
        }

        if (_inputData._rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out Vector2 rightThumbStick))
        {
            if (rightThumbStick.x >= 0.80 || rightThumbStick.x <= -0.80)
            {
                righStickUsed = true;
                Debug.Log("used left stick");
            }
        }

        if (_inputData._leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out bool leftGripPressed))
        {
            if (leftGripPressed && !leftGripButtonUsed)
            {
                leftGripButtonUsed = true;
                Debug.Log("Left grip button pressed");
                // Trigger the event or method to play clip_2
            }
            else if (!leftGripPressed && leftGripButtonUsed)
            {
                leftGripButtonUsed = false;
                Debug.Log("Left grip button released");
                // Trigger the event or method to replay clip_1
            }
        }

        /*
        if (_inputData._rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out bool rightGripPressed))
        {
            rightGripButtonUsed = true;
            Debug.Log("used right grip button");
        }
        */
    }
}
