using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventSystem : MonoBehaviour
{
    public static EventSystem instance;
    public event Action roamMode;
    public event EventHandler<Vector3> colorMode, colorUpdated;

    private void Awake()
    {
        instance = this;
    }

   

    public void RoamMode()
    {
        Debug.Log("RoamMode");
        roamMode?.Invoke();
    }

    public void ColorMode(Vector3 rgb)
    {
        colorMode?.Invoke(this, rgb);
        Debug.Log("ColorMode");
    }

    public void ColorUpdated(Vector3 rgb)
    {
        colorUpdated?.Invoke(this, rgb);
        Debug.Log("ColorUpdate");
    }
}

