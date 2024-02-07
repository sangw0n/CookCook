using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlate : MonoBehaviour
{
    [Header("Plate Info")]
    public string foodName;
    public FoodType foodType;

    [Header("Plate Cur Material Info")]
    public Material foodMaterial;

    public void Init(string foodName, FoodType foodType, Material material)
    {
        this.foodName = foodName;
        this.foodType = foodType;
        this.foodMaterial = material;
    }
}
