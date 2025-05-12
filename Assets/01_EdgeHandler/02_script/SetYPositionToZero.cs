using UnityEngine;

public class SetYPositionToZero : MonoBehaviour
{

    float lastVal;
    public Transform _refTranceForm;
    void Start()
    {
        lastVal = _refTranceForm.localPosition.z;
    }
    private void Update()
    {
        float currentZPosition = _refTranceForm.position.z;
        float zDifference = currentZPosition - lastVal;

        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, _refTranceForm.localPosition.z + 0.09f /*+ zDifference*/);
        lastVal = currentZPosition;
    }

}