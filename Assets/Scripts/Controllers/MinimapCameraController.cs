using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MinimapCameraController :  MonoBehaviour 
{
    GameManager gameManager;
    GameObject player;

    private void Awake()
    {
        gameManager = GameManager.Instance;
        player = gameManager.playerObject;
    }

    private void Start()
    {
        gameManager.characterSettingController.OnCharacterChange += PlayerSetting;
    }

    private void Update()
    {
        float x = player.transform.position.x; ;
        float y  = player.transform.position.y;

        transform.position = new Vector3 (x, y, -10);
    }

    void PlayerSetting(Player.Type type)
    {
        player = gameManager.playerObject;
    }
}
