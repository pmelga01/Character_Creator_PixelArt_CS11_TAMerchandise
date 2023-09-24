

/*
 * This is the SETTER of the SINGLETON values
 *
 *
 *
 *
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCreationMenu : MonoBehaviour
{
    
    public CharacterRenderer character;
    // public OptionChanger hair;
    
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindWithTag("Shell").GetComponent<CharacterRenderer>();    }

    void Update()
    {

    }
    
    public void updateArtChoice()
    {
        // PlayerPreferences.Instance.eyeColorChoice = 0;
        // PlayerPreferences.Instance.hairStyleChoice = 0;
        // PlayerPreferences.Instance.hairColorChoice = 0;
        // PlayerPreferences.Instance.shirtStyleChoice = 0;
        // PlayerPreferences.Instance.accessoryChoice = 0;
        
       
       character.updateCharacterArt();
    }
    
    
    // public void RandomizeCharacter()
    // {
    //     foreach(OutfitChanger changer in outfitChangers) {
    //         changer.Randomize();
    //     }
        
    //     updateArtChoice();
    // }
    
}


