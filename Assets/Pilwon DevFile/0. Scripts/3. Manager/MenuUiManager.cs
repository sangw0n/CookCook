using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuUiManager : MonoBehaviour
{
    public static MenuUiManager instance { get; private set; }

    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private Transform StagePanel;
    public Button[] button;
    public GameObject[] checkObject;

    private void Awake()
    {
        instance = this;
    }

    public void StartButton()
    {
        mainMenuPanel.SetActive(false);
        Vector3 movePos = new Vector3(0, -38, 0);
        StagePanel.transform.DOLocalMove(movePos, 0.5f);
    }

    public void StageCancleButton()
    {
        Vector3 movePos = new Vector3(0, 921, 0);
        StagePanel.transform.DOLocalMove(movePos, 0.1f);
        mainMenuPanel.SetActive(true);
    }

    public void StageEnter(int index)
    {
        SceneManager.LoadScene("Stage " + index);
        StageManager.instance.clickStageIndex = index;
    }

}
