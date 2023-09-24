using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShirtChanger : MonoBehaviour
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


        redSlider.value = PlayerPreferences.Instance.shirtColorChoice.r;
        greenSlider.value = PlayerPreferences.Instance.shirtColorChoice.g;
        blueSlider.value = PlayerPreferences.Instance.shirtColorChoice.b;



        currOption = PlayerPreferences.Instance.shirtStyleChoice;
        colorOption = PlayerPreferences.Instance.shirtColorChoice;
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

        PlayerPreferences.Instance.shirtColorChoice = colorOption;
        PlayerPreferences.Instance.shirtStyleChoice = currOption;


        character.updateCharacterArt();
    }

    void OnGUI() {
        changeColor();
    }
    
    public void NextOption()
    {
        currOption++;
        
        
        if (currOption >= character.shirts.Count) {
            currOption = 0;
        } 
        
        character.isolateSingleShirt(currOption);
        changeColor();

    }

    public void PreviousOption()
    {
        currOption--;
        
        if (currOption < 0) {
            currOption = character.shirts.Count - 1;
        }
        
        character.isolateSingleShirt(currOption);
        changeColor();
    }

}
