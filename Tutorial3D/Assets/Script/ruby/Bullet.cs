using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Vector3 _dir = Vector3.zero;

    private float _speed=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateMove();
    }

    public void SetData(Vector3 dir,float speed)
    {
        _speed = speed;
        _dir = dir;
        // var angel = Mathf.Atan(dir.y / dir.x);
        this.transform.rotation = Quaternion.Euler(dir.x, dir.y, 0);
    }
    public void UpdateMove()
    {
        var vec =new Vector3(_dir.x*_speed*Time.deltaTime,_dir.y*_speed*Time.deltaTime,0);
        this.transform.Translate(vec);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var name = other.transform.gameObject.name;
        if (name == "player") return;
        switch (name)
        {
            case "CollectibleHealth(Clone)":
                Destroy(other.transform.gameObject);
                 break;
        }
        Game.Instance.clearBullet(this);
    }
}
