using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public SpriteRenderer spriteRenderer { get; private set; }
    public int health { get; private set; }
    public int point = 200;
    public Sprite[] states;
    public bool unbreakable;
    public Ball ball { get; private set; }

    public bool powerup;


    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.ball = FindObjectOfType<Ball>();
    }
    private void Start()
    {
        ResetBrick();

    }
    private void Hit()
    {
        if (this.unbreakable)
        {
            return;
        }
        if (this.powerup)
        {
            ball.PowerUp();
        }
        this.health--;
        if (this.health <= 0)
        {
            this.gameObject.SetActive(false);
        }
        else
        {
            this.spriteRenderer.sprite = this.states[this.health - 1];
        }
        FindObjectOfType<GameManager>().Hit(this);
    }

    private void OneHitDestroy()
    {
        if (this.unbreakable)
        {
            return;
        }
        int newPoint = 0;
        if (this.health >= 0)
        {
            for (int i = 0; i < this.health; i++)
            {
                newPoint += this.point;
                // Debug.Log("Point When got 1 hit" + newPoint);
            }
        }
        this.gameObject.SetActive(false);
        this.point = newPoint;
        FindObjectOfType<GameManager>().Hit(this);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            Hit();
        }

        if (collision.gameObject.name == "PowerBall")
        {
            OneHitDestroy();
        }

    }

    public void ResetBrick()
    {
        this.gameObject.SetActive(true);
        if (!this.unbreakable)
        {
            this.health = this.states.Length;
            this.spriteRenderer.sprite = this.states[this.health - 1];
        }
    }




}
