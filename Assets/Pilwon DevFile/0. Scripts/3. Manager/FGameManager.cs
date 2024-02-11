using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class FGameManager : MonoBehaviour
{
    public static FGameManager instance { get; private set; }

    [SerializeField] private FoodData[] foodDatas;

    [Header("[ Game Data ] - No Data Modify!!")]
    [Space(5)]
    public Food currentFood;
    [SerializeField] private Food[] foods;

    [Space(5)]
    public  int foodIndex = 0;
    public int materialIndex = 0;
    public  MainPlate mainPlate;


    private void Awake()
    {
        instance = this;

        // Foods Array Size Init
        foods = new Food[foodDatas.Length];
    }

    private void Start()
    {
        for (int index = 0; index < foodDatas.Length; index++)
            C_FoodInit(index);

        FoodInit();
        Debug.Log(currentFood.foodMaterials.Length);
    }

    private void Update()
    {
        Timer();
    }

    #region # Array Init Functions
    private void C_FoodInit(int index)
    {
        foods[index] = new Food();
        foods[index].foodName = foodDatas[index].foodName;
        foods[index].foodSprite = foodDatas[index].foodSprite;
        foods[index].foodComplete = foodDatas[index].foodComplete;
        foods[index].timer = foodDatas[index].timer;

        MaterialInit(index);
    }

    private void MaterialInit(int index)
    {
        foods[index].foodMaterials = new Material[foodDatas[index].foodMaterials.Length];

        for (int index2 = 0; index2 < foods[index].foodMaterials.Length; index2++)
        {
            foods[index].foodMaterials[index2] = new Material();
            foods[index].foodMaterials[index2].materialName = foodDatas[index].foodMaterials[index2].materialName;
            foods[index].foodMaterials[index2].materialSprite = foodDatas[index].foodMaterials[index2].materialSprite;
            foods[index].foodMaterials[index2].materialCount = foodDatas[index].foodMaterials[index2].materialCount;
        }
    }
    #endregion

    #region Cook Init Function
    public void FoodInit()
    {
        currentFood = foods[foodIndex];

        MainPlate _mainPlate = mainPlate.GetComponent<MainPlate>();
        _mainPlate.Init(currentFood.foodName, currentFood.foodSprite, currentFood.foodComplete, currentFood.timer, currentFood.foodMaterials[materialIndex]);
    }

    public void MaterialInit()
    {
        // 재료가 남아있으면 재료설정
        if (materialIndex < currentFood.foodMaterials.Length - 1)
        {
            materialIndex++;
            MainPlate _mainPlate = mainPlate.GetComponent<MainPlate>();
            _mainPlate.MaterialInit(currentFood.foodMaterials[materialIndex]);
        }
        // 재료가 끝났으면 음식설정
        else
        {
            NextRecipeInit();
        }
    }

    public void NextRecipeInit()
    {
        materialIndex = 0;
        if (foodIndex == foods.Length - 1)
        {
            GameManager.instance.isGameEnd = true;
            GameManager.instance.plateSpawnParent.gameObject.SetActive(false);
            return;
        }
        foodIndex++;
        foreach (var item in GameManager.instance.plateSpawnParent.GetComponentsInChildren<SubPlate>())
        {
            Destroy(item.gameObject);
        }
        StartCoroutine(GameManager.instance.WaitFoodGame());
    }
    #endregion

    private void Timer()
    {
        if (GameManager.instance.isTimeOver) return;

        float timer = Mathf.Max(Mathf.FloorToInt(currentFood.timer -= Time.deltaTime), 0);
        GameManager.instance.timerText.text = timer.ToString();
        if (currentFood.timer <= 0)
        {
            GameManager.instance.isTimeOver = true;
            NextRecipeInit();
        }
    }
}
