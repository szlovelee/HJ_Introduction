using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class CharacterSettingController
{
    internal static bool isSettingPanelOpen = false;

    public event Action OnPanelOpen;
    public event Action OnPanelClose;
    internal event Action<Player.Type> OnCharacterChange;

    internal void CallPanelOpen()
    {
        OnPanelOpen?.Invoke();
    }

    internal void CallPanelClose()
    {
        OnPanelClose?.Invoke();
    }

    internal void CallCharacterChange(Player.Type type)
    {
        OnCharacterChange?.Invoke(type);
    }

}
