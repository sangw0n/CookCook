using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public int gameHp;

    [Header("[ # Bool Var ]")]
    public bool isGameOver = false;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        GameOver();
    }

    private void GameOver()
    {
        if (isGameOver) return;

        if (gameHp <= 0)
        {
            isGameOver = true;
            Debug.Log("Game Over");
        }
    }
}

