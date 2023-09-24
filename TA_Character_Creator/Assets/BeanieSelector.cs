using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BeanieSelector : MonoBehaviour
{
   public CharacterRenderer character;
    public Slider redSlider;    
    public Slider greenSlider;
    public Slider blueSlider;
    
    public bool currOption;
    public Color colorOption;

    void Start()
    {
        character = GameObject.FindWithTag("Shell").GetComponent<CharacterRenderer>();

        redSlider = GameObject.FindWithTag("red_slider").GetComponent<Slider>();
        greenSlider = GameObject.FindWithTag("green_slider").GetComponent<Slider>();
        blueSlider = GameObject.FindWithTag("blue_slider").GetComponent<Slider>();


        
        redSlider.value = PlayerPreferences.Instance.beanieColorChoice.r;
        greenSlider.value = PlayerPreferences.Instance.beanieColorChoice.g;
        blueSlider.value = PlayerPreferences.Instance.beanieColorChoice.b;



        currOption = PlayerPreferences.Instance.beanieChoice;
        colorOption = PlayerPreferences.Instance.beanieColorChoice;
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

        PlayerPreferences.Instance.beanieColorChoice = colorOption;
        PlayerPreferences.Instance.beanieChoice = currOption;


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
