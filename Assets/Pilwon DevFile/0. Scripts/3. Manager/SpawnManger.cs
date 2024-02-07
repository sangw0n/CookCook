using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    // Index 0 : Left | Index 1 : Right
    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private GameObject spawnPrefab;
    [SerializeField] private float spawnTime;

    [SerializeField] private int definiteSpawnCount = 0; // �ʿ��� ��� Ȯ�� ��ȯ ����
    [SerializeField] private int curDefiniteSpawnCount = 0; // �ʿ��� ��� Ȯ�� ��ȯ ����

    private WaitForSeconds waitForSeconds;

    private void Awake()
    {
        waitForSeconds = new WaitForSeconds(spawnTime);
        definiteSpawnCount = Random.Range(2, 4);
    }

    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner()
    {
        while (!GameManager.instance.isGameOver) 
        {
            int rSpawnIndex = Random.Range(0, spawnPoint.Length);
            GameObject clone = Instantiate(spawnPrefab, spawnPoint[rSpawnIndex].position, Quaternion.identity);
            SubPlate subPlate = clone.GetComponent<SubPlate>();

            // Move DirVec Init
            if (rSpawnIndex == 0) subPlate.MoveDirVec(Vector3.right);
            else subPlate.MoveDirVec(Vector3.left);

            // Plate Info Init
            if (curDefiniteSpawnCount >= definiteSpawnCount)
            {
                curDefiniteSpawnCount = 0;
                definiteSpawnCount = Random.Range(2, 4);
                var material = FGameManager.instance.currentFood.foodMaterials[FGameManager.instance.materialIndex];
                subPlate.Init(material.materialName, material.materialType, material.materialSprite);
            }
            else
            {
                curDefiniteSpawnCount++;
                int ranMaterial = Random.Range(0, FGameManager.instance.currentFood.foodMaterials.Length);
                var material = FGameManager.instance.currentFood.foodMaterials[ranMaterial];

                // �ᳪ���� �����ϸ� õ�� �ʱ�ȭ
                if (material.materialName == FGameManager.instance.currentFood.foodMaterials[FGameManager.instance.materialIndex].materialName) 
                        curDefiniteSpawnCount = 0;
                subPlate.Init(material.materialName, material.materialType, material.materialSprite);
            }
            yield return waitForSeconds;
        }
    }
}
