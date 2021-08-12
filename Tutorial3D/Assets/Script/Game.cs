using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using System;

public class Game : MonoBehaviour
{
    public PlayerCtrl playerCtrl;

    public Map map;
    public GameObject bulletPool;
    

    private List<GameObject> heaths = new List<GameObject>();
    private List<Bullet> bullets = new List<Bullet>();

    public float generatedt;
    private float _generateTime;


    private static Game _Instance;
    public static Game Instance => _Instance;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        _Instance = this;
    }

    void Start()
    {
    }

    public List<Bullet> GETBullets()
    {
        return this.bullets;
    }

    void UpdateOperation()
    {
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        var space = Input.GetKeyDown(KeyCode.Space);
        var vec3 = new Vector3(h, v, 0);
        if (playerCtrl.state != PlayerCtrl.EnumPlayerState.dead)
        {
            if (vec3.Equals(Vector3.zero))
            {
                playerCtrl.SetIdle();
            }
            else
            {
                playerCtrl.SetMove(vec3);
            }

            if (space)
            {
                playerCtrl.Shoot();
            }
        }
    }


    void UpdateGenerateHealth()
    {
        if (_generateTime >= generatedt)
        {
            if (playerCtrl.state != PlayerCtrl.EnumPlayerState.dead)
            {
                var random =new System.Random();
                var count = random.Next(3);
                for (int i = 0; i < count; i++)
                {
                    var obj = Resources.Load("Prefabs/CollectibleHealth");
                    var gameObj =(GameObject) Instantiate(obj, this.map.transform);
                    var vec = new Vector3(random.Next(-4,4),random.Next(-6,0),0);
                    gameObj.transform.position = vec;
                    heaths.Add(gameObj);
                }
            }
            _generateTime = 0;
        }
        else
        {
            _generateTime += Time.deltaTime;
        }
       
    }

    public void clearHealt(GameObject obj)
    {
        heaths.Remove(obj);
        Destroy(obj);
    }


    public void clearBullet(Bullet obj)
    {
        bullets.Remove(obj);
        Destroy(obj.gameObject);
    }

    void Update()
    {
        UpdateOperation();
        UpdateGenerateHealth();
    }
}