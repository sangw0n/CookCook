using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUiManager : MonoBehaviour
{
    public static GameUiManager instance { get; private set; }

    [SerializeField] private GameObject menuPanel;
    public GameObject gameEndPanel;
    public TMP_Text nextStageText;

    private void Awake()
    {
        instance = this;
    }

    public void MenuButton()
    {
        GameManager.instance.isPause = true;
        menuPanel.SetActive(true);
    }

    public void RetryButton()
    {
        // 현재 씬을 다시 불러온다.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ContinueButton()
    {
        GameManager.instance.isPause = false;
        menuPanel.SetActive(false);
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
