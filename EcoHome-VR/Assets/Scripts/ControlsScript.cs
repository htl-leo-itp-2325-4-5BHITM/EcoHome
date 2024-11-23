using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ControlsScript : MonoBehaviour
{
    private ActionBasedController leftController;
    private ActionBasedController rightController;

    // Start is called before the first frame update
    void Start()
    {
        leftController = GameObject.Find("Left Controller").GetComponent<ActionBasedController>();
        rightController = GameObject.Find("Right Controller").GetComponent<ActionBasedController>();

        if (PlayerPrefs.HasKey("Controls"))
        {
            switch (PlayerPrefs.GetString("Controls"))
            {
                case "default":
                    SetControlsDefault();
                    break;
                case "simple":
                    SetControlsSimple();
                    break;
            }
        }
        else
        {
            UpdateControlsDefault();
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void UpdateControlsDefault()
    {
        PlayerPrefs.SetString("Controls", "default");
        SetControlsDefault();
    }

    public void UpdateControlsSimple()
    {
        PlayerPrefs.SetString("Controls", "simple");
        SetControlsSimple();
    }

    private void ConfigureController(ActionBasedController controller, string triggerBinding, bool combineTriggerAndGrip)
    {
        if (combineTriggerAndGrip)
        {
            // Configure trigger to perform both grip and trigger actions
            InputAction combinedAction = new InputAction("Combined", InputActionType.Button);
            combinedAction.AddBinding(triggerBinding);
            combinedAction.Enable(); // Ensure action is enabled

            controller.selectAction = new InputActionProperty(combinedAction); // Trigger does both
            controller.activateAction = new InputActionProperty(combinedAction); // Trigger does both
        }
    }

    public void SetControlsDefault()
    {
        // Apply default controls to both controllers
        ConfigureController(leftController, "<XRController>{LeftHand}/triggerPressed", false);
        ConfigureController(rightController,"<XRController>{RightHand}/triggerPressed", false);
    }

    public void SetControlsSimple()
    {
        // Apply simplified controls to both controllers
        ConfigureController(leftController, "<XRController>{LeftHand}/triggerPressed", true);
        ConfigureController(rightController,"<XRController>{RightHand}/triggerPressed", true);
    }
}
