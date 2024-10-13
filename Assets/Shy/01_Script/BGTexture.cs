using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGTexture : MonoBehaviour
{
    private void Awake()
    {
        RectTransform re = transform.parent.GetComponent<RectTransform>();
        Debug.Log(re);
        GetComponent<RectTransform>().sizeDelta = new Vector2(re.rect.height, re.rect.width);
    }
}
