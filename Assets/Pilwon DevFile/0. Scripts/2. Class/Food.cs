using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Food
{
    public string foodName;
    public FoodType foodType;
    public Sprite foodSprite;

    [Space(10)] public Material[] foodMaterials;
}
