using UnityEngine;
using UnityEngine.InputSystem;

public class RaySelect : MonoBehaviour
{
    public Transform rayOrigin;  // The position from where the ray is cast
    public float rayDistance = 10f;  // Distance for the ray
    public LayerMask interactableLayer;  // Set layers for objects you want to interact with

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Cast a ray from the rayOrigin (e.g., VR controller)
        Ray ray = new Ray(rayOrigin.position, rayOrigin.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayDistance, interactableLayer))
        {
            // Object hit by the ray
            GameObject hitObject = hit.collider.gameObject;
            Debug.Log("Hit Object: " + hitObject.name);

            // If the input (e.g., trigger) is pressed
            if (Input.GetButtonDown("Fire1")) // Replace this with VR input action if using XR
            {
                SelectObject(hitObject);
            }
        }
    }

    void SelectObject(GameObject obj)
    {
        // Perform selection action on the object
        Debug.Log("Selected Object: " + obj.name);

        // Example: Add custom behavior, like changing color or triggering a function
        obj.GetComponent<Renderer>().material.color = Color.green;
    }
}
