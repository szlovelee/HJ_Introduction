using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    GameManager gameManager;
    GameObject player;
    private void Awake()
    {
        SceneController.InformSceneChange();
    }

    private void Start()
    {
        gameManager = GameManager.Instance;
        player = gameManager.playerObject;
        gameManager.characterSettingController.OnCharacterChange += PlayerSetting;
    }

    private void Update()
    {
        float x;
        float y;

        if (player.transform.position.x >= -33 && player.transform.position.x <= 10) x = player.transform.position.x;
        else if (player.transform.position.x < -33) x = -33;
        else x = 10;

        if (player.transform.position.y >= -17 && player.transform.position.y <= 8) y = player.transform.position.y;
        else if (player.transform.position.y < -17) y = -17;
        else y = 8;

        transform.position = new Vector3 (x, y, -10);
    }

    void PlayerSetting(Player.Type type)
    {
        player = gameManager.playerObject;
    }
}
