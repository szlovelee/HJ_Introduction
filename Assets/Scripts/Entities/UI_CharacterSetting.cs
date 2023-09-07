using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_CharacterSetting : MonoBehaviour
{
    [SerializeField] Image profile_bg;
    [SerializeField] Image profile;
    [SerializeField] GameObject settingPanel;

    GameManager gameManager;
    CharacterSettingController controller;

    private void Awake()
    {
        gameManager = GameManager.Instance;
        controller = gameManager.characterSettingController;
    }
    private void Start()
    {
        controller.OnPanelOpen += PanelOpen;
        controller.OnPanelClose += PanelClose;
        controller.OnCharacterChange += SelectCharacter;
    }

    void PanelOpen()
    {
        profile.color = new Color32(246, 255, 155, 0);
        profile_bg.color = new Color32(255, 255, 255, 0);

        CharacterSettingController.isSettingPanelOpen = true;
        settingPanel.SetActive(true);
    }


    void PanelClose()
    {
        profile.color = new Color32(246, 255, 155, 255);
        profile_bg.color = new Color32(255, 255, 255, 50);

        CharacterSettingController.isSettingPanelOpen = false;
        settingPanel.SetActive(false);
    }

    void SelectCharacter(Player.Type type)
    {
        if (type == gameManager.player.CharType) return;
        Vector3 playerPos = gameManager.playerObject.transform.position;
        gameManager.player.CharType = type;
        Destroy(gameManager.playerObject);
        gameManager.playerObject = (type == Player.Type.Pink) ? Instantiate(gameManager.pinkPrefab, playerPos, Quaternion.identity) : Instantiate(gameManager.bluePrefab, playerPos, Quaternion.identity);
        DontDestroyOnLoad(gameManager.playerObject);
    }


}
