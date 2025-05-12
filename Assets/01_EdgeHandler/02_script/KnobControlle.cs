using TMPro;
using UnityEngine;

public class KnobController : MonoBehaviour
{
    public float minValue = 0f;      // Minimum value
    public float maxValue = 100f;    // Maximum value
    public float rotationSpeed = 1f; // Speed of rotation-to-value mapping
    public float currentValue = 0f;  // Current value based on rotation
    public TextMeshProUGUI _displayText;

    private float previousRotation;  // Previous frame's rotation angle

    void Start()
    {
        // Initialize the previous rotation angle based on the current z-rotation
        previousRotation = transform.eulerAngles.z;
    }

    void Update()
    {
        // Get the current z-axis rotation of the knob
        float currentRotation = transform.eulerAngles.z;
        float currentRotationY = transform.eulerAngles.y;
        _displayText.text = currentRotationY.ToString();
        Debug.Log("Current Value: " + currentRotationY);
        // Calculate the rotation difference from the previous frame
        float rotationDifference = currentRotation - previousRotation;

        // Adjust for angle wrap-around (from 0 to 360 degrees)
        if (rotationDifference > 180) rotationDifference -= 360;
        if (rotationDifference < -180) rotationDifference += 360;

        // Update the value based on the rotation direction
        currentValue += rotationDifference * rotationSpeed;

        // Clamp the value to stay within the set range
        currentValue = Mathf.Clamp(currentValue, minValue, maxValue);

        // Update the previous rotation for the next frame
        previousRotation = currentRotation;
       
        // Optional: Output the current value to the console
        //Debug.Log("Current Value: " + currentValue);
    }
}
