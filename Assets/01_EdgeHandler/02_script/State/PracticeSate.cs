using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeSate : State
{
    public PracticeSate(StateMachine stateMachine) : base(stateMachine) { }
    public override void Enter()
    {
        Debug.Log("Entering Task_A_1 State");
        GameManager.Instance.currentArray = GameManager.Instance._edges;
        GameManager.Instance.UnitSelection("cm");
        GameManager.Instance._ui.SetActive(true);
        if (GameManager.Instance._practiceCube != null)
        {
            GameManager.Instance._practiceCube.SetActive(true);
        }
        GameManager.Instance.CalculateAllEdges(GameManager.Instance.currentArray);

    }


    public override void UpdateState()
    {

    }

    public override void Exit()
    {
        GameManager.Instance._practiceCube.SetActive(false);
        GameManager.Instance._ui.SetActive(false);
        GameManager.Instance.ResetAllEdges();
    }
}
