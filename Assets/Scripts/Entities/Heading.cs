using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heading : MonoBehaviour
{
    GameManager gameManager;
    SpriteRenderer _mainSpriteRenderer;
    GameObject player;


    private void Awake()
    {
        gameManager = GameManager.Instance;
    }

    private void Start()
    {
        player = gameManager.playerObject;
        _mainSpriteRenderer = player.transform.Find("MainSprite").GetComponent<SpriteRenderer>();
        gameObject.GetComponent<HJ_CharacterController>().OnLookEvent += Look;
        gameManager.characterSettingController.OnCharacterChange += PlayerSetting;
    }

    private void Look(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        _mainSpriteRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }
    void PlayerSetting(Player.Type type)
    {
        player = gameManager.playerObject;
        _mainSpriteRenderer = player.transform.Find("MainSprite").GetComponent<SpriteRenderer>();
    }
}
