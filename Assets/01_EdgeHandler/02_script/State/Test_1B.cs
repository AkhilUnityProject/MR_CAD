using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_1B : State
{
    public Test_1B(StateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Entering Test_1B");
        GameManager.Instance.UnitSelection("mm");
        GameManager.Instance.SetDialAsController();
        //GameManager.Instance._currentControler.SetActive(true);
        GameManager.Instance._referemceCube.SetActive(true);
        GameManager.Instance._examinCube.SetActive(true);
        GameManager.Instance._referemceCube.SetActive(true);
        GameManager.Instance.currentArray = GameManager.Instance._examincube._examinTestEdge;
        GameManager.Instance._refEdge_1B.GetComponent<LineDrawer>().SetDistance(GameManager.Instance._reValue_1B);
        GameManager.Instance.CalculateAllEdges(GameManager.Instance._examincube._referenceEdge);
        //GameManager.Instance.OnDisplayAlltexts(GameManager.Instance._examincube._referenceEdge);
        GameManager.Instance.CalculateAllEdges(GameManager.Instance.currentArray);


    }


    public override void UpdateState()
    {
        GameManager.Instance.CheckAlledgesPosition();
    }

    public override void Exit()
    {
        GameManager.Instance._examinCube.SetActive(false);
        GameManager.Instance._referemceCube.SetActive(false);
        GameManager.Instance._referemceCube.SetActive(false);
        GameManager.Instance._currentControler.SetActive(false);

        GameManager.Instance.ResetAllEdges();

    }
}
