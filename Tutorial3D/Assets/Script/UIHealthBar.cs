using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{

    public static UIHealthBar Instance { get;private set; }
    
    public Image mask;

    private Rect maskRect;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        maskRect = mask.rectTransform.rect;
    }


    public void SetProgress(float value)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,maskRect.width*value);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
