using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubPlate : MonoBehaviour
{
    [Header("[ Plate Info ]")]
    [SerializeField] private string materialName;
    [SerializeField] private MaterialType materialType;

    [Space(5), SerializeField] private float moveSpeed;
    private Vector3 dirVec;

    private SpriteRenderer materialSpriteRdr;
    private Rigidbody2D rigid;

    private void Awake()
    {
        materialSpriteRdr = GetComponentsInChildren<SpriteRenderer>()[1];
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigid.velocity = dirVec * moveSpeed * Time.fixedDeltaTime;
    }

    public void Init(string name, Sprite sprite)
    {
        this.materialName = name;
        materialSpriteRdr.sprite = sprite;
    }

    public void MoveDirVec(Vector3 dirVec)
    {
        this.dirVec = dirVec;
    }

    // Temp Code
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        MainPlate mainPlate = trigger.GetComponent<MainPlate>();
        FGameManager fGameManager = FGameManager.instance;

        if (trigger.CompareTag("MainPlate"))
        {
            if (mainPlate.foodMaterial.materialName == materialName)
            {
                mainPlate.foodMaterial.materialCount--;
                if(mainPlate.foodMaterial.materialCount <= 0)
                {
                    // �丮 �ϼ���
                    float maxAlpha = 1.0f; // �ִ� ����
                    float minAlpha = 0.2f; // �ּ� ����
                    float increment = (maxAlpha - minAlpha) / (fGameManager.currentFood.foodMaterials.Length - 1); // ��Ḧ ȹ���� ������ ������ ���� ��

                    float alpha = minAlpha + increment * fGameManager.materialIndex;
                    alpha = Mathf.Clamp(alpha, minAlpha, maxAlpha); // ������ minAlpha�� maxAlpha ���̿� �ӹ������� Ŭ����
                    mainPlate.spriteRdr.color = new Color(1f, 1f, 1f, alpha);

                    fGameManager.MaterialInit();
                }
                Debug.Log("����");
            }
            else
            {
                mainPlate.foodComplete--;
                Debug.Log("����");
            }
            Destroy(gameObject);
        }
    }
}
