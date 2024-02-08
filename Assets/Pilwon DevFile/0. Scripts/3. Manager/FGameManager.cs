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
        _mainPlate.Init(currentFood.foodName, currentFood.foodType, currentFood.foodMaterials[foodIndex]);
    }
}
