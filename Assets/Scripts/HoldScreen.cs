using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldScreen : MonoBehaviour
{

    public Sprite[] states;
    public SpriteRenderer spriteRenderer { get; private set; }
    private int nowSprite;
    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        showOnHold();
    }


    private void changeSprites()
    {
        if (this.nowSprite > 0)
        {
            this.spriteRenderer.sprite = this.states[--this.nowSprite];
            Invoke(nameof(changeSprites), 0.3f);
        }
        else { this.gameObject.SetActive(false); }
    }

    public void showOnHold()
    {
        this.gameObject.SetActive(true);
        this.nowSprite = this.states.Length;
        Invoke(nameof(changeSprites), 0.3f);
    }
}
