using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

public class UI_Profile : MonoBehaviour
{
    [SerializeField] Image profile_bg;

    CharacterSettingController controller;

    private void Awake()
    {
        controller = GameManager.Instance.characterSettingController;
    }

    public void OnProfileClick()
    {
        controller.CallPanelOpen();
    }
    
    public void OnProfileHover()
    {
        if (!CharacterSettingController.isSettingPanelOpen)
        profile_bg.color = new Color32(255, 255, 255, 70);
    }

    public void OnProfileExit()
    {
        if (!CharacterSettingController.isSettingPanelOpen)
        profile_bg.color = new Color32(255, 255, 255, 30);
    }
}
