using UnityEngine;

public class Home : State
{
    public Home(StateMachine stateMachine) : base(stateMachine) { }


    public override void Enter()
    {
        Debug.Log("Home Enter");
        GameManager.Instance._HomeUi.SetActive(true);
        if (GameManager.Instance._taskCompleteUI.activeInHierarchy)
        {
            GameManager.Instance._taskCompleteUI.SetActive(false);
        }
        GameManager.Instance._xrKnob.value = 0;
        //GameManager.Instance.ResetKnobeValues();
        GameManager.Instance._sliderObject.transform.localPosition = new Vector3(0,0,-0.09f);
        GameManager.Instance._knobeObject.transform.localPosition = new Vector3(0,0,0f);
    }


    public override void UpdateState()
    {

    }

    public override void Exit()
    {
        GameManager.Instance._HomeUi.SetActive(false);

    }
}
