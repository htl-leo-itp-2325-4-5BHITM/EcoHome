using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigExit : MonoBehaviour
{
    public static TrigExit instance;

    [HideInInspector]
    public VRUIOperations currentCollider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void OnDisable() 
    {
        currentCollider.onExit.Invoke();
    }
}
