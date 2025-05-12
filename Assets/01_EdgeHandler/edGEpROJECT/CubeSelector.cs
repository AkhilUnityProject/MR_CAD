using UnityEngine;

public class CubeSelector : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Detect left mouse click
        //if (Input.GetMouseButtonDown(0))
        //{
        //    // Create a ray from the camera to the mouse position
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    // Perform raycast and check if it hits any object
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        // Check if the hit object has a collider and is selectable
        //        GameObject selectedObject = hit.collider.gameObject;

        //        // You can add your logic here when the object is selected
        //        Debug.Log("Selected Object: " + selectedObject.name);

        //        // Optionally, change color or perform an action
        //        //selectedObject.GetComponent<Renderer>().material.color = Color.red;
        //        //selectedObject.GetComponent<ObjectSelectorcube>().PointeSeclect();
        //    }
        //}
    }
}
