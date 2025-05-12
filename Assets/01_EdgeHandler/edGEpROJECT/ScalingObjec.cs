using UnityEngine;

public class ScalingObject : MonoBehaviour
{
    // Scale increment amount, change this to control how much the object scales when the key is pressed
    public float scaleIncrement = 1f;

    // Axis to scale (1 means scale on this axis, 0 means no scaling)
    public Vector3 scaleAxis = new Vector3(1f, 0f, 0f);

    // Update is called once per frame
    void Update()
    {
        // Check if the "S" key is pressed (you can change the key if needed)
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Calculate the new scale by adding scaleIncrement to the current scale on the chosen axis
            Vector3 newScale = transform.localScale + scaleAxis * scaleIncrement;

            // Set the new scale to the object
            transform.localScale = newScale;
        }
    }
}
