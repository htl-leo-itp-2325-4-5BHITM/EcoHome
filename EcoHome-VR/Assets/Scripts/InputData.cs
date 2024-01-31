using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class InputData : MonoBehaviour
{
    public InputDevice _rightController;
    public InputDevice _leftController;
    public InputDevice _HMD;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_rightController.isValid || !_leftController.isValid || !_HMD.isValid) InitializeInputDevices();
    }

    private void InitializeInputDevices()
    {
        if (!_rightController.isValid)
            InitializeInputDevice(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, ref _rightController);
        if (!_leftController.isValid)
            InitializeInputDevice(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, ref _leftController);
        if (!_HMD.isValid)
            InitializeInputDevice(InputDeviceCharacteristics.HeadMounted, ref _HMD);
    }

    private void InitializeInputDevice(InputDeviceCharacteristics inputDeviceCharacteristics, ref InputDevice inputDevice) {
        List<InputDevice> devices = new List<InputDevice>();

        if (devices.Count > 0) {
            inputDevice = devices[0];
        }
    }
}