using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPreferences : MonoBehaviour
{
   public static PlayerPreferences Instance { get; private set; } 

   /* Player Art Choices */
   public Color skinColorChoice = new Color(1.0f, 1.0f, 1.0f, 1.0f);
   public Color eyeColorChoice = new Color(1.0f, 1.0f, 1.0f, 1.0f);

   public int hairStyleChoice = 0;
   public Color hairColorChoice = new Color(1.0f, 1.0f, 1.0f, 1.0f);

   public int shirtStyleChoice = 0;
   public Color shirtColorChoice = new Color(1.0f, 1.0f, 1.0f, 1.0f);

   public bool glassesChoice = false;
   public Color glassesColorChoice = new Color(1.0f, 1.0f, 1.0f, 1.0f);


   public bool beanieChoice = false;
   public Color beanieColorChoice = new Color(1.0f, 1.0f, 1.0f, 1.0f);

   public bool dimpleChoice = true;


   //public int accessoryChoice = 0;


   private void Awake()
   {
        // This means, don't destroy the very first instance of this object
        if (Instance == null) {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        } else {
            // If a duplicate is made by accident, destroy the duplicate! 
            Destroy(gameObject);
        }
   }
}
