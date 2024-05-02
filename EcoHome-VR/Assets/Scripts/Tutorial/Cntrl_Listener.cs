using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cntrl_Listener : MonoBehaviour
{

    public InputData _inputData;

    public Transform leftControllerTransform;
    public Transform rightControllerTransform;

    public bool _leftStickUsed = false;
    public bool leftStickUsed
    {
        get => _leftStickUsed;
        private set 
        {
            if (_leftStickUsed == value) return;
            _leftStickUsed = value;
            OnLeftStickChanged?.Invoke(_leftStickUsed);
        }
    }
    public static event Action<bool> OnLeftStickChanged;


    public bool _rightStickUsed = false;
    public bool rightStickUsed
    {
        get => _rightStickUsed;
        private set 
        {
            if (_rightStickUsed == value) return;
            _rightStickUsed = value;
            OnRightStickChanged?.Invoke(_rightStickUsed);
        }
    }
    public static event Action<bool> OnRightStickChanged;

    public bool leftGripButtonUsed = false;
    public bool rightGripButtonUsed = false;

    public bool _isCorrectObjectHeld = false;
    public bool IsCorrectObjectHeld
    {
        get => _isCorrectObjectHeld;
        private set
        {
            if (_isCorrectObjectHeld == value) return;
            _isCorrectObjectHeld = value;
            OnCorrectObjectHeldStateChanged?.Invoke(_isCorrectObjectHeld);
        }
    }

    public static event Action<bool> OnCorrectObjectHeldStateChanged;


    public GameObject leftHeldObject;
    public GameObject rightHeldObject;
    

    public string correctObjectTag = "PaperTrash";

    public bool testUsed = false;

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
                Debug.Log("used left stick");
            }
        }

        if (_inputData._rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out Vector2 rightThumbStick))
        {
            if (Mathf.Abs(rightThumbStick.x) >= 0.80 || Mathf.Abs(rightThumbStick.x) <= -0.80)
            {
                _rightStickUsed = true;
                Debug.Log("used right stick");
            }
        }
    }

    private void UpdateGripStatus() {
        if (_inputData._leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out bool leftGripPressed))
        {
            leftGripButtonUsed = leftGripPressed;

            IsCorrectObjectHeld = CheckForObjectInHand(leftControllerTransform);
        }

        if (_inputData._rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out bool rightGripPressed))
        {
            rightGripButtonUsed = rightGripPressed;

            IsCorrectObjectHeld = CheckForObjectInHand(rightControllerTransform);
        }
    }

    private bool CheckForObjectInHand(Transform controllerTransform)
    {
        RaycastHit hit;

        if (Physics.Raycast(controllerTransform.position, controllerTransform.forward, out hit, 1.0f))
        {
            if (hit.collider.gameObject.CompareTag(correctObjectTag))
            {
                //return hit.collider.gameObject;
                return true;
            }
        }
        return false;
    }

    /*
    public bool IsHoldingCorrectObject()
    {
        return (leftHeldObject != null && leftHeldObject.CompareTag(correctObjectTag)) ||
               (rightHeldObject != null && rightHeldObject.CompareTag(correctObjectTag));
    }
    */
}
