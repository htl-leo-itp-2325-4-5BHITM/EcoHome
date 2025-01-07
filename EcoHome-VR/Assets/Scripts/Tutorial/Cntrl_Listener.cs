using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cntrl_Listener : MonoBehaviour
{
    public InputData _inputData;

    //variables for using the movement sticks
    //the value of these variables changes only once to true, so it doesnt need an observable pattern
    public bool _leftStickUsed = false;
    public bool _rightStickUsed = false;

    //observerd variables for using the grip or trigger button for grabbing an object
    //values: false or true

    public bool _usedLeftGrip = false;
    public event Action<bool> OnUsedLeftGrip;
    public bool UsedLeftGrip 
    {
        get => _usedLeftGrip;
        set
        {
            if (_usedLeftGrip != value)
            {
                _usedLeftGrip = value;
                OnUsedLeftGrip?.Invoke(_usedLeftGrip);
            }
        }
    }

    public bool _usedRightGrip = false;
    public event Action<bool> OnUsedRightGrip;
    public bool UsedRightGrip 
    {
        get => _usedRightGrip;
        set
        {
            if (_usedRightGrip != value)
            {
                _usedRightGrip = value;
                OnUsedRightGrip?.Invoke(_usedRightGrip);
            }
        }
    }

    public bool _usedRightTrigger = false;
    public event Action<bool> OnUsedRightTrigger;
    public bool UsedRightTrigger
    {
        get => _usedRightTrigger;
        set
        {
            if (_usedRightTrigger != value)
            {
                _usedRightTrigger = value;
                OnUsedRightTrigger?.Invoke(_usedRightTrigger);
            }
        }
    }
    
    public bool _usedLeftTrigger = false;
    public event Action<bool> OnUsedLeftTrigger;
    public bool UsedLeftTrigger
    {
        get => _usedLeftTrigger;
        set
        {
            if (_usedLeftTrigger != value)
            {
                _usedLeftTrigger = value;
                OnUsedLeftTrigger?.Invoke(_usedLeftTrigger);
            }
        }
    }
    
    void Start()
    {
        _inputData = GetComponent<InputData>();
    }

    void Update()
    {
        UpdateStickUsage();
        UpdateGripStatus();
    }

    private void UpdateStickUsage()
    {
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

    private void UpdateGripStatus()
    {
        if (_inputData._leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out bool leftGripPressed))
        {
            if (leftGripPressed)
            {
                UsedLeftGrip = true;
            }
            else {
                UsedLeftGrip = false;
            }
        }

        if (_inputData._leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out bool leftTriggerPressed))
        {
            if (leftTriggerPressed)
            {
                UsedLeftTrigger = true;
            }
            else {
                UsedLeftTrigger = false;
            }
        }

        if (_inputData._rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out bool rightGripPressed))
        {
            if (rightGripPressed)
            {
                UsedRightGrip = true;
            }
            else {
                UsedRightGrip = false;
            }
        }

        if (_inputData._rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out bool rightTriggerPressed))
        {
            if (rightTriggerPressed)
            {
                UsedRightTrigger = true;
            }
            else {
                UsedRightTrigger = false;
            }
        }
    }
}
