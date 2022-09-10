using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorable : MonoBehaviour,IInteractable
{
    bool coloring;
    Material mat;
    Vector3 matColor;

    string _type;
    
    public string type
    {
        get => _type;
        set => _type = value;
    }

    private void Start()
    {
        mat = this.gameObject.GetComponent<MeshRenderer>().material;
        matColor = new Vector3(mat.color.r * 255, mat.color.g * 255, mat.color.b * 255);
  
        type = "recolor";
    }

    public void Interact(Transform interactor)
    {
        EventSystem.instance.colorUpdated += ChangeColor;
        EventSystem.instance.roamMode += EndColoring;
        EventSystem.instance.ColorMode(matColor);
    }

    private void ChangeColor(object sender, Vector3 rgb)
    {
        
        mat.color = new Color(rgb.x / 255, rgb.y / 255, rgb.z / 255, mat.color.a);
        matColor = new Vector3(mat.color.r * 255, mat.color.g * 255, mat.color.b * 255);

    }

    private void EndColoring()
    {
        EventSystem.instance.colorUpdated -= ChangeColor;
        EventSystem.instance.roamMode -= EndColoring;
    }
}
