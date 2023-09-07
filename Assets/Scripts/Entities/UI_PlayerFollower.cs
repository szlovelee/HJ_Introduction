using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerFollower : MonoBehaviour
{
    GameManager gameManagerInstance;
    GameObject player;
    Camera mainCamera;
    public Vector3 offset;
    public Canvas canvas;
    private RectTransform rectTransform;
    Text name;

    void Start()
    {
        gameManagerInstance = GameManager.Instance;
        player = gameManagerInstance.playerObject;
        mainCamera = player.GetComponent<PlayerInputController>()._camera;
        rectTransform = GetComponent<RectTransform>();
        name = GetComponent<Text>();
        name.text = gameManagerInstance.player.Name;
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
}
