using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ExampleScript : MonoBehaviour
{
    private Controls controls;
    int v = 0;
    private void Awake()
    {
        controls = new Controls();

        controls.Gameplay.ActionA.performed += _ => OnObjectClick();
        controls.Gameplay.ActionB.performed += _ => SetLineDrawerDistance();
   
    }

    private void SetLineDrawerDistance()
    {
        //GameManager.Instance._currentActiveObject.GetComponent<LineDrawer>().SetDistance(400);
        GameManager.Instance.Adder();
    }

    private void OnObjectClick()
    {
        
        Debug.Log("''''''");
        GameManager.Instance.OnObjectClick(v);
        v++;


    }

    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

   
}
