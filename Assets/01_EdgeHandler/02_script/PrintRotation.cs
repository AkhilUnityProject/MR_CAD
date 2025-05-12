using TMPro;
using UnityEngine;

public class PrintRotation : MonoBehaviour
{
    public TextMeshProUGUI _knobeValue;
    public TextMeshPro _knobeValuefromKnob;
    public float lastVal;
    private int A;
    private int currentRotation = 0;
    //private int currentRotationCM = 0;
    //private int currentRotationMM = 0;
    //private int currentRotationM = 0;
    //private int currentRotationDM = 0;
    private void Start()
    {
        if (float.TryParse(_knobeValuefromKnob.text, out float currentVal))
        {
            lastVal = currentVal;
        }
    }

    void Update()
    {
        if (float.TryParse(_knobeValuefromKnob.text, out float currentVal))
        {

            if (GameManager.Instance._unity_cm)
            {
                currentRotation = GameManager.Instance._currentActiveObject.GetComponent<LineDrawer>().currentRotationCM;
                GameManager.Instance._currentActiveObject.GetComponent<LineDrawer>()._knobeValueIncm = GameManager.Instance._xrKnob.value;
            }
            else if (GameManager.Instance._unity_mm)
            {
                currentRotation = GameManager.Instance._currentActiveObject.GetComponent<LineDrawer>().currentRotationMM;
                GameManager.Instance._currentActiveObject.GetComponent<LineDrawer>()._knobeValueInmm = GameManager.Instance._xrKnob.value;
            }
            else if (GameManager.Instance._unity_m)
            {
                currentRotation = GameManager.Instance._currentActiveObject.GetComponent<LineDrawer>().currentRotationM;
                GameManager.Instance._currentActiveObject.GetComponent<LineDrawer>()._knobeValueInm = GameManager.Instance._xrKnob.value;
            }
            else if (GameManager.Instance._unity_dm)
            {
                currentRotation = GameManager.Instance._currentActiveObject.GetComponent<LineDrawer>().currentRotationDM;
                GameManager.Instance._currentActiveObject.GetComponent<LineDrawer>()._knobeValueIndm = GameManager.Instance._xrKnob.value;
            }
            int nearest15Degree = Mathf.RoundToInt(currentVal / 15) * 15;
            if (nearest15Degree != currentRotation)
            {
                int angleDifference = Mathf.Abs(nearest15Degree - currentRotation);

                if (nearest15Degree > currentRotation)
                {
                    //A += 1;
                    GameManager.Instance.Adder();
                }
                else if (nearest15Degree < currentRotation)
                {
                    //A -= 1;
                    GameManager.Instance.substractor();

                }

                //currentRotation = nearest15Degree;
                if (GameManager.Instance._unity_cm)
                {
                    GameManager.Instance._currentActiveObject.GetComponent<LineDrawer>().currentRotationCM = nearest15Degree;
                }
                else if (GameManager.Instance._unity_mm)
                {
                    GameManager.Instance._currentActiveObject.GetComponent<LineDrawer>().currentRotationMM = nearest15Degree;

                }
                else if (GameManager.Instance._unity_m)
                {
                    GameManager.Instance._currentActiveObject.GetComponent<LineDrawer>().currentRotationM = nearest15Degree;

                }
                else if (GameManager.Instance._unity_dm)
                {
                    GameManager.Instance._currentActiveObject.GetComponent<LineDrawer>().currentRotationDM = nearest15Degree;

                }

            }
        }
        else
        {
            Debug.LogWarning("Failed to parse knob value to float: " + _knobeValuefromKnob.text);
        }
    }

    public void ResetAllObject()
    {
        //currentRotation = 0;
        //currentRotationCM = 0;
        //currentRotationMM = 0;
        //currentRotationM = 0;
        //currentRotationDM = 0;
    }
}
