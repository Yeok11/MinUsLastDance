using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class a_Player : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    private bool playerClick = false;
    private Camera _mainCamera;
    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 _worldPosition = _mainCamera.ScreenToWorldPoint(new Vector3(eventData.position.x, eventData.position.y, _mainCamera.nearClipPlane));
        transform.position = new Vector3(_worldPosition.x, _worldPosition.y, 0);

    }
    public void OnEndDrag(PointerEventData eventData)
    {
        playerClick = false;
        Transform _findGreenImage = FindGreenImage();
        transform.position = _findGreenImage.position;
        a_PlayerMove.instance.PlayerMoveToDrag(_findGreenImage);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        a_PlayerMove.instance.CheckCanMove();
        playerClick = true;
    }
    private Transform FindGreenImage()
    {
        Transform _closeObject = null;
        float _closeDistance = Mathf.Infinity;

        foreach (Image img in GameObject.FindObjectsOfType<Image>())
        {
            if (img.color == Color.green)
            {
                float distance = Vector3.Distance(transform.position, img.transform.position);
                if (distance < _closeDistance)
                {
                    _closeDistance = distance;
                    _closeObject = img.transform;
                }
            }
        }

        return _closeObject;
    }
}

