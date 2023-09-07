using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 싱글톤
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 플레이어 정보 받기

    internal Player player;
    internal GameObject playerObject;
    internal HJ_CharacterController characterController;

    [SerializeField] private InputField input;
    [SerializeField] private GameObject nameInputpanel;
    [SerializeField] private Text username;
    [SerializeField] private GameObject nameWarning;


    // 캐릭터 생성 단계에 필요한 필드
    string inputName;
    internal Player.Type? type;
    public bool pinkIsSelected = false;
    public bool blueIsSelected = false;
    [SerializeField] internal GameObject pinkPrefab;
    [SerializeField] internal GameObject bluePrefab;

    //캐릭터 수정 단계에 필요
    internal CharacterSettingController characterSettingController;
    


    void Start()
    {
        characterSettingController = new CharacterSettingController();
        characterController = new HJ_CharacterController();
    }

    public void NameInput()
    {
        if (input.text.Length >= 2 && input.text.Length <= 10)
        {
            inputName = input.text;
            username.text = string.Format($"{inputName} 님,");
            nameInputpanel.SetActive(false);
        }
        else
        {
            nameWarning.SetActive(true);
            StartCoroutine(HideWarningAfterDelay(nameWarning, 4.0f)); // 2초 후에 텍스트를 비활성화
        }
        
    }

    public void CharSelect()
    {
        if (type != null)
        {
            player = new Player(inputName, type.Value);


            if (type == Player.Type.Pink) playerObject = Instantiate(pinkPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            else playerObject = Instantiate(bluePrefab, new Vector3(0, 0, 0), Quaternion.identity);
            
            DontDestroyOnLoad(playerObject);
            SceneController.ToMainScene();
            characterSettingController.CallCharacterChange(player.CharType);

        }
    }

    IEnumerator HideWarningAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.gameObject.SetActive(false);
    }
}


