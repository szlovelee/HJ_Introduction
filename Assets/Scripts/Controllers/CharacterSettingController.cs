using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSettingController
{
    internal static bool isSettingPanelOpen = false;

    public event Action OnPanelOpen;
    public event Action OnPanelClose;


    internal void CallPanelOpen()
    {
        OnPanelOpen?.Invoke();
    }

    internal void CallPanelClose()
    {
        OnPanelClose?.Invoke();
    }
   
}
