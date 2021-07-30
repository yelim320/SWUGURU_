using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Experimental.Rendering.LWRP;

public class light
{
    private Light light2D;
    public enum ItemType
    {
        Light
    }

    private void Awake()
    {
        //light2D = GetComponent<Light>();
    }
    public ItemType itemType;
    public Color GetColor()
    {
        switch (itemType)
        {
            default:
            case ItemType.Light: return new Color(0, 0, 0);
        }
    }
}
