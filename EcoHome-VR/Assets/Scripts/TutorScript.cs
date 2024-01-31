using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


[RequireComponent(typeof(InputData))]
public class TutorScript : MonoBehaviour
{
    public AudioClip _clip1;
    public AudioClip _clip2;
    public AudioClip _clip3;


    private InputData _inputData;
    // Start is called before the first frame update
    void Start()
    {
        _inputData = GetComponent<InputData>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPressed))
        {
            GetComponent<AudioSource>().PlayOneShot(_clip1);
        }
    }
}