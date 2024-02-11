using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginCharacter : MonoBehaviour
{
    [SerializeField] private Sprite[] characterFace;

    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void FaceSpriteInit(ECharacterFace num)
    {
        sprite.sprite = characterFace[(int)num];
    }
}
