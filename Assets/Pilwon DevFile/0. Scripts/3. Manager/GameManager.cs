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

    [Header("[ # Bool Var ]")]
    public bool isGameEnd = false;

    private void Awake()
    {
        instance = this;
    }
}

