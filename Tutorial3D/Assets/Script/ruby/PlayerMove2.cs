using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove2 : MonoBehaviour
{
    public Vector3 moveVec = Vector3.zero;
    public float moveSpeed;

    void Start()
    {
    }

    void Update()
    {
    }

    private void FixedUpdate()
    {
        var vec = moveVec * moveSpeed * Time.deltaTime;
        this.transform.Translate(vec);
    }
}