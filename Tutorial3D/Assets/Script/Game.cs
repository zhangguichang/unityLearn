using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public PlayerCtrl playerCtrl;
    void Start()
    {
        
    }

    void UpdateOperation()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        var vec3 = new Vector3(h,0,v);
        if (vec3.Equals(Vector3.zero))
        {
            playerCtrl.SetIdle();
        }
        else
        {
            playerCtrl.SetMove(vec3);
        }
    }
    
    void Update()
    {
        UpdateOperation();
    }
}
