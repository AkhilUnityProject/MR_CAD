using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExamin : State
{
    public CubeExamin(StateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Entering Task_A_1 State");
        GameManager.Instance.UnitSelection("cm");
        GameManager.Instance._examinCube.SetActive(true);
        GameManager.Instance._referemceCube.SetActive(true);
        GameManager.Instance._ui.SetActive(true);
        GameManager.Instance.currentArray = GameManager.Instance._examincube._examinTestEdge;
        GameManager.Instance.CalculateAllEdges(GameManager.Instance._examincube._referenceEdge);
        GameManager.Instance.CalculateAllEdges(GameManager.Instance.currentArray);

        GameManager.Instance._examincube.PrintEdgeLength();
    }


    public override void UpdateState()
    {
        GameManager.Instance.CheckAlledgesPosition();
    }

    public override void Exit()
    {
        GameManager.Instance._examinCube.SetActive(false);
        GameManager.Instance._referemceCube.SetActive(false);
        GameManager.Instance.ResetAllEdges();

    }
}
