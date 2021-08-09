using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [Serializable]
    public class PlayerData
    {
        public float moveSpeed;
        private float _currHp;
        public float maxHp;

        public void Init()
        {
            _currHp = maxHp;
        }
        /// <summary>
        /// 设置当前血量
        /// </summary>
        /// <param name="hp"></param>
        public void setCurrHp(float hp)
        {
            _currHp = Mathf.Clamp(hp, 0, maxHp);
        }
        /// <summary>
        /// 获取当前血量
        /// </summary>
        /// <returns></returns>
        public float getCurrHp()
        {
            return _currHp;
        }
    }
    public PlayerData playerData;
    
    
    public enum EnumPlayerState
    {
        idle,
        move,
        dead
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
        moveCtrl.moveSpeed = playerData.moveSpeed;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
