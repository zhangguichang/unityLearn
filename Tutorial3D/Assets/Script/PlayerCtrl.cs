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
        public float shootCd;
        private float _currshootCd;
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

        public float GetShootCd()
        {
            return _currshootCd;
        }

        public void SetShootCd(float cd)
        {
            _currshootCd = cd;
        }
        
        
    }
    public PlayerData playerData;
    
    
    public enum EnumPlayerState
    {
        idle,
        move,
        dead,
        shoot,
        shootMove
    }
    
    public EnumPlayerState state;

    private Vector2 lookDir = Vector2.down;

    private PlayerMove2 moveCtrl;
    private Animator _animator;
    void Start()
    {
        moveCtrl = GetComponent<PlayerMove2>();
        _animator = GetComponent<Animator>();
    }

    public void SetIdle()
    {
        state = EnumPlayerState.idle;
        moveCtrl.moveVec = Vector3.zero;
        _animator.SetBool("isMove",false);
        _animator.SetFloat("LookX",lookDir.x);
        _animator.SetFloat("LookY",lookDir.y);
    }
    
    public void SetMove(Vector3 vector3)
    {
        state = EnumPlayerState.move;
        moveCtrl.moveVec = vector3;
        moveCtrl.moveSpeed = playerData.moveSpeed;
        _animator.SetBool("isMove",true);
        _animator.SetFloat("MoveX",vector3.x);
        _animator.SetFloat("MoveY",vector3.y);
        lookDir.x = vector3.x;
        lookDir.y = vector3.y;
    }

    public void SetDead()
    {
        // state = EnumPlayerState.dead;
        // playerData.setCurrHp(0);
        Debug.Log("死了!");
    }

    public void Shoot()
    {
        if (this.state == EnumPlayerState.move)
        {
            this.state = EnumPlayerState.shootMove;
        }
        else
        {
            this.state = EnumPlayerState.shoot;
        }

        if (playerData.GetShootCd() == 0)
        {
            var obj = Resources.Load("Prefabs/CogBullet");
            var gameobj =(GameObject) Instantiate(obj,Game.Instance.bulletPool.transform);
            gameobj.transform.position = this.transform.position;
            var bullet = gameobj.GetComponent<Bullet>();
            bullet.SetData(lookDir,10);
            var list = Game.Instance.GETBullets();
            list.Add(bullet);
        }
        else
        {
            var cd = playerData.GetShootCd() + Time.deltaTime;
            if (cd >= playerData.shootCd)
            {
                playerData.SetShootCd(0);
            }
            else
            {
                playerData.SetShootCd(cd);
            }
        }
        
    }
    public void SetHp(float hp)
    {
        playerData.setCurrHp(hp);
        var currHp = playerData.getCurrHp();
        if (currHp <= 0)
        {
            SetDead();
        }
        var radio = currHp / playerData.maxHp;
        UIHealthBar.Instance.SetProgress(radio);
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
