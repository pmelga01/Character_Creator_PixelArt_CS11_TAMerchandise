using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRenderer : MonoBehaviour
{

    public SpriteRenderer skin;
    //public SpriteRenderer eyes;

    public List<GameObject> hairs = new List<GameObject>();
    public List<GameObject> shirts = new List<GameObject>();

    private SpriteRenderer hair;
    private SpriteRenderer shirt;
    
    public GameObject glasses;
    public SpriteRenderer glassesColor;

    public GameObject beanie;
    public SpriteRenderer beanieColor;

    public GameObject dimples;


    void Start()
    {
        // skin = GameObject.FindWithTag("art_skin").GetComponent<SpriteRenderer>();
        updateCharacterArt();

    }

    void Awake()
    {
        //updateCharacterArt();
    }
    
    
    public void updateCharacterArt()
    {
        skin.color = PlayerPreferences.Instance.skinColorChoice;
        //eyes.color = PlayerPreferences.Instance.eyeColorChoice;

        //shirt.sprite = PlayerPreferences.Instance.shirtStyleChoice;
        //shirt.color = PlayerPreferences.Instance.shirtColorChoice;

        isolateSingle(PlayerPreferences.Instance.hairStyleChoice);
        hair = hairs[ PlayerPreferences.Instance.hairStyleChoice].GetComponent<SpriteRenderer>();
        hair.color = PlayerPreferences.Instance.hairColorChoice;


        isolateSingleShirt(PlayerPreferences.Instance.shirtStyleChoice);
        shirt = shirts[ PlayerPreferences.Instance.shirtStyleChoice].GetComponent<SpriteRenderer>();
        shirt.color = PlayerPreferences.Instance.shirtColorChoice;


        toggleGlasses(PlayerPreferences.Instance.glassesChoice);
        glassesColor.color = PlayerPreferences.Instance.glassesColorChoice;

        toggleBeanie(PlayerPreferences.Instance.beanieChoice);
        beanieColor.color = PlayerPreferences.Instance.beanieColorChoice;

        dimples.SetActive(PlayerPreferences.Instance.dimpleChoice);
    }


    void Update()
    {
        
    }

    public void toggleGlasses(bool isOn)
    {
        glasses.SetActive(isOn);
    }

    public void toggleBeanie(bool isOn)
    {
        beanie.SetActive(isOn);
    }

    public void toggleDimples()
    {
        bool d_choice = PlayerPreferences.Instance.dimpleChoice;
        d_choice = !d_choice;
        PlayerPreferences.Instance.dimpleChoice = d_choice;
        dimples.SetActive(d_choice);

        updateCharacterArt();
    }


    public void isolateSingle(int toKeep)
    {

        for (int i = 0; i < hairs.Count; i++)
        {
            if (i != toKeep) {
                hairs[i].SetActive(false);
            }


        }

        hairs[toKeep].SetActive(true);
    }


    public void isolateSingleShirt(int toKeep)
    {

        for (int i = 0; i < shirts.Count; i++)
        {
            if (i != toKeep) {
                shirts[i].SetActive(false);
            }


        }

        shirts[toKeep].SetActive(true);
    }


}
