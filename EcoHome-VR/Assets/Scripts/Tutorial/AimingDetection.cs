using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
public class AimingDetection : MonoBehaviour
{
    private XRRayInteractor rayInteractor;
    private XRInteractionManager interactionManager;
    private GameObject lastAimedObject;

    void Start()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
        interactionManager = FindObjectOfType<XRInteractionManager>();
    }

    void Update()
    {
        /*if (rayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
        {
            GameObject aimedObject = hit.collider.gameObject;
            Debug.Log("Currently aiming at: " + aimedObject.name);

            if (lastAimedObject != aimedObject)
            {
                ResetTextMeshPro(lastAimedObject);

                // Add custom logic for interactions here
                HighlightObject(aimedObject);
            }
        }
        else
        {
            // No object is aimed at
            ResetTextMeshPro(lastAimedObject);
            lastAimedObject = null;
            Debug.Log("Not aiming at any object.");
        }*/
    }

    void HighlightObject(GameObject obj)
    {
        TextMeshPro textMeshPro = obj.GetComponent<TextMeshPro>();

        if (textMeshPro != null)
        {
            textMeshPro.enabled = false;
        }

        // Example: Change object's color when aimed at
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.yellow;
        }
    }

    void ResetTextMeshPro(GameObject obj)
    {
        if (obj == null) return;

        TextMeshPro textMeshPro = obj.GetComponent<TextMeshPro>();
        if (textMeshPro != null)
        {
            textMeshPro.enabled = true;
        }

        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.white;
        }
    }

}
