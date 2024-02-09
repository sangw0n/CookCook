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

    private SpriteRenderer spriteRdr;

    private void Awake()
    {
        spriteRdr = GetComponent<SpriteRenderer>();
    }

    public void Init(string foodName, FoodType foodType, Sprite foodImg, Material material)
    {
        this.foodName = foodName;
        this.foodType = foodType;
        this.spriteRdr.sprite = foodImg;
        this.foodMaterial = material;
    }

    public void MaterialInit(Material material)
    {
        this.foodMaterial = material;
    }
}
