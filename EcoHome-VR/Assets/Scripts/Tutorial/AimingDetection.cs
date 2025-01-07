using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AimingDetection : MonoBehaviour
{
    private XRRayInteractor rayInteractor;
    private XRInteractionManager interactionManager;

    void Start()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
        interactionManager = FindObjectOfType<XRInteractionManager>();
    }

    void Update()
    {
        if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            GameObject aimedObject = hit.collider.gameObject;
            Debug.Log("Currently aiming at: " + aimedObject.name);

            // Add custom logic for interactions here
            HighlightObject(aimedObject);
        }
        else
        {
            // No object is aimed at
            Debug.Log("Not aiming at any object.");
        }
    }

    void HighlightObject(GameObject obj)
    {
        // Example: Change object's color when aimed at
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.yellow;
        }
    }
}
