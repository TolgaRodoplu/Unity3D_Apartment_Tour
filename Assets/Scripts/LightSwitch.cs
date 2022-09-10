using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour, IInteractable 
{
    [SerializeField] Light lgth;

    bool turnedOn = false;

    string _type;
    
    public string type
    {
        get => _type;
        set => _type = value;
    }

    void Start()
    {
        type = "turn on";
    }

  
    public void Interact(Transform interactor)
    {
        lgth.enabled = !lgth.enabled;
        
        turnedOn = !turnedOn;

        if(turnedOn)
            type = "turn off";

        else
            type = "turn on";
    }
}
