using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UI_CharacterSetting : MonoBehaviour
{
    [SerializeField] Image profile_bg;
    [SerializeField] Image profile;
    [SerializeField] GameObject minimap;
    [SerializeField] GameObject settingPanel;

    CharacterSettingController controller;

    private void Awake()
    {
        controller = GameManager.Instance.characterSettingController;
    }
    private void Start()
    {
        controller.OnPanelOpen += PanelOpen;
        controller.OnPanelClose += PanelClose;
    }

    void PanelOpen()
    {
        minimap.SetActive(false);

        profile.color = new Color32(246, 255, 155, 0);
        profile_bg.color = new Color32(255, 255, 255, 0);

        CharacterSettingController.isSettingPanelOpen = true;
        settingPanel.SetActive(true);
    }


    void PanelClose()
    {
        minimap.SetActive(true);

        profile.color = new Color32(246, 255, 155, 255);
        profile_bg.color = new Color32(255, 255, 255, 50);

        CharacterSettingController.isSettingPanelOpen = false;
        settingPanel.SetActive(false);
    }  


}
