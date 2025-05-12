using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckingLengthReach : MonoBehaviour
{
    private LineDrawer _edge;

    public bool _edgeReached;

    private void Start()
    {
        _edge = GetComponent<LineDrawer>(); 
    }

    private void Update()
    {
        if (_edge._targetEdge.distanceInMillimeters.ToString("F2") == _edge.distanceInMillimeters.ToString("F2"))
        {
            _edge._egdeMessueText.GetComponent<TextMeshProUGUI>().faceColor = Color.green;
            _edgeReached = true;
        }
        else
        {
            _edgeReached = false;
            _edge._egdeMessueText.GetComponent<TextMeshProUGUI>().faceColor = Color.white;

        }
    }

   
}
