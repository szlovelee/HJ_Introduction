using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : HJ_CharacterController
{

    internal Camera _camera;
    GameManager gameManager;
    GameObject playerObject;

    private void Awake()
    {
        SceneController.SceneChange += FindingCamera;
        gameManager = GameManager.Instance;
        _camera = Camera.main;
    }

    private void Start()
    {
        playerObject = gameManager.playerObject;
        gameManager.characterSettingController.OnPanelOpen += PauseMovement;
        gameManager.characterSettingController.OnPanelClose += ResumeMovement;
        gameManager.characterSettingController.OnCharacterChange += PlayerSetting;
    }


    private void PauseMovement()
    {
        gameObject.GetComponent<PlayerInput>().enabled = false;
    }

    private void ResumeMovement()
    {
        gameObject.GetComponent<PlayerInput>().enabled = true;
    }

    private void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        gameObject.GetComponent<HJ_CharacterController>().CallMoveEvent(moveInput);
    }

    private void OnLook(InputValue value)
    {
        Vector2 mousePos = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(mousePos);

        Vector2 direction = (worldPos - (Vector2)playerObject.transform.position).normalized;

        if (direction.magnitude > 0.9f)
        {
            gameObject.GetComponent<HJ_CharacterController>().CallLookEvent(direction);
        }

    }

    internal void FindingCamera()
    {
        _camera = Camera.main;
    }

    void PlayerSetting(Player.Type type)
    {
        playerObject = gameManager.playerObject;
    }
}
