using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GlassesChanger : MonoBehaviour
{
    public CharacterRenderer character;
    public Slider redSlider;    
    public Slider greenSlider;
    public Slider blueSlider;

    public Toggle glassesToggle;
    
    public bool currOption;
    public Color colorOption;

    void Start()
    {
        character = GameObject.FindWithTag("Shell").GetComponent<CharacterRenderer>();

        redSlider = GameObject.FindWithTag("red_slider").GetComponent<Slider>();
        greenSlider = GameObject.FindWithTag("green_slider").GetComponent<Slider>();
        blueSlider = GameObject.FindWithTag("blue_slider").GetComponent<Slider>();

        
        redSlider.value = PlayerPreferences.Instance.glassesColorChoice.r;
        greenSlider.value = PlayerPreferences.Instance.glassesColorChoice.g;
        blueSlider.value = PlayerPreferences.Instance.glassesColorChoice.b;



        currOption = PlayerPreferences.Instance.glassesChoice;
        colorOption = PlayerPreferences.Instance.glassesColorChoice;
        character.updateCharacterArt();
    }

    void Update()
    {
        
    }


    public void changeColor()
    {
        colorOption.r = redSlider.value;
        colorOption.g = greenSlider.value;
        colorOption.b = blueSlider.value;

        PlayerPreferences.Instance.glassesColorChoice = colorOption;
        PlayerPreferences.Instance.glassesChoice = currOption;


        character.updateCharacterArt();
    }

    void OnGUI() {
        changeColor();
    }
    
    public void NextOption()
    {
        currOption = !currOption;
        
        
        // if (currOption >= character.shirts.Count) {
        //     currOption = 0;
        // } 
        
        //character.isolateSingleShirt(currOption);
        changeColor();

    }

    public void PreviousOption()
    {
        currOption = !currOption;
        
        // if (currOption < 0) {
        //     currOption = character.shirts.Count - 1;
        // }
        
        //character.isolateSingleShirt(currOption);
        changeColor();
    }

}
