using TMPro;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public bool _examinObject;
    public Transform startPoint;
    public Transform endPoint;

    public LineRenderer lineRenderer;
    private BoxCollider boxCollider;
    public Color Color;
    public Transform virtualMid;
    public GameObject _egdeMessueText;

    public float _maxLimit_In_Meter = 2f;
    public float _minLimit_In_Meter = 0.001f;

    public bool _isRef;


    public LineDrawer _targetEdge;
    public bool _targeLengthGet;
    public bool _startPointReached;
    public bool _endPointReached;

    private float _addingValue;

    public bool _ADD;

    public bool _iStype_1;
    public bool _istype_2;
    public bool _istype_3;
    public bool _edgeTop;
    public bool _edgeBottom;
    public bool _edgeSideL;
    public bool _edgeSideR;
    public float distanceInMeters;
    public float distanceInCentimeters;
    public float distanceInMillimeters;
    public float distanceInDecimeters;
    public int currentRotationCM = 0;
    public int currentRotationMM = 0;
    public int currentRotationM = 0;
    public int currentRotationDM = 0;
    public float _knobeValueInmm;
    public float _knobeValueIncm;
    public float _knobeValueIndm;
    public float _knobeValueInm;
    private Vector3 _startpointinitialPosition;
    private Vector3 _endpointinitialPosition;
    // Calculate the center and size of the collider

    void Start()
    {

        lineRenderer = gameObject.GetComponent<LineRenderer>();
        boxCollider = gameObject.GetComponent<BoxCollider>();

        if (_isRef)
        {
            lineRenderer.startWidth = 0.002f;
            lineRenderer.endWidth = 0.002f;
        }
        else
        {
            lineRenderer.startWidth = 0.005f;
            lineRenderer.endWidth = 0.005f;
        }


        lineRenderer.positionCount = 2;

        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));

        lineRenderer.startColor = Color;
        lineRenderer.endColor = Color;

        UpdateCollider();

        _startpointinitialPosition = startPoint.position;
        _endpointinitialPosition = endPoint.position;
    }

    void Update()
    {
        lineRenderer.SetPosition(0, startPoint.position);
        lineRenderer.SetPosition(1, endPoint.position);

        UpdateCollider();
        if (_ADD)
        {
            _ADD = false;

        }
    }


    private void UpdateCollider()
    {
        Vector3 midPoint = (startPoint.position + endPoint.position) / 2;
        float distance = Vector3.Distance(startPoint.position, endPoint.position);
        float adjustValue;
        adjustValue = distance / 4;
        //if (!_isRef)
        {
            if (_egdeMessueText != null)
            {
                if (_edgeTop)
                {
                    if (_isRef)
                    {
                        _egdeMessueText.transform.position = new Vector3(midPoint.x, midPoint.y + adjustValue + .01f, midPoint.z);

                    }
                    else
                    {
                        _egdeMessueText.transform.position = new Vector3(midPoint.x, midPoint.y + adjustValue - .01f, midPoint.z);

                    }
                    //Debug.Log(" adjust value " + adjustValue);
                    _egdeMessueText.GetComponent<TextMeshProUGUI>().fontSize = Mathf.Abs(midPoint.y * 1.1f);



                }
                else if (_edgeBottom)
                {
                    if (_isRef)
                    {
                        _egdeMessueText.transform.position = new Vector3(midPoint.x, midPoint.y - 0.025f, midPoint.z);

                    }
                    else
                    {
                        _egdeMessueText.transform.position = new Vector3(midPoint.x, midPoint.y - 0.013f, midPoint.z);

                    }
                    _egdeMessueText.GetComponent<TextMeshProUGUI>().fontSize = Mathf.Abs(midPoint.y * 1.1f);


                }
                else if (_edgeSideL)
                {
                    float newAdjustVal = adjustValue * 2;
                    if (_isRef)
                    {
                        _egdeMessueText.transform.position = new Vector3(midPoint.x - newAdjustVal, midPoint.y + .02f, midPoint.z);

                    }
                    else
                    {
                        _egdeMessueText.transform.position = new Vector3(midPoint.x - newAdjustVal, midPoint.y, midPoint.z);

                    }
                    _egdeMessueText.GetComponent<TextMeshProUGUI>().fontSize = Mathf.Abs(midPoint.x * 20);


                }
                else if (_edgeSideR)
                {
                    float newAdjustVal = adjustValue * 2;
                    //Debug.Log(" newAdjustVal " + newAdjustVal);
                    if (_isRef)
                    {
                        _egdeMessueText.transform.position = new Vector3(midPoint.x + newAdjustVal, midPoint.y + .02f, midPoint.z);
                    }
                    else
                    {
                        _egdeMessueText.transform.position = new Vector3(midPoint.x + newAdjustVal, midPoint.y, midPoint.z);
                    }

                    _egdeMessueText.GetComponent<TextMeshProUGUI>().fontSize = Mathf.Abs(midPoint.x * 20);

                }
            }
        }
        // Set the center of the BoxCollider
        boxCollider.center = midPoint - transform.position;


        if (_iStype_1)
        {
            // p1-p3 //p7- p8 // p4- p2 // //p6- p5
            boxCollider.size = new Vector3(distance/* - .9f*/, boxCollider.size.y, boxCollider.size.z);
            // Match the collider's position and rotation
            transform.position = midPoint;
            transform.LookAt(startPoint);

            // p1-p3 //p7- p8 // p4- p2 //p6- p5
            transform.Rotate(0, 90, 0);
        }
        else if (_istype_2)
        {
            //Edge2_p3p4 //Edge2_p2p1 // Edge2_p5p7 // Edge4_p8p6
            boxCollider.size = new Vector3(boxCollider.size.x, boxCollider.size.y, distance);
            transform.position = midPoint;
            transform.LookAt(startPoint);
        }
        else if (_istype_3)
        {
            //Edge4_p1p7 // Edge4_p2p5 // Edge4_p4p6 // Edge4_p3p8
            boxCollider.size = new Vector3(boxCollider.size.x, distance, boxCollider.size.z);
            transform.position = midPoint;
            transform.LookAt(startPoint);
            transform.Rotate(90, 0, 0);

        }


    }

    public void CalculateLength()
    {
        // Calculate the distance between the two objects
        distanceInMeters = Vector3.Distance(startPoint.transform.localPosition, endPoint.transform.localPosition);

        distanceInCentimeters = distanceInMeters * 100f;
        distanceInMillimeters = distanceInMeters * 1000f;
        distanceInDecimeters = distanceInMeters * 10f;
        _egdeMessueText.GetComponent<TextMeshProUGUI>().text = distanceInMillimeters.ToString("0000") ;

        //if (GameManager.Instance._unity_cm)
        //{
        //    _egdeMessueText.GetComponent<TextMeshProUGUI>().text = distanceInCentimeters.ToString("F2") + "cm";
        //}
        //else if (GameManager.Instance._unity_mm)
        //{
        //    _egdeMessueText.GetComponent<TextMeshProUGUI>().text = distanceInMillimeters.ToString("F2") + "mm";

        //}
        //else if (GameManager.Instance._unity_m)
        //{
        //    _egdeMessueText.GetComponent<TextMeshProUGUI>().text = distanceInMeters.ToString("F2") + "M";

        //}
        //else if (GameManager.Instance._unity_dm)
        //{
        //    _egdeMessueText.GetComponent<TextMeshProUGUI>().text = distanceInMeters.ToString("F2") + "dm";

        //}



    }



    public void EdgeClick()
    {
        GameManager.Instance.CalculateAllEdges(GameManager.Instance.currentArray);
        _egdeMessueText.SetActive(true);
        if (!GameManager.Instance._currentControler.activeInHierarchy)
        {
            GameManager.Instance._currentControler.SetActive(true);
        }
        GameManager.Instance.SetKnobRotationByedge();
    }

    public void ExaminLengthAdder()
    {
        if (distanceInMeters != GetComponent<TargetEdge>()._targetEdge.distanceInCentimeters)
        {
            AddEdgeLength();
        }

    }

    public void AddEdgeLength()
    {
        _addingValue = GameManager.Instance._addingAndsubstractingValue;
        if (distanceInMeters <= _maxLimit_In_Meter)
        {
            if (_iStype_1)
            {
                if (startPoint.transform.localPosition.x < 0)
                {
                    if (_examinObject)
                    {
                        //if (!_targeLengthGet)
                        {
                            startPoint.transform.localPosition += new Vector3(-_addingValue, 0, 0);

                        }
                    }
                    else
                    {
                        startPoint.transform.localPosition += new Vector3(-_addingValue, 0, 0);
                    }
                }
                else
                {
                    if (_examinObject)
                    {
                        //if (!_targeLengthGet)
                        {
                            startPoint.transform.localPosition += new Vector3(_addingValue, 0, 0);
                        }
                    }
                    else
                    {
                        startPoint.transform.localPosition += new Vector3(_addingValue, 0, 0);

                    }



                }

                if (endPoint.transform.localPosition.x < 0)
                {
                    if (_examinObject)
                    {
                        //if (!_targeLengthGet)
                        {
                            endPoint.transform.localPosition += new Vector3(-_addingValue, 0, 0);
                        }
                    }
                    else
                    {
                        endPoint.transform.localPosition += new Vector3(-_addingValue, 0, 0);
                    }


                }
                else
                {
                    if (_examinObject)
                    {
                        //if (!_targeLengthGet)
                        {
                            endPoint.transform.localPosition += new Vector3(_addingValue, 0, 0);
                        }
                    }
                    else
                    {
                        endPoint.transform.localPosition += new Vector3(_addingValue, 0, 0);

                    }

                }
            }
            if (_istype_2)
            {
                if (startPoint.transform.localPosition.z < 0)
                {

                    startPoint.transform.localPosition += new Vector3(0, 0, -_addingValue);

                }
                else
                {

                    startPoint.transform.localPosition += new Vector3(0, 0, _addingValue);

                }

                if (endPoint.transform.localPosition.z < 0)
                {
                    endPoint.transform.localPosition += new Vector3(0, 0, -_addingValue);


                }
                else
                {
                    endPoint.transform.localPosition += new Vector3(0, 0, _addingValue);


                }
            }
            if (_istype_3)
            {
                if (startPoint.transform.localPosition.y < 0)
                {

                    startPoint.transform.localPosition += new Vector3(0, -_addingValue, 0);


                }
                else
                {

                    startPoint.transform.localPosition += new Vector3(0, _addingValue, 0);


                }

                if (endPoint.transform.localPosition.y < 0)
                {
                    endPoint.transform.localPosition += new Vector3(0, -_addingValue, 0);

                }
                else
                {
                    endPoint.transform.localPosition += new Vector3(0, _addingValue, 0);


                }
            }
            EdgeClick();

        }
        // p1p3 , p7p8 , p4p2 ,p6p5

    }

    public void SustractLength()
    {
        _addingValue = GameManager.Instance._addingAndsubstractingValue;
        if (distanceInMeters >= _minLimit_In_Meter)
        {
            if (_iStype_1)
            {
                if (startPoint.transform.localPosition.x < 0)
                {
                    startPoint.transform.localPosition += new Vector3(_addingValue, 0, 0);

                }
                else
                {
                    startPoint.transform.localPosition += new Vector3(-_addingValue, 0, 0);


                }

                if (endPoint.transform.localPosition.x < 0)
                {
                    endPoint.transform.localPosition += new Vector3(_addingValue, 0, 0);

                }
                else
                {
                    endPoint.transform.localPosition += new Vector3(-_addingValue, 0, 0);

                }
            }
            if (_istype_2)
            {
                if (startPoint.transform.localPosition.z < 0)
                {
                    startPoint.transform.localPosition += new Vector3(0, 0, _addingValue);

                }
                else
                {
                    startPoint.transform.localPosition += new Vector3(0, 0, -_addingValue);


                }

                if (endPoint.transform.localPosition.z < 0)
                {
                    endPoint.transform.localPosition += new Vector3(0, 0, _addingValue);

                }
                else
                {
                    endPoint.transform.localPosition += new Vector3(0, 0, -_addingValue);

                }
            }
            if (_istype_3)
            {
                if (startPoint.transform.localPosition.y < 0)
                {
                    startPoint.transform.localPosition += new Vector3(0, _addingValue, 0);

                }
                else
                {
                    startPoint.transform.localPosition += new Vector3(0, -_addingValue, 0);


                }

                if (endPoint.transform.localPosition.y < 0)
                {
                    endPoint.transform.localPosition += new Vector3(0, _addingValue, 0);

                }
                else
                {
                    endPoint.transform.localPosition += new Vector3(0, -_addingValue, 0);

                }
            }
            EdgeClick();
        }



    }
    public void ResetPosition()
    {
        if (_egdeMessueText.activeInHierarchy)
        {
            _egdeMessueText.SetActive(false);
        }
        SetDistance(200);
        //startPoint.position = _startpointinitialPosition;
        //endPoint.position = _endpointinitialPosition;
        _egdeMessueText.GetComponent<TextMeshProUGUI>().text = "";
        if (gameObject.GetComponent<CheckingLengthReach>() != null)
        {
            gameObject.GetComponent<CheckingLengthReach>()._edgeReached = false;
        }

        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
        currentRotationCM = 0;
        currentRotationMM = 0;
        currentRotationM = 0;
        currentRotationDM = 0;
        _knobeValueInmm = 0;
        _knobeValueIncm = 0;
        _knobeValueIndm = 0;
        _knobeValueInm = 0;
    }


    public void SetDistance(float targetDistance)

    {
        float halfLengthInMeters = targetDistance / 1000f;

        // Calculate the current midpoint between A and B
        Vector3 midpoint = (startPoint.transform.localPosition + endPoint.transform.localPosition) / 2;

        // Calculate the direction from midpoint to each point
        Vector3 direction = (endPoint.transform.localPosition - startPoint.transform.localPosition).normalized;

        // Move both A and B from the midpoint to achieve half the target distance each
        startPoint.transform.localPosition = midpoint - direction * (halfLengthInMeters / 2);
        endPoint.transform.localPosition = midpoint + direction * (halfLengthInMeters / 2);

        //Debug.Log("New position of A: " + startPoint.transform.localPosition);
        //Debug.Log("New position of B: " + endPoint.transform.localPosition);
        //Debug.Log("New distance between A and B: " + Vector3.Distance(startPoint.transform.localPosition, endPoint.transform.localPosition));
        CalculateLength();

    }
    public void HoverEnter()
    {
       GetComponent<LineRenderer>().startColor = Color.white;
       GetComponent<LineRenderer>().endColor = Color.white;
    }
    public void HoverExit()
    {
       GetComponent<LineRenderer>().startColor = Color.black;
       GetComponent<LineRenderer>().endColor = Color.black;
    }
}
