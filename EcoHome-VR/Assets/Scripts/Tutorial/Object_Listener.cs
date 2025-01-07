using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Listener : MonoBehaviour
{

    //to store the object beind held by the player
    private GameObject heldObject = null;

    // References to controller transforms (Assign in Unity Inspector)
    public Transform leftControllerTransform;
    public Transform rightControllerTransform;


    void Start() 
    {
        if (leftControllerTransform == null || rightControllerTransform == null) 
        {
            Debug.LogError("Controller transforms are not assigned!");
        }
    }

    /*
        FIRST ROOM PAPER Object handling
    */
    //observed variable for the first room paper in the Tutorial 
    //its needed for the audio clips in FirstLevel_LearnGrip.cs and FirstLevel_ThrowObject.cs
    [SerializeField] private Cntrl_Listener cntrl_Listener;
    public bool _firstRoomPaperIsBeingHeld;
    public static event Action<bool> OnFirstRoomPaperIsBeingHeld_Changed;
    public bool FirstRoomPaperisBeingHeld
    {
        get => _firstRoomPaperIsBeingHeld;
        set
        {
            if (_firstRoomPaperIsBeingHeld != value)
            {
                _firstRoomPaperIsBeingHeld = value;
                OnFirstRoomPaperIsBeingHeld_Changed?.Invoke(_firstRoomPaperIsBeingHeld);
            }
        }
    }

    public bool _firstRoomPaperIsDestroyed = false;
    public static event Action<bool> OnFirstRoomPaperIsDestroyed;
    public bool FirstRoomPaperIsDestroyed
    {
        get => _firstRoomPaperIsDestroyed;
        set 
        {
            if (_firstRoomPaperIsDestroyed != value)
            {
                _firstRoomPaperIsDestroyed = value;
                OnFirstRoomPaperIsDestroyed?.Invoke(_firstRoomPaperIsDestroyed);
            }
        }
    }


    void OnEnable()
    {
        TrashbinCollider.OnObjectDestroyed += HandleFirstRoomPaperDestroyed;
        cntrl_Listener.OnUsedLeftGrip += HandleFirstRoomPaperBeingHeld;
        cntrl_Listener.OnUsedLeftTrigger += HandleFirstRoomPaperBeingHeld;
        cntrl_Listener.OnUsedRightGrip += HandleFirstRoomPaperBeingHeld;
        cntrl_Listener.OnUsedRightTrigger += HandleFirstRoomPaperBeingHeld;
    }

    void OnDisable()
    {
        TrashbinCollider.OnObjectDestroyed -= HandleFirstRoomPaperDestroyed;
        cntrl_Listener.OnUsedLeftGrip -= HandleFirstRoomPaperBeingHeld;
        cntrl_Listener.OnUsedLeftTrigger -= HandleFirstRoomPaperBeingHeld;
        cntrl_Listener.OnUsedRightGrip -= HandleFirstRoomPaperBeingHeld;
        cntrl_Listener.OnUsedRightTrigger -= HandleFirstRoomPaperBeingHeld;
    }

    private void HandleFirstRoomPaperDestroyed(bool isDestroyed) {
        if (isDestroyed)
        {
            FirstRoomPaperIsDestroyed = true;
        }
        else {
            FirstRoomPaperIsDestroyed = false;
        }
    }

    //POTENTIAL TODO (needs testing) : 
    //run the function if the players aim the right object and also 
    //using the grib button (AimingDetections.cs)
    private void HandleFirstRoomPaperBeingHeld(bool isHolding)
    {
        string tutorialTag = GameObject.Find("Trash Paper Tutorial").tag;
        if (isHolding)
        {
            if (TryGrabObject(leftControllerTransform, tutorialTag) || TryGrabObject(rightControllerTransform, tutorialTag))
            {
                this.FirstRoomPaperisBeingHeld = true;
            }
        }
        else if (heldObject != null && heldObject.CompareTag(tutorialTag))
        {
            ReleaseObject();
        }
    }

    //This function checks if the player is holding a specific object
    //or if he is just holding the Grip/Trigger Button
    private bool TryGrabObject(Transform controllerTransform, string tag)
    {
        RaycastHit hit;

        if (Physics.Raycast(controllerTransform.position, controllerTransform.forward, out hit, 2f))
        {
            if (hit.collider.CompareTag(tag))
            {
                heldObject = hit.collider.gameObject;
                return true;
            }
            else return false;
        }
        else return false;
    }

    private void ReleaseObject()
    {
        if (heldObject != null) {
            heldObject.transform.SetParent(null);
            heldObject.GetComponent<Rigidbody>().isKinematic = false;
            heldObject = null;
            this.FirstRoomPaperisBeingHeld = false;
        }
    }
}