using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Sprite[] characterFace;
    [SerializeField] private float blinkTime;

    private WaitForSeconds waitForSeconds;

    private Animator anim;
    private SpriteRenderer sprite;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
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
            if(!GameManager.instance.isFoodComplete)
            {
                anim.SetTrigger("Blink");
            }
            yield return waitForSeconds;
        }
    }
}
