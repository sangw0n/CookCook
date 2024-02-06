using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FGameManager : MonoBehaviour
{
    [SerializeField] private FoodData[] foodDatas;

    [Header("[ Game Data ] - No Data Modify!!")]
    public Food[] foods;

    private void Awake()
    {
        StartCoroutine(C_ArrayInit());
    }

    private void Start()
    {
        for (int index = 0; index < foodDatas.Length; index++)
        {
            StartCoroutine(C_FoodInit(index));
        }
    }

    #region Array Init Function
    private IEnumerator C_ArrayInit()
    {
        // 음식 배열 초기화
        foods = new Food[foodDatas.Length];

        // 한 프레임 대기 
        yield return null;
        
        // 음식의 재료 배열 초기화
        for (int index = 0; index < foodDatas.Length; index++)
        {
            foods[index].foodMaterials = new Material[foodDatas[index].foodMaterials.Length];
        }
    }

    private IEnumerator C_FoodInit(int index)
    {
        foods[index].foodName = foodDatas[index].foodName;
        foods[index].foodType = foodDatas[index].foodType;
        foods[index].foodSprite = foodDatas[index].foodSprite;

        yield return null;  
        MaterialInit(index);
    }

    private void MaterialInit(int index)
    {
        for (int index2 = 0; index2 < foods[index].foodMaterials.Length; index2++)
        {
            foods[index].foodMaterials[index2].materialName = foodDatas[index].foodMaterials[index2].materialName;
            foods[index].foodMaterials[index2].materialType = foodDatas[index].foodMaterials[index2].materialType;
            foods[index].foodMaterials[index2].materialSprite = foodDatas[index].foodMaterials[index2].materialSprite;
            foods[index].foodMaterials[index2].materialCount = foodDatas[index].foodMaterials[index2].materialCount;
        }
    }
    #endregion
}
