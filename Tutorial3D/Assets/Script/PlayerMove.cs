using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Vector3 moveVec =Vector3.zero;
    public float moveSpeed;
    void Start()
    {
        
    }
    void Update()
    {
        var vec = moveVec * moveSpeed * Time.deltaTime;
        this.transform.Translate(vec);
    }
}
