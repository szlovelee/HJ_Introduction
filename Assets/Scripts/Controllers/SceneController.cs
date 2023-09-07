using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{ 

    public static event Action SceneChange;
    internal static void ToMainScene()
    {
        SceneManager.LoadScene("MainScene");
        InformSceneChange();
    }

    internal static void InformSceneChange()
    {
        SceneChange?.Invoke();
    }

}
