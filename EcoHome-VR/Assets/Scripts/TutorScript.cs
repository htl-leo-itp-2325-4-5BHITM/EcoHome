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
    public AudioClip _clip4;
    public AudioClip _clip5;
    public AudioClip _clip6;
    public AudioClip _clip7;
    public AudioClip _clip8;


    private InputData _inputData;
    // Start is called before the first frame update
    void Start()
    {
        _inputData = GetComponent<InputData>();
        GetComponent<AudioSource>().PlayOneShot(_clip1);
        GetComponent<AudioSource>().PlayOneShot(_clip2);
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