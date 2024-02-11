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
        // ���� ���� �ٽ� �ҷ��´�.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ContinueButton()
    {
        GameManager.instance.isPause = false;
        menuPanel.SetActive(false);
    }

    public void HomeButton()
    {
        Debug.Log("���θ޴��� �̵�~~");
    }
}
