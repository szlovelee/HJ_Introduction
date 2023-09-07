using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HJ_CharacterController : MonoBehaviour 
{
    internal event Action<Vector2> OnMoveEvent;
    internal event Action<Vector2> OnLookEvent;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }
}
