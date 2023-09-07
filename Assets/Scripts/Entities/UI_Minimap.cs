using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Minimap : MonoBehaviour
{
    GameManager gameManager;
    CharacterSettingController charSettingController;

    [SerializeField] Image minimapBorder;
    [SerializeField] Image minimapRenderer;
    [SerializeField] Image playerPos;

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameManager.Instance;
        charSettingController = gameManager.characterSettingController;
    }

    void Start()
    {
        charSettingController.OnPanelOpen += HideMinimap;
        charSettingController.OnPanelClose += ShowMinimap;
    }

    void HideMinimap()
    {
        minimapBorder.color = new Color32(95, 172, 255, 0);
        minimapRenderer.color = new Color32(255, 255, 255, 0);
        playerPos.color = new Color32(178, 248, 139, 0);
    }

    void ShowMinimap()
    {
        minimapBorder.color = new Color32(95, 172, 255, 255);
        minimapRenderer.color = new Color32(255, 255, 255, 255);
        playerPos.color = new Color32(178, 248, 139, 255);
    }
}
