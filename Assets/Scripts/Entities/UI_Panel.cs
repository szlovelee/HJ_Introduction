using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Panel : MonoBehaviour
{
    CharacterSettingController controller;
    GameManager gameManager;

    Player.Type tempType;

    [SerializeField] Image pinkLight;
    [SerializeField] Image blueLight;
    [SerializeField] Sprite pinkSource;
    [SerializeField] Sprite blueSource;
    [SerializeField] GameObject playerImage;

    private void Awake()
    {
        gameManager = GameManager.Instance;
        controller = gameManager.characterSettingController;
        tempType = gameManager.player.CharType;
        if (tempType == Player.Type.Pink)
        {
            pinkLight.color = new Color32(145, 255, 114, 38);
            playerImage.GetComponent<Image>().sprite = pinkSource;
        }
        else
        {
            blueLight.color = new Color32(145, 255, 114, 38);
            playerImage.GetComponent<Image>().sprite = pinkSource;
        }
    }


    public void OnExitClick()
    {
        controller.CallPanelClose();
        controller.CallCharacterChange(tempType);
    }

    public void ChangePlayerName()
    {

    }

    public void SelectPink()
    {
        tempType = Player.Type.Pink;
        pinkLight.color = new Color32(145, 255, 114, 38);
        blueLight.color = new Color32(145, 255, 114, 0);
        playerImage.GetComponent<Image>().sprite = pinkSource;

    }

    public void SelectBlue()
    {
        tempType = Player.Type.Blue;
        blueLight.color = new Color32(145, 255, 114, 38);
        pinkLight.color = new Color32(145, 255, 114, 0);
        playerImage.GetComponent<Image>().sprite = blueSource;
    }


}
