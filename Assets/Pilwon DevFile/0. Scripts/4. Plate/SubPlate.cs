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

    public void Init(string name, MaterialType type, Sprite sprite)
    {
        this.materialName = name;
        this.materialType = type;
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

        if (trigger.CompareTag("MainPlate"))
        {
            if (mainPlate.foodMaterial.materialName == materialName)
            {
                Debug.Log("성공");
            }
            else
            {
                GameManager.instance.gameHp--;
                Debug.Log("실패");
            }
            Destroy(gameObject);
        }
    }
}
