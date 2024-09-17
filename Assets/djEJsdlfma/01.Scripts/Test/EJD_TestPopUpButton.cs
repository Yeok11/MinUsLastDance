using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_TestPopUpButton : MonoBehaviour
{
    private EJD_ShowLog _testPopUp;

    [SerializeField] private GameObject _popup;

    private void Awake()
    {
        _testPopUp = GameObject.Find("EncounterPopUp").GetComponent<EJD_ShowLog>();
        _popup = GameObject.FindWithTag("PopUp");
    }

    public void YesButton()
    {
        _popup.SetActive(false);
        Debug.Log("����");
        //��� ¥�󤿤�
    }

    public void NoButton()
    {
        _popup.SetActive(false);
        Debug.Log("����");
        //�׳� �ݴ°�
    }
    

    public void OnMouseDown()
    {

        if (gameObject.name == "0") YesButton();
        else if (gameObject.name == "1") NoButton();
    }
}
