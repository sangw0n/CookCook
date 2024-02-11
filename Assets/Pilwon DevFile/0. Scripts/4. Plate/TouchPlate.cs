using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TouchPlate : MonoBehaviour
{
    void Start()
    {
        PlateTouch();
        Destroy(gameObject, 0.8f);
    }

    void PlateTouch()
    {
        Vector3 distanceVec = transform.position - FGameManager.instance.mainPlate.transform.position;
        if (distanceVec.x > 0.01f)
        {
            transform.DOMove(new Vector3(25.0f, 6.1f, 0), 0.65f).SetEase(GameManager.instance.ease);
            transform.DORotate(new Vector3(0, 0, -180), 0.75f);
        }
        else
        {
            transform.DOMove(new Vector3(-25.0f, 6.1f, 0), 0.65f).SetEase(GameManager.instance.ease);
            transform.DORotate(new Vector3(0, 0, 180), 0.75f);
        }
    }
}
