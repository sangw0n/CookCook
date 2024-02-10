using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlate : MonoBehaviour
{
    [Header("Plate Info")]
    public string foodName;
    public int foodComplete;
    public float timer;

    [Header("Plate Cur Material Info")]
    public Material foodMaterial;

    public SpriteRenderer spriteRdr;

    private void Awake()
    {
        spriteRdr = GetComponent<SpriteRenderer>();
    }

    public void Init(string foodName, Sprite foodImg, int foodComplete, float timer, Material material)
    {
        this.foodName = foodName;
        this.spriteRdr.sprite = foodImg;
        this.foodComplete = foodComplete;
        this.timer = timer;
        this.foodMaterial = material;

        // ó�� ���� ����
        float maxAlpha = 1.0f; // �ִ� ����
        float minAlpha = 0.2f; // �ּ� ����
        float increment = (maxAlpha - minAlpha) / (FGameManager.instance.currentFood.foodMaterials.Length - 1); // ��Ḧ ȹ���� ������ ������ ���� ��

        float alpha = minAlpha + increment * FGameManager.instance.materialIndex;
        alpha = Mathf.Clamp(alpha, minAlpha, maxAlpha); // ������ minAlpha�� maxAlpha ���̿� �ӹ������� Ŭ����
        spriteRdr.color = new Color(1f, 1f, 1f, alpha);
    }

    public void MaterialInit(Material material)
    {
        this.foodMaterial = material;
    }
}
