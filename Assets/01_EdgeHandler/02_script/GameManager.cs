using TMPro;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Cube Object")]

    public GameObject _practiceCube;
    public GameObject _examinCube;
    public GameObject _referemceCube;



    public GameObject[] _edges;
    public GameObject[] _edgetexts;
    public GameObject[] currentArray;
    //public GameObject[] currentArray;
    public GameObject _currentActiveObject;
    public GameObject _uiParent;
    public GameObject _ui;
    public GameObject _taskCompleteUI;
    [HideInInspector] public bool _unity_cm;
    [HideInInspector] public bool _unity_mm;
    [HideInInspector] public bool _unity_m;
    [HideInInspector] public bool _unity_dm;

    public TextMeshProUGUI _knobeValue;
    public TextMeshPro _knobeValuefromKnob;
    public LocomotionSetup _locomotionSetup;


    [Header("Controlers")]
    public GameObject _currentControler;
    public GameObject _dial;
    public GameObject _numberPad;
    [Header("ExaminCube")]
    public ExaminBube _examincube;
    [Header("1A")]
    public GameObject _refEdge_1A;
    public float _reValue_1A;
    [Header("1B")]
    public GameObject _refEdge_1B;
    public float _reValue_1B;

    [Header("2A")]
    public GameObject _refEdge_2A;
    public float _reValue_2A;

    [Header("2B")]
    public GameObject _refEdge_2B;
    public float _reValue_2B;
    public bool _isTestState;

    private int activeIndex = -1;

    public GameObject _HomeUi;

    public XRKnob _xrKnob;
    public GameObject _sliderObject;
    public GameObject _knobeObject;
    public bool _cubePracticeState;
    public bool _cubeExaminState;
    public PrintRotation _rotationControlerObject;
    
    [HideInInspector] public float _addingAndsubstractingValue;

    public StateMachine StateMachine;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {

        //StateMachine.ChangeState(new Test_1A(StateMachine));
        StateMachine.ChangeState(new Home(StateMachine));
    }
  
    public void OnObjectClick(int index)
    {
        if (activeIndex != -1)
        {
            currentArray[activeIndex].GetComponent<LineRenderer>().endColor = Color.black;
            currentArray[activeIndex].GetComponent<LineRenderer>().startColor = Color.black;
        }

        currentArray[index].GetComponent<LineRenderer>().endColor = Color.yellow;
        currentArray[index].GetComponent<LineRenderer>().startColor = Color.yellow;

        _currentActiveObject = currentArray[index].gameObject;
        activeIndex = index;
        _currentActiveObject.GetComponent<LineDrawer>().EdgeClick();

    }

    public void Adder()
    {
        _currentActiveObject.GetComponent<LineDrawer>().AddEdgeLength();

    }

    public void substractor()
    {
        _currentActiveObject.GetComponent<LineDrawer>().SustractLength();

    }

    public void UnitSelection(string unit)
    {
        switch (unit)
        {
            case "mm":
                _addingAndsubstractingValue = 0.0005f;
                _unity_cm = false;
                _unity_mm = true;
                _unity_m = false;
                _unity_dm = false;
                if(_currentActiveObject != null)
                {
                    _xrKnob.value = _currentActiveObject.GetComponent<LineDrawer>()._knobeValueInmm;

                }
                CalculateAllEdges(currentArray);
                break;
            case "cm":
                _addingAndsubstractingValue = 0.005f;
                _unity_cm = true;
                _unity_mm = false;
                _unity_m = false;
                _unity_dm = false;
                if (_currentActiveObject != null)
                    _xrKnob.value = _currentActiveObject.GetComponent<LineDrawer>()._knobeValueIncm;
                CalculateAllEdges(currentArray);
                break;
            case "m":
                _addingAndsubstractingValue = 0.5f;
                _unity_cm = false;
                _unity_mm = false;
                _unity_m = true;
                _unity_dm = false;
                if (_currentActiveObject != null)
                    _xrKnob.value = _currentActiveObject.GetComponent<LineDrawer>()._knobeValueInm;
                CalculateAllEdges(currentArray);
                break;
            case "dm":
                _addingAndsubstractingValue = 0.05f;
                _unity_cm = false;
                _unity_mm = false;
                _unity_dm = true;
                _unity_m = false;
                if (_currentActiveObject != null)
                    _xrKnob.value = _currentActiveObject.GetComponent<LineDrawer>()._knobeValueIndm;
                CalculateAllEdges(currentArray);
                break;
            default:
                // Handle the case where 'unit' is not recognized, if needed
                break;
        }
    }

    public void CalculateAllEdges(GameObject[] _arrayCalcualte)
    {
        foreach (var edge in _arrayCalcualte)
        {
            edge.GetComponent<LineDrawer>().CalculateLength();
        }
    }

    public void ResetAllEdges()
    {
        foreach (var edge in currentArray)
        {
            edge.GetComponent<LineDrawer>().ResetPosition();
        }
        activeIndex = -1;
        foreach (var edge in _examincube._referenceEdge)
        {
            edge.GetComponent<LineDrawer>().ResetPosition();
        }
    }
    public void CheckAlledgesPosition()
    {
        bool allEdgesReached = true;

        foreach (var edge in currentArray)
        {
            if (!edge.GetComponent<CheckingLengthReach>()._edgeReached)
            {
                allEdgesReached = false;
                break;
            }
        }

        if (allEdgesReached)
        {
            Debug.Log("All edges have been reached.");
            //_currentControler.SetActive(false);
            //_taskCompleteUI.SetActive(true);
        }
        else
        {

            //Debug.Log("Not all edges have been reached.");
        }
    }

    public void HomeButton()
    {
        StateMachine.ChangeState(new Home(StateMachine));

    }


    public void ChangeToCubePracticeState()
    {
        StateMachine.ChangeState(new PracticeSate(StateMachine));

    }

    public void ChangeToexaminCube()
    {
        StateMachine.ChangeState(new CubeExamin(StateMachine));

    }

    public void SetDialAsController()
    {
        if (_currentControler != null)
        {
            _currentControler = null;
        }
        _currentControler = _dial;
    }
    public void SetKeyPadAsController()
    {
        if (_currentControler != null)
        {
            _currentControler = null;
        }
        _currentControler = _numberPad;
    }
    public void OnDisplayAlltexts(GameObject[] _arrayDisplaytexts)
    {
        foreach (var obj in _arrayDisplaytexts)
        {
            obj.GetComponent<LineDrawer>().CalculateLength();
            obj.GetComponent<LineDrawer>()._egdeMessueText.gameObject.SetActive(true);
        }
    }
    public void OffDisplayedTexts(GameObject[] _arrayDisplaytexts)
    {
        foreach (var obj in _arrayDisplaytexts)
        {
            obj.GetComponent<LineDrawer>()._egdeMessueText.gameObject.SetActive(false);
        }
    }

    public void StateSlection(int stateIndex)
    {
        switch (stateIndex)
        {
            case 0:
                StateMachine.ChangeState(new Home(StateMachine));
                break;
            case 1:
                StateMachine.ChangeState(new Test_1A(StateMachine));
                break;
            case 2:
                StateMachine.ChangeState(new Test_1B(StateMachine));
                break;
            case 3:
                StateMachine.ChangeState(new Test_2A(StateMachine));
                break;
            case 4:
                StateMachine.ChangeState(new Test_2B(StateMachine));
                break;

        }
    }
    public void SetKnobRotationByedge()
    {
        if (_unity_cm)
        {
          UnitSelection("cm");
        }
        else if (_unity_mm)
        {
            UnitSelection("mm");

        }
        else if (_unity_dm)
        {
            UnitSelection("dm");

        }
        else if (_unity_m)
        {
            UnitSelection("m");

        }

    }
    public void ResetKnobeValues()
    {
        foreach (var edge in currentArray)
        {
            edge.GetComponent<LineDrawer>().ResetPosition();
        }
    }
}
