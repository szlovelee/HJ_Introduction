using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heading : MonoBehaviour
{

    private HJ_CharacterController _controller;
    private SpriteRenderer _mainSpriteRenderer;


    private void Awake()
    {
        _controller = GetComponent<HJ_CharacterController>();
        _mainSpriteRenderer = transform.Find("MainSprite").GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _controller.OnLookEvent += Look;
    }

    private void Look(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        _mainSpriteRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }
}
