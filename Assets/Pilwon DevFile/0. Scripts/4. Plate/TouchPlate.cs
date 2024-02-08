using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TouchPlate : MonoBehaviour
{
    void Start()
    {
        PlateTouch();
        Destroy(gameObject, 1.5f);
    }

    void PlateTouch()
    {
        Vector3 distanceVec = transform.position - FGameManager.instance.mainPlate.transform.position;
        if (distanceVec.x > 0.01f)
        {
            Debug.Log("���������� ��~~");
        }
        else
        {
            Debug.Log("�������� ��~~");
        }
    }
}
