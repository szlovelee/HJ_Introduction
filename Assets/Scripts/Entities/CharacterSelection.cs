using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    GameManager gameManagerInstance;

    [SerializeField] private Image pinkLight;
    [SerializeField] private Image blueLight;


    private void Start()
    {
        gameManagerInstance = GameManager.Instance;
    }

    public void pinkSelected()
    {
        gameManagerInstance.type = Player.Type.Pink;
        gameManagerInstance.pinkIsSelected = true;
        gameManagerInstance.blueIsSelected = false;
        BlueLightOff();
        PinkLightOn();
    }

    public void blueSelected()
    {
        gameManagerInstance.type = Player.Type.Blue;
        gameManagerInstance.blueIsSelected = true;
        gameManagerInstance.pinkIsSelected = false;
        PinkLightOff();
        BlueLightOn();
    }

    public void PinkLightOn()
    {
        pinkLight.color = new Color32(208, 255, 0, 112);
    }

    public void PinkLightOff()
    {
        if (!gameManagerInstance.pinkIsSelected) pinkLight.color = new Color32(208, 255, 0, 0);
    }

    public void BlueLightOn()
    {
        blueLight.color = new Color32(208, 255, 0, 112);
    }

    public void BlueLightOff()
    {
        if (!gameManagerInstance.blueIsSelected) blueLight.color = new Color32(208, 255, 0, 0);
    }
}
