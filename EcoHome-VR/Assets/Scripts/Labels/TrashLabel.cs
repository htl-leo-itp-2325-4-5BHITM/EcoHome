using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashLabel : MonoBehaviour
{

    [SerializeField] public Transform lookAt;
    [SerializeField] public Vector3 offset;

    public GameObject txtToDisplay;
    //private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
       //mainCamera = Camera.mainCamera;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 pos = mainCamera.WorldToScreenPoint(lookAt.position + offset);
        //transform.LookAt(mainCamera.transform);

        //if (transform.position != pos) transform.position = pos;
    }
}
