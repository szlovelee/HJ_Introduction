using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerFollower : MonoBehaviour
{
    GameManager gameManager;
    GameObject player;
    Camera mainCamera;
    public Vector3 offset;
    public Canvas canvas;
    private RectTransform rectTransform;
    Text name;

    void Start()
    {
        gameManager = GameManager.Instance;
        player = gameManager.playerObject;
        mainCamera = Camera.main;
        rectTransform = GetComponent<RectTransform>();
        name = GetComponent<Text>();
        name.text = gameManager.player.Name;
        gameManager.characterSettingController.OnCharacterChange += PlayerSetting;
        
    }

    void LateUpdate()
    {
        // distance = player.transform.position - mainCamera.transform.position;
        Vector3 playerPos = player.transform.position;
        Vector3 camPos = mainCamera.transform.position;

        offset = new Vector2(0, 50);

        // ¿ùµåÁÂÇ¥ --> ½ºÅ©¸°ÁÂÇ¥
        Vector2 screenPosition = mainCamera.WorldToScreenPoint(playerPos) + offset;

        //screenPosition += (Vector2)(playerPos - camPos);


        Vector2 anchoredPosition = screenPosition - new Vector2(canvas.pixelRect.width / 2, canvas.pixelRect.height / 2);

        rectTransform.anchoredPosition = anchoredPosition;
    }

    void PlayerSetting(Player.Type type)
    {
        player = gameManager.playerObject;
    }
}
