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

    private void ConfigureController(ActionBasedController controller, string gripBinding, string triggerBinding, bool combineTriggerAndGrip)
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
        else
        {
            // Configure separate actions for grip and trigger
            InputAction gripAction = new InputAction("Grip", InputActionType.Button);
            gripAction.AddBinding(gripBinding);
            gripAction.Enable(); // Ensure grip action is enabled

            InputAction triggerAction = new InputAction("Trigger", InputActionType.Button);
            triggerAction.AddBinding(triggerBinding);
            triggerAction.Enable(); // Ensure trigger action is enabled

            controller.selectAction = new InputActionProperty(triggerAction); // Trigger action
            controller.activateAction = new InputActionProperty(gripAction); // Grip action
        }
    }

    public void SetControlsDefault()
    {
        // Apply default controls to both controllers
        ConfigureController(leftController, "<XRController>{LeftHand}/gripPressed", "<XRController>{LeftHand}/triggerPressed", false);
        ConfigureController(rightController, "<XRController>{RightHand}/gripPressed", "<XRController>{RightHand}/triggerPressed", false);
    }

    public void SetControlsSimple()
    {
        // Apply simplified controls to both controllers
        ConfigureController(leftController, "<XRController>{LeftHand}/gripPressed", "<XRController>{LeftHand}/triggerPressed", true);
        ConfigureController(rightController, "<XRController>{RightHand}/gripPressed", "<XRController>{RightHand}/triggerPressed", true);
    }
}
