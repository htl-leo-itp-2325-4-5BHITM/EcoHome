using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cntrl_Listener : MonoBehaviour
{

    public InputData _inputData;

    public bool _leftStickUsed = false;

    public bool _rightStickUsed = false;

    public bool _usedLeftGrip = false;
    public bool _usedRightGrip = false;

    public bool _grabPaper = true;

    // Start is called before the first frame update
    void Start()
    {
        _inputData = GetComponent<InputData>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStickUsage();
        UpdateGripStatus();
    }

    private void UpdateStickUsage() {
        if (_inputData._leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out Vector2 leftThumbStick))
        {
            if (Mathf.Abs(leftThumbStick.y) >= 0.80 || Mathf.Abs(leftThumbStick.y) <= -0.80)
            {
                _leftStickUsed = true;
            }
        }

        if (_inputData._rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out Vector2 rightThumbStick))
        {
            if (Mathf.Abs(rightThumbStick.x) >= 0.80 || Mathf.Abs(rightThumbStick.x) <= -0.80)
            {
                _rightStickUsed = true;
            }
        }
    }

    private void UpdateGripStatus() {
        if (_inputData._leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out bool leftGripPressed))
        {
            _usedLeftGrip = leftGripPressed;
        }

        if (_inputData._rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out bool rightGripPressed))
        {
            _usedRightGrip = rightGripPressed;
        }
    }

    public void SelectPaper()
    {
        _grabPaper = true;
    }

    public void ExitPaperSelection() {
        _grabPaper = false;
    }

    public void HoverPaper() {
        Debug.Log("Hover Paper");
    }

    public void ExitHoverPaper() {
        Debug.Log("Exit Hover Paper");
    }

}
