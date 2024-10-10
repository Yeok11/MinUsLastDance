using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGTexture : MonoBehaviour
{
    private void Awake()
    {
        RectTransform re = GetComponentInParent<RectTransform>();
        GetComponent<RectTransform>().sizeDelta = new Vector2(re.rect.height, re.rect.width);
    }
}
