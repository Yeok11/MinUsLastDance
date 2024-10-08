using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shy_Event_SelectItem : MonoBehaviour, IPointerDownHandler
{
    internal Shy_Event_Select ses;

    public void OnPointerDown(PointerEventData eventData)
    {
        ses.ShowData(transform.GetSiblingIndex());
    }
}
