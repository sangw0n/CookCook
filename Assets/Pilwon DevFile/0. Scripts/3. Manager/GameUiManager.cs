using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUiManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;

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
        Debug.Log("메인메뉴로 이동~~");
    }
}
