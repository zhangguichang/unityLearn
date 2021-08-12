using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    public Tilemap _tilemap;
    void Start()
    {
        
    }

    
    public Vector3 GetMapSize()
    {
        var size =_tilemap.size;
        var d = _tilemap.cellSize;
        var vec = new Vector3(size.x * d.x, size.y * d.y, 0);
        return vec;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
