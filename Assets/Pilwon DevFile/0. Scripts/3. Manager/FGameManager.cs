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
    [ReadOnly(true)] public int foodIndex = 0;
    [ReadOnly(true)] public int materialIndex = 0;
    public GameObject mainPlate;


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

    #region # Array Init Functions
    private void C_FoodInit(int index)
    {
        foods[index] = new Food();
        foods[index].foodName = foodDatas[index].foodName;
        foods[index].foodType = foodDatas[index].foodType;
        foods[index].foodSprite = foodDatas[index].foodSprite;

        MaterialInit(index);
    }

    private void MaterialInit(int index)
    {
        foods[index].foodMaterials = new Material[foodDatas[index].foodMaterials.Length];

        for (int index2 = 0; index2 < foods[index].foodMaterials.Length; index2++)
        {
            foods[index].foodMaterials[index2] = new Material();
            foods[index].foodMaterials[index2].materialName = foodDatas[index].foodMaterials[index2].materialName;
            foods[index].foodMaterials[index2].materialType = foodDatas[index].foodMaterials[index2].materialType;
            foods[index].foodMaterials[index2].materialSprite = foodDatas[index].foodMaterials[index2].materialSprite;
            foods[index].foodMaterials[index2].materialCount = foodDatas[index].foodMaterials[index2].materialCount;
        }
    }
    #endregion

    public void FoodInit()
    {
        currentFood = foods[foodIndex];
        currentFood.foodType = FoodType.CurFood;

        MainPlate _mainPlate = mainPlate.GetComponent<MainPlate>();
        _mainPlate.Init(currentFood.foodName, currentFood.foodType, currentFood.foodSprite, currentFood.foodMaterials[materialIndex]);
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
            materialIndex = 0;
            // 음식까지 다 끝났으면
            if (foodIndex == foods.Length - 1)
            {
                GameManager.instance.isGameEnd = true;
                GameManager.instance.plateSpawnParent.gameObject.SetActive(false);
                return;
            }
            foodIndex++;
            // 음식 완성되면 대기
            StartCoroutine(GameManager.instance.WaitFoodGame());
            foreach (var item in GameManager.instance.plateSpawnParent.GetComponentsInChildren<SubPlate>())
            {
                Destroy(item.gameObject);
            }
            
            FoodInit();
        }
    }
}
