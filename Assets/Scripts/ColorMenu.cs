using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorMenu : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    [SerializeField] Slider sliderRed, sliderGreen, sliderBlue;
    [SerializeField] TMP_InputField inputRed, inputGreen, inputBlue;
    Vector3 matRGB;

    private void Start()
    {
        EventSystem.instance.colorMode += ActivateMenu;
        EventSystem.instance.roamMode += DeactivateMenu;
    }


    private void Initilize(Vector3 rgb)
    {
        matRGB = rgb;
        UpdateSliders(rgb);
        UpdateInputFields(rgb);
    }

    private void UpdateColor()
    {
        
        
        EventSystem.instance.ColorUpdated(matRGB);
    }

    public void OnSliderChange()
    {
        Vector3 rgb = new Vector3(sliderRed.value, sliderGreen.value, sliderBlue.value);
        UpdateInputFields(rgb);
        UpdateRGB(rgb);
    }

    public void OnInputChange()
    {
        inputRed.text = CheckInput(inputRed.text);
        inputGreen.text = CheckInput(inputGreen.text);
        inputBlue.text = CheckInput(inputBlue.text);

        Vector3 rgb = new Vector3(float.Parse(inputRed.text), float.Parse(inputGreen.text), float.Parse(inputBlue.text));

        UpdateSliders(rgb);
        UpdateRGB(rgb);

    }

    private void UpdateSliders(Vector3 rgb)
    {
        sliderRed.value = rgb.x;
        sliderGreen.value = rgb.y;
        sliderBlue.value = rgb.z;
    }

    private void UpdateInputFields(Vector3 rgb)
    {
        inputRed.text = rgb.x.ToString();
        inputGreen.text = rgb.y.ToString();
        inputBlue.text = rgb.z.ToString();
    }

    private void UpdateRGB(Vector3 rgb)
    {
        matRGB.x = rgb.x;
        matRGB.y = rgb.y;
        matRGB.z = rgb.z;
        UpdateColor();
    }

    private string CheckInput(string s)
    {
        if (s.Equals(""))
            return "0";

        float x = float.Parse(s);

        if (x < 0f )
            return "0";

        if (x > 255f)
            return "225";

        else
            return s;

    }

    private void ActivateMenu(object sender, Vector3 rgb)
    {
        Debug.Log("MenuUpdated");
        Menu.SetActive(true);
        Initilize(rgb);
    }

    private void DeactivateMenu()
    {
        Menu.SetActive(false);
    }

    public void ApplyButton()
    {
        EventSystem.instance.RoamMode();
    }
}
