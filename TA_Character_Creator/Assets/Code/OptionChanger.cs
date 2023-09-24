using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OptionChanger : MonoBehaviour
{
    public CharacterRenderer character;
    public Slider redSlider;    
    public Slider greenSlider;
    public Slider blueSlider;
    
    public int currOption;
    public Color colorOption;

    void Start()
    {
        character = GameObject.FindWithTag("Shell").GetComponent<CharacterRenderer>();

        redSlider = GameObject.FindWithTag("red_slider").GetComponent<Slider>();
        greenSlider = GameObject.FindWithTag("green_slider").GetComponent<Slider>();
        blueSlider = GameObject.FindWithTag("blue_slider").GetComponent<Slider>();


        redSlider.value = PlayerPreferences.Instance.hairColorChoice.r;
        greenSlider.value = PlayerPreferences.Instance.hairColorChoice.g;
        blueSlider.value = PlayerPreferences.Instance.hairColorChoice.b;



        currOption = PlayerPreferences.Instance.hairStyleChoice;
        colorOption = PlayerPreferences.Instance.hairColorChoice;
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

        PlayerPreferences.Instance.hairColorChoice = colorOption;
        PlayerPreferences.Instance.hairStyleChoice = currOption;


        character.updateCharacterArt();
    }

    void OnGUI() {
        changeColor();
    }
    
    public void NextOption()
    {
        currOption++;
        
        
        if (currOption >= character.hairs.Count) {
            currOption = 0;
        } 
        
        character.isolateSingle(currOption);
        changeColor();

    }

    public void PreviousOption()
    {
        currOption--;
        
        if (currOption < 0) {
            currOption = character.hairs.Count - 1;
        }
        
        character.isolateSingle(currOption);
        changeColor();
    }

}
