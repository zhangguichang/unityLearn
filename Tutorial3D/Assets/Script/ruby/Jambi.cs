using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jambi : MonoBehaviour
{
    public GameObject dialog;
    private float _displayTime = 0;
    void Start()
    {
        
    }
    
    public void DisplayDialog(float display=4f)
    {
        _displayTime = display;
        dialog.SetActive(true);
    }
    void Update()
    {
        if (_displayTime > 0)
        {
            _displayTime -= Time.deltaTime;
            if (_displayTime <= 0)
            {
                dialog.SetActive(false);
            }
        }
        
    }
}
