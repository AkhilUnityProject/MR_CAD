using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelection : MonoBehaviour
{
    public GameObject _text_M;
    public GameObject _text_dM;
    public GameObject _text_cM;
    public GameObject _text_mM;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "mm")
        {
            GameManager.Instance.UnitSelection("mm");
            _text_M.SetActive(false);
            _text_dM.SetActive(false);
            _text_cM.SetActive(false);
            _text_mM.SetActive(true);

        }
        else if (other.tag == "cm")
        {
            GameManager.Instance.UnitSelection("cm");
            _text_M.SetActive(false);
            _text_dM.SetActive(false);
            _text_cM.SetActive(true);
            _text_mM.SetActive(false);
        }
        else if (other.tag == "dm")
        {
            GameManager.Instance.UnitSelection("dm");
            _text_M.SetActive(false);
            _text_dM.SetActive(true);
            _text_cM.SetActive(false);
            _text_mM.SetActive(false);
        }
        else if (other.tag == "m")
        {
            GameManager.Instance.UnitSelection("m");
            _text_M.SetActive(true);
            _text_dM.SetActive(false);
            _text_cM.SetActive(false);
            _text_mM.SetActive(false);
        }
    }
}
