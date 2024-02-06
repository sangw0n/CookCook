using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FoodData", menuName = "Scriptable Object/FoodData")]
public class FoodData : ScriptableObject
{
    public string foodName;
    public FoodType foodType;
    public Sprite foodSprite;

    [Space(10)] public Material[] foodMaterials;
}
