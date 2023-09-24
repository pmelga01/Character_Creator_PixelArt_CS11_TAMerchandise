using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SkinSelector : MonoBehaviour
{
    private Color defaultColor;
    public CharacterRenderer character;

    public Slider redSlider;    
    public Slider greenSlider;
    public Slider blueSlider;
    public Slider alphaSlider;

    public Color currOption = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    
    void Start()
    {
        character = GameObject.FindWithTag("Shell").GetComponent<CharacterRenderer>();

        redSlider = GameObject.FindWithTag("red_slider").GetComponent<Slider>();
        greenSlider = GameObject.FindWithTag("green_slider").GetComponent<Slider>();
        blueSlider = GameObject.FindWithTag("blue_slider").GetComponent<Slider>();
        alphaSlider = GameObject.FindWithTag("alpha_slider").GetComponent<Slider>();


        redSlider.value = PlayerPreferences.Instance.skinColorChoice.r;
        greenSlider.value = PlayerPreferences.Instance.skinColorChoice.g;
        blueSlider.value = PlayerPreferences.Instance.skinColorChoice.b;
        alphaSlider.value = PlayerPreferences.Instance.skinColorChoice.a;



        currOption = PlayerPreferences.Instance.skinColorChoice;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI() {
        changeColor();
    }

    
    
    public void changeColor()
    {
        currOption.r = redSlider.value;
        currOption.g = greenSlider.value;
        currOption.b = blueSlider.value;
        currOption.a = alphaSlider.value;

        PlayerPreferences.Instance.skinColorChoice = currOption;

        character.updateCharacterArt();
    }
    
}
