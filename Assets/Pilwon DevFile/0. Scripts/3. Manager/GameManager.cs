using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public int gameHp;
    public Transform plateSpawnParent;
    public Ease ease;

    [Header("[ # Timer Var ]")]
    public float waitFoodTime;

    [Header("[ # Bool Var ]")]
    public bool isGameEnd = false;
    public bool isFoodComplete = false;

    private WaitForSeconds waitForSeconds;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        waitForSeconds = new WaitForSeconds(waitFoodTime);
    }

    public IEnumerator WaitFoodGame()
    {
        isFoodComplete = true;
        yield return waitForSeconds;
        isFoodComplete = false;
    }
}

