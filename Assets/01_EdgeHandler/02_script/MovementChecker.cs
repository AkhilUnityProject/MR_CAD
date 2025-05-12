using UnityEngine;

public class MovementChecker : MonoBehaviour
{
    private Vector3 previousPosition;
    public bool isMoving { get; private set; }
    public float movementThreshold = 0.01f;
    private bool wasMoving = false;
    public GameObject _slider;

    private void Start()
    {
        previousPosition = transform.position;
    }

    public void OnPosition()
    {
        _slider.GetComponent<SetYPositionToZero>().enabled = true;
    }

    public void OffPositionChange()
    {
        _slider.GetComponent<SetYPositionToZero>().enabled = false;
    }
    //private void Update()
    //{
    //    // Calculate the distance moved since the last frame
    //    float distanceMoved = Vector3.Distance(transform.position, previousPosition);

    //    // Determine if the object is moving based on the threshold
    //    isMoving = distanceMoved > movementThreshold;

    //    // Check for a change in movement state and log messages
    //    if (isMoving && !wasMoving)
    //    {
    //        Debug.Log("Movement started");
           
    //    }
    //    else if (!isMoving && wasMoving)
    //    {
    //        Debug.Log("Movement stopped");
           


    //    }

    //    // Update the wasMoving flag for the next frame
    //    wasMoving = isMoving;

    //    // Store the current position for the next frame
    //    previousPosition = transform.position;
    //}
}
