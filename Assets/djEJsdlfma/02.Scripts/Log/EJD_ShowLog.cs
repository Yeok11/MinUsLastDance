using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EJD_ShowLog : MonoBehaviour
{
    private EJD_ShowEncounter _showEncounter;

    [SerializeField] public GameObject testEncounter;

    string s;

    private void Awake()
    {
        _showEncounter = GetComponent<EJD_ShowEncounter>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        testEncounter.SetActive(true);
        Debug.Log($"{other.tag}");
        _showEncounter.Show(other.tag);

        _showEncounter.LogManage(s);
    }

}