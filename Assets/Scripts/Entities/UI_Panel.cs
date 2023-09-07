using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Panel : MonoBehaviour
{
    CharacterSettingController controller;

    private void Start()
    {
        controller = GameManager.Instance.characterSettingController;

    }

    public void OnExitClick()
    {
        controller.CallPanelClose();
    }
}
