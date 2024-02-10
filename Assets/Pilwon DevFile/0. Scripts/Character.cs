using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float blinkTime;

    private WaitForSeconds waitForSeconds;

    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        waitForSeconds = new WaitForSeconds(blinkTime);
    }

    private void Start()
    {
        StartCoroutine(BlinkEye());
    }

    private IEnumerator BlinkEye()
    {
        while (!GameManager.instance.isGameEnd)
        {
            anim.SetTrigger("Blink");
            yield return waitForSeconds;
        }
    }
}
