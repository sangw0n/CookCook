using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public int gameHp;

    [Header("[ # GameObject ]")]
    public Transform plateSpawnParent;
    public Character animCharacter;
    public OriginCharacter originCharacter;

    [Header("[ # Effect GameObject ]")]
    public GameObject goodParticle;
    public GameObject badParticle;
    public GameObject sparkleParticle;
    public Transform particleSpawnPos;

    [Header("[ # Dotween Var ]")]
    public Ease ease;

    [Header("[ # Timer Var ]")]
    public TMP_Text timerText;
    public float waitFoodTime;

    [Header("[ # Bool Var ]")]
    public bool isGameEnd = false;
    public bool isFoodComplete = false;
    public bool isTimeOver = false;
    public bool isPause = false;

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
        isFoodComplete = true; // 음식이 완성되면 재료 소환이 안됨
        Face(); // 캐릭터 표정 설정
        yield return waitForSeconds;
        isFoodComplete = false;
        isTimeOver = false;
        FGameManager.instance.FoodInit();
    }

    #region Character Face Function
    public void Face()
    {
        var foodComplete = FGameManager.instance.mainPlate.foodComplete;

        StartCoroutine(CharacterSetActive());
        if (foodComplete >= 9) originCharacter.FaceSpriteInit(ECharacterFace.Delicious);
        else if (foodComplete >= 7) originCharacter.FaceSpriteInit(ECharacterFace.Happy);
        else if (foodComplete >= 5) originCharacter.FaceSpriteInit(ECharacterFace.SoSo);
        else if (foodComplete >= 3) originCharacter.FaceSpriteInit(ECharacterFace.Angry);
        else originCharacter.FaceSpriteInit(ECharacterFace.Tasteless);
    }

    private IEnumerator CharacterSetActive()
    {
        animCharacter.gameObject.SetActive(false);
        originCharacter.gameObject.SetActive(true);
        yield return waitForSeconds;
        animCharacter.gameObject.SetActive(true);
        originCharacter.gameObject.SetActive(false);
    }
    #endregion
}

