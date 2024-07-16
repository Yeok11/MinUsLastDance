using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    public Vector2 moveDir;

    private Rigidbody2D rigid;
    private float speed = 8f;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        GetMove();
    }

    public void GetMove()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(h, v);
    }

    private void FixedUpdate()
    {
        rigid.velocity = moveDir.normalized * speed;
    }
}
