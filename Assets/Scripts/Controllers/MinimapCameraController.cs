using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MinimapCameraController : HJ_CharacterController
{
    GameManager gameManager;
    GameObject player;

    private void Awake()
    {
        gameManager = GameManager.Instance;
        player = gameManager.playerObject;
    }

    private void Update()
    {
        float x = player.transform.position.x; ;
        float y  = player.transform.position.y;

        transform.position = new Vector3 (x, y, -10);
    }
}
