using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{


    public new Rigidbody2D rigidbody { get; private set; }
    public SpriteRenderer spriteRenderer { get; private set; }
    public Sprite[] sprites;
    public float speed = 300f;
    private void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.rigidbody = GetComponent<Rigidbody2D>();
    }


    private void Start()
    {
        ResetBall();
    }

    private void SetRandomBronce()
    {
        Vector2 force = Vector2.zero;
        force.x = Random.Range(1f, 1f);
        force.y = -1f;
        this.rigidbody.AddForce(force.normalized * this.speed);
    }

    public void ResetBall()
    {
        this.transform.position = Vector2.zero;
        this.rigidbody.velocity = Vector2.zero;
        this.name = "Ball";
        this.spriteRenderer.sprite = this.sprites[0];
        Invoke(nameof(SetRandomBronce), 2f);
    }

    public void PowerUp()
    {
        this.name = "PowerBall";
        this.spriteRenderer.sprite = this.sprites[1];
    }

}
