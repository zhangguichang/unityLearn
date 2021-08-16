using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class CollectibleHealth : MonoBehaviour
{
    // Start is called before the first frame update

    public enum EnumHurtType
    {
        Add,
        Reduce
    }

    public EnumHurtType HurtType;

    public List<int> HurtNums;
    public List<int> AddtNums;
    void Start()
    {
        var random = new Random();
        var value = random.Next(0,2);
        HurtType = (EnumHurtType) value;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private int GetHurt()
    {
        var hurt = 0;
        var random = new Random();
        var list = HurtType == EnumHurtType.Add ? AddtNums : HurtNums;
        var (min, max) = (list[0], list[1]);
        hurt = random.Next(min, max);
        return hurt;
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.transform.GetComponent<PlayerCtrl>();
        if (player != null)
        {
            var hurt = GetHurt();
            if (HurtType == EnumHurtType.Add)
            {
                hurt += (int)player.playerData.getCurrHp();
                Debug.Log($"添加血量{hurt}");
            }
            else
            {
                hurt = (int) player.playerData.getCurrHp() - hurt;
                Debug.Log($"减少血量{hurt}");
            }
            player.SetHp(hurt);
            Game.Instance.clearHealt(this.gameObject);
        }
    }
}
