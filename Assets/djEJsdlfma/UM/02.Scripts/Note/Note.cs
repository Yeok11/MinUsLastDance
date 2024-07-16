using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private void Update()
    {
        gameObject.transform.position += Vector3.left * Time.deltaTime;
    }
}
