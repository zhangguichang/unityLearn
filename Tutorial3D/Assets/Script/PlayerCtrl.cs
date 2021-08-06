using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public enum EnumPlayerState
    {
        idle,
        move
    }
    
    public EnumPlayerState state;


    private PlayerMove moveCtrl;
    void Start()
    {
        moveCtrl = GetComponent<PlayerMove>();
    }

    public void SetIdle()
    {
        state = EnumPlayerState.idle;
        moveCtrl.moveVec = Vector3.zero;
    }
    
    public void SetMove(Vector3 vector3)
    {
        state = EnumPlayerState.move;
        moveCtrl.moveVec = vector3;
    }
    
    // Update is called once per frame
    void Update()
    {
      
    }
}
