using UnityEngine;

[RequireComponent(typeof(LineRenderer), typeof(BoxCollider))]
public class LineRendererColliderUpdater : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private BoxCollider boxCollider;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        boxCollider = GetComponent<BoxCollider>();

        UpdateCollider(); // Initialize the collider at start
    }

    void Update()
    {
        UpdateCollider();  // Continuously update the collider in case the line changes dynamically
    }

    // Function to update only the X size of the BoxCollider
    void UpdateCollider()
    {
        if (lineRenderer.positionCount < 2) return; // No need to update if there's only 1 point or less

        // Get the start and end positions of the LineRenderer
        Vector3 startPos = lineRenderer.GetPosition(0);
        Vector3 endPos = lineRenderer.GetPosition(lineRenderer.positionCount - 1);

        // Calculate the length of the line on the X-axis
        float lineLength = Vector3.Distance(startPos, endPos);

        // Set the collider's center point halfway between the start and end positions
        //boxCollider.center = (startPos + endPos) / 2;

        // Adjust only the X size (length) of the BoxCollider while keeping Y and Z sizes the same
        boxCollider.size = new Vector3(lineLength, boxCollider.size.y, boxCollider.size.z);
    }
}
