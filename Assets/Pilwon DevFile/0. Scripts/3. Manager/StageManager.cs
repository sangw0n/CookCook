using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public static StageManager instance { get; private set; }

    public CButton[] stageButtons;
    public int clickStageIndex;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        for(int i = 0; i < stageButtons.Length; i++)
        {
            if (!stageButtons[i].isClear)
            {
                MenuUiManager.instance.button[i].image.color = new Color32(197, 197, 197, 165);
                TMP_Text text = MenuUiManager.instance.button[i].GetComponentInChildren<TMP_Text>();
                text.color = new Color32(255, 255, 255, 165);

                // Touch False
                MenuUiManager.instance.button[i].interactable = false;
            }
        }
    }

    public void StageClear(int index)
    {
        MenuUiManager.instance.button[index - 1].image.color = new Color32(197, 197, 197, 255);
        TMP_Text text = MenuUiManager.instance.button[index - 1].GetComponentInChildren<TMP_Text>();
        text.color = new Color32(255, 255, 255, 255);

        MenuUiManager.instance.button[index - 1].interactable = true;
    }
}
