using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Crosshair : MonoBehaviour
{
    TextMeshProUGUI crosshairText;
    
    void Start()
    {
        crosshairText = gameObject.GetComponent<TextMeshProUGUI>();
        EventSystem.instance.crosshairUpdated += UpdateCrosshairText;
        crosshairText.text = "";
    }

    public void UpdateCrosshairText(object sender, string type)
    {
        if(!Input.GetKey(KeyCode.Mouse0) && !type.Equals("Untagged"))
            crosshairText.text = type;
        
        else    
            crosshairText.text = null;
    }

    
    

}
