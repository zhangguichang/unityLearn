using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;
    void Awake()
    {
        
    }

    void Update()
    {
        
    }

    private void LateUpdate()
    {
        this.transform.LookAt(target);
    }
}
