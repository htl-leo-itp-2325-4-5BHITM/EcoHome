using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class VRUIOperations : MonoBehaviour
{
    public UnityEvent OnEnter;
    public UnityEvent onExit;

/*
    private void OnCollisionEnter(Collider other)
    {
        TrigExit.instance.currentCollider = GetComponent<VRUIOperations>();
        OnEnter.Invoke();
    }
    */
}
