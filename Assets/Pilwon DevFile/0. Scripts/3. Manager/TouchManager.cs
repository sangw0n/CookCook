using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : MonoBehaviour
{
    [SerializeField] private LayerMask clickLayer;

    private void Update()
    {
        Click();
    }

    private void Click()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0.0f, clickLayer);

            if(hit.collider != null && hit.collider.CompareTag("SubPlate"))
            {
                hit.collider.gameObject.AddComponent<TouchPlate>(); 
            }
        }
    }
}
