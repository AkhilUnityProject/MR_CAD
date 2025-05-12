using UnityEngine;

public class Test_1A : State
{
    public Test_1A(StateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
        Debug.Log("Entering Test_1A");
        GameManager.Instance.UnitSelection("mm");
        GameManager.Instance.SetDialAsController();
        //GameManager.Instance._currentControler.SetActive(true);
        GameManager.Instance._examinCube.SetActive(true);
        GameManager.Instance._referemceCube.SetActive(true);
        GameManager.Instance.currentArray = GameManager.Instance._examincube._examinTestEdge;
        GameManager.Instance._refEdge_1A.GetComponent<LineDrawer>().SetDistance(GameManager.Instance._reValue_1A);
        GameManager.Instance.CalculateAllEdges(GameManager.Instance.currentArray);
        GameManager.Instance.OnDisplayAlltexts(GameManager.Instance._examincube._referenceEdge);

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
        GameManager.Instance.OffDisplayedTexts(GameManager.Instance._examincube._referenceEdge);

        GameManager.Instance.ResetAllEdges();

    }
}
