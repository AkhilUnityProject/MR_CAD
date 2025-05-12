using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_2B : State
{
    public Test_2B(StateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Entering Test_1B");
        GameManager.Instance.UnitSelection("mm");
        GameManager.Instance.SetKeyPadAsController();
        GameManager.Instance._examinCube.SetActive(true);
        GameManager.Instance._referemceCube.SetActive(true);
        GameManager.Instance.currentArray = GameManager.Instance._examincube._examinTestEdge;
        GameManager.Instance.CalculateAllEdges(GameManager.Instance._examincube._referenceEdge);
        GameManager.Instance.CalculateAllEdges(GameManager.Instance.currentArray);
        //GameManager.Instance.OnDisplayAlltexts(GameManager.Instance._examincube._referenceEdge);
        GameManager.Instance._refEdge_2B.GetComponent<LineDrawer>().SetDistance(GameManager.Instance._reValue_2B);


    }


    public override void UpdateState()
    {
        GameManager.Instance.CheckAlledgesPosition();
    }

    public override void Exit()
    {
        GameManager.Instance._examinCube.SetActive(false);
        GameManager.Instance._referemceCube.SetActive(false);
        GameManager.Instance._currentControler.SetActive(false);

        GameManager.Instance.ResetAllEdges();

    }
}
