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

    // observable variable for grabbing the paper
    public bool _grabPaper;
    public event Action<bool> OnGrabPaperChanged;

    public bool GrabPaper 
    {
        get => _grabPaper;
        set 
        {
            if (_grabPaper != value)
            {
                _grabPaper = value;
                OnGrabPaperChanged?.Invoke(_grabPaper);
            }
        }
    }

    private GameObject heldObject = null;  // To store the object being held

    // References to controller transforms (Assign in Unity Inspector)
    public Transform leftControllerTransform;
    public Transform rightControllerTransform;

    void Start()
    {
        _inputData = GetComponent<InputData>();

        // Ensure these are assigned either in the Inspector or dynamically
        if (leftControllerTransform == null || rightControllerTransform == null)
        {
            Debug.LogError("Controller transforms are not assigned!");
        }
    }

    void Update()
    {
        UpdateStickUsage();
        UpdateGripStatus();
        HandleObjectGrab();
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
                UsedLeftGrip = leftGripPressed;
                GrabPaper = leftGripPressed;
            }
        }
        else
        {
            UsedLeftGrip = false;
            GrabPaper = false;
        }

        if (_inputData._leftController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out bool leftTriggerPressed))
        {
            if (leftTriggerPressed)
            {
                UsedLeftGrip = leftTriggerPressed;
                GrabPaper = leftTriggerPressed;
            }
        }

        if (_inputData._rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.gripButton, out bool rightGripPressed))
        {
            if (rightGripPressed)
            {
                UsedRightGrip = rightGripPressed;
                GrabPaper = rightGripPressed;
            }
        }

        if (_inputData._rightController.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out bool rightTriggerPressed))
        {
            if (rightTriggerPressed)
            {
                UsedRightGrip = rightTriggerPressed;
                GrabPaper = rightTriggerPressed;
            }
        }
    }

    private void HandleObjectGrab()
    {
        String tutorialTag = GameObject.Find("Trash Paper Tutorial").tag;
        // Handle left controller grab
        if (UsedLeftGrip)
        {
            TryGrabObject(leftControllerTransform, tutorialTag);
        }
        else if (heldObject != null && heldObject.CompareTag(tutorialTag))
        {
            ReleaseObject();
        }

        // Handle right controller grab
        if (UsedRightGrip)
        {
            TryGrabObject(rightControllerTransform, tutorialTag);
        }
        else if (heldObject != null && heldObject.CompareTag(tutorialTag))
        {
            ReleaseObject();
        }
    }

    private void TryGrabObject(Transform controllerTransform, string tag)
    {
        RaycastHit hit;
        // Cast a ray from the controller's position to detect grabbable objects
        if (Physics.Raycast(controllerTransform.position, controllerTransform.forward, out hit, 2f))
        {
            // If the hit object is grabbable
            if (hit.collider.CompareTag(tag))
            {
                heldObject = hit.collider.gameObject;
                //heldObject.transform.SetParent(controllerTransform); // Attach to controller
                //heldObject.GetComponent<Rigidbody>().isKinematic = true; // Disable physics
                
                // Log the name of the object being held
                Debug.Log("Holding Object: " + heldObject.name);
                
                GrabPaper = true; // Update grab state
            }
        }
    }

    private void ReleaseObject()
    {
        if (heldObject != null)
        {
            // Log the name of the object being released
            Debug.Log("Released Object: " + heldObject.name);
            
            // Detach from controller
            heldObject.transform.SetParent(null);
            heldObject.GetComponent<Rigidbody>().isKinematic = false; // Re-enable physics
            heldObject = null; // Clear reference to held object
            GrabPaper = false; // Reset grab state
        }
    }

    public void SelectPaper()
    {
        _grabPaper = true;
    }

    public void ExitPaperSelection()
    {
        _grabPaper = false;
    }

    public void HoverPaper()
    {
        Debug.Log("Hover Paper");
    }

    public void ExitHoverPaper()
    {
        Debug.Log("Exit Hover Paper");
    }
}
