using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MinimapCameraController : HJ_CharacterController
{
    GameManager gameManagerInstance;
    GameObject player;

    private void Start()
    {
        gameManagerInstance = GameManager.Instance;
        player = gameManagerInstance.playerObject;
    }

    private void Update()
    {
        float x = player.transform.position.x; ;
        float y  = player.transform.position.y;

        transform.position = new Vector3 (x, y, -10);
    }
}
