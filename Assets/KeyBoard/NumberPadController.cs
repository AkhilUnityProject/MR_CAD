using TMPro;
using UnityEngine;

public class NumberPadController : MonoBehaviour
{

    public TMP_InputField inputField;
    public int maxInputLength = 10;


    public void OnNumberButtonClick(string number)
    {
        if (inputField.text.Length < maxInputLength)
        {
            inputField.text += number;
        }
    }


    public void OnDeleteButtonClick()
    {
        if (inputField.text.Length > 0)
        {
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        }
    }


    public void OnClearButtonClick()
    {
        inputField.text = "";
    }

    public void OnEnterButtonClick()

    {
        Debug.Log("Entered number: " + inputField.text);
        if (GameManager.Instance._currentActiveObject != null)
        {
            LineDrawer lineDrawer = GameManager.Instance._currentActiveObject.GetComponent<LineDrawer>();
            if (lineDrawer != null && float.TryParse(inputField.text, out float distance))
            {
                lineDrawer.SetDistance(distance);
            }
            else
            {
                Debug.LogWarning("Invalid input or LineDrawer component missing.");
            }
        }
        else
        {
            Debug.LogWarning("Current active object is null.");
        }

    }
}
