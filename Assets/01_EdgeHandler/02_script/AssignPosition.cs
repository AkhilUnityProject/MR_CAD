using UnityEngine;

public class AssignPosition : MonoBehaviour
{
    public GameObject Parent;  // Assign object A in the inspector
    public GameObject objectB;  // Assign object B in the inspector

    void Update()
    {
        if (Parent != null && objectB != null)
        {
            // Assign the position of objectA to objectB
            transform.position = Parent.transform.position;
        }
    }
}
