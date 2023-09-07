using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    GameManager gameManager;
    private Rigidbody2D _rigidbody;
    GameObject player;

    Vector2 _movementDirection = Vector2.zero;

    float speed = 5f;

    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    private void Start()
    {
        player = gameManager.playerObject;
        gameObject.GetComponent<HJ_CharacterController>().OnMoveEvent += Move;
        gameManager.characterSettingController.OnCharacterChange += PlayerSetting;
        _rigidbody = player.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_rigidbody != null) ApplyMovement(_movementDirection);
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * speed;
        _rigidbody.velocity = direction;
    }

    void PlayerSetting(Player.Type type)
    {
        player = gameManager.playerObject;
        _rigidbody = player.GetComponent<Rigidbody2D>();
    }
}
