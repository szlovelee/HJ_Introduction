using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : HJ_CharacterController
{

    internal Camera _camera;
    GameManager gameManager;
    CharacterSettingController charSettingController;

    private void Awake()
    {
        SceneController.SceneChange += FindingCamera;
        gameManager = GameManager.Instance;
        charSettingController = gameManager.characterSettingController;
        _camera = Camera.main;
    }

    private void Start()
    {
        charSettingController.OnPanelOpen += PauseMovement;
        charSettingController.OnPanelClose += ResumeMovement;
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
        CallMoveEvent(moveInput);
    }

    private void OnLook(InputValue value)
    {
        Vector2 mousePos = value.Get<Vector2>();
        Vector2 worldPos = _camera.ScreenToWorldPoint(mousePos);

        Vector2 direction = (worldPos - (Vector2)transform.position).normalized;

        if(direction.magnitude > 0.9f)
        {
            CallLookEvent(direction);
        }
    }

    internal void FindingCamera()
    {
        _camera = Camera.main;
    }
}
