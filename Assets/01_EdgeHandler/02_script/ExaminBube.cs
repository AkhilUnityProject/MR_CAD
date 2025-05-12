using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExaminBube : MonoBehaviour
{
    [Header("ExaminCube")]
    public GameObject[] _examinTestEdge;
    public GameObject[] _examindgetexts;

    public GameObject[] _referenceEdge;
    public bool _yes;
    public void PrintEdgeLength()
    {
        //_yes = true;
        //Debug.Log("Examin : " + _examinTestEdge[0].GetComponent<LineDrawer>().distanceInMeters); 
        //Debug.Log("ref : " + _referenceEdge[0].GetComponent<LineDrawer>().distanceInMeters); 
    }
    private void Update()
    {
        if (_yes)
        {
            //GameManager.Instance.CalculateAllEdges(GameManager.Instance.currentArray);
            //GameManager.Instance.CalculateAllEdges(_referenceEdge);

            Debug.Log("Examin : " + _examinTestEdge[0].GetComponent<LineDrawer>().distanceInMeters);
            Debug.Log("ref : " + _referenceEdge[0].GetComponent<LineDrawer>().distanceInMeters);
        }
    }
}
